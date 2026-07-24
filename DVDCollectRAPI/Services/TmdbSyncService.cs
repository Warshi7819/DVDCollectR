using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using DVDCollectRAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Services;

public enum SyncStatus
{
    Idle,
    Running,
    Completed
}

public class TmdbSyncService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TmdbSyncService> _logger;
    private readonly HttpClient _httpClient;

    private readonly Channel<int> _workChannel = Channel.CreateUnbounded<int>();

    private volatile SyncStatus _status = SyncStatus.Idle;
    private volatile int _total;
    private volatile int _completed;
    private volatile string? _currentTitle;

    private DateTime _lastRequestTime = DateTime.MinValue;
    private readonly object _rateLimitLock = new();

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public TmdbSyncService(
        IServiceScopeFactory scopeFactory,
        IConfiguration configuration,
        ILogger<TmdbSyncService> logger)
    {
        _scopeFactory = scopeFactory;
        _configuration = configuration;
        _logger = logger;
        _httpClient = new HttpClient();
    }

    public (SyncStatus Status, int Total, int Completed, string? CurrentTitle) GetStatus()
    {
        var status = _status;
        if (status == SyncStatus.Completed && _completed >= _total)
        {
            status = SyncStatus.Idle;
        }
        return (status, _total, _completed, _currentTitle);
    }

    public async Task StartSyncAsync()
    {
        if (_status == SyncStatus.Running)
            return;

        using var scope = _scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DvdDbContext>();

        var cutoff = DateTime.UtcNow.AddDays(-30);

        var dvdIds = await db.DVDs
            .Where(d => d.Tmdb == null || d.Tmdb.LastUpdated == null || d.Tmdb.LastUpdated < cutoff)
            .Select(d => d.Id)
            .ToListAsync();

        if (dvdIds.Count == 0)
        {
            _status = SyncStatus.Completed;
            _total = 0;
            _completed = 0;
            _currentTitle = null;
            return;
        }

        _total = dvdIds.Count;
        _completed = 0;
        _currentTitle = null;
        _status = SyncStatus.Running;

        foreach (var id in dvdIds)
        {
            await _workChannel.Writer.WriteAsync(id);
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var dvdId in _workChannel.Reader.ReadAllAsync(stoppingToken))
        {
            await ProcessDvdAsync(dvdId, stoppingToken);

            Interlocked.Increment(ref _completed);

            if (_completed >= _total)
            {
                _status = SyncStatus.Completed;
                _currentTitle = null;
            }
        }
    }

    private async Task ProcessDvdAsync(int dvdId, CancellationToken ct)
    {
        using var scope = _scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DvdDbContext>();

        var dvd = await db.DVDs.FirstOrDefaultAsync(d => d.Id == dvdId, ct);
        if (dvd == null)
            return;

        _currentTitle = dvd.Title;

        await WaitForRateLimitAsync(ct);

        var apiKey = await GetApiKeyAsync(db);
        if (string.IsNullOrEmpty(apiKey))
        {
            _logger.LogWarning("TMDB API key not configured. Skipping DVD {Id}: {Title}", dvdId, dvd.Title);
            return;
        }

        var title = Uri.EscapeDataString(dvd.OriginalTitle ?? dvd.Title);
        var url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={title}";
        if (dvd.ProductionYear.HasValue)
        {
            url += $"&year={dvd.ProductionYear.Value}";
        }

        try
        {
            var response = await _httpClient.GetAsync(url, ct);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(ct);
            var result = JsonSerializer.Deserialize<TmdbSearchResult>(json, JsonOptions);
            var movie = result?.Results?.FirstOrDefault();

            var existing = await db.Tmdb.FirstOrDefaultAsync(t => t.DvdId == dvdId, ct);
            if (existing == null)
            {
                existing = new TmdbEntity { DvdId = dvdId };
                db.Tmdb.Add(existing);
            }

            if (movie != null)
            {
                existing.TmdbId = movie.Id;
                existing.PosterPath = movie.PosterPath;
                existing.VoteAverage = movie.VoteAverage;
                existing.VoteCount = movie.VoteCount;
                existing.Overview = movie.Overview;
            }
            else
            {
                existing.TmdbId = null;
                existing.PosterPath = null;
                existing.VoteAverage = null;
                existing.VoteCount = null;
                existing.Overview = null;
            }

            existing.LastUpdated = DateTime.UtcNow;
            await db.SaveChangesAsync(ct);

            _logger.LogInformation("TMDB updated for DVD {Id}: {Title}", dvdId, dvd.Title);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "TMDB sync failed for DVD {Id}: {Title}", dvdId, dvd.Title);
        }
    }

    private async Task WaitForRateLimitAsync(CancellationToken ct)
    {
        TimeSpan delay;
        lock (_rateLimitLock)
        {
            var elapsed = DateTime.UtcNow - _lastRequestTime;
            delay = elapsed < TimeSpan.FromSeconds(30)
                ? TimeSpan.FromSeconds(30) - elapsed
                : TimeSpan.Zero;
            _lastRequestTime = DateTime.UtcNow.Add(delay > TimeSpan.Zero ? delay : TimeSpan.Zero);
        }

        if (delay > TimeSpan.Zero)
        {
            await Task.Delay(delay, ct);
        }
    }

    private async Task<string?> GetApiKeyAsync(DvdDbContext db)
    {
        var setting = await db.AppSettings.FindAsync("TMDB_API_KEY");
        if (setting != null && !string.IsNullOrEmpty(setting.Value))
            return setting.Value;

        return _configuration["TMDB_API_KEY"];
    }

    private sealed class TmdbSearchResult
    {
        public List<TmdbMovie>? Results { get; set; }
    }

    private sealed class TmdbMovie
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        [JsonPropertyName("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int? VoteCount { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }
    }
}
