using DVDCollectRAPI.Data;
using DVDCollectRAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Controllers;

[ApiController]
[Route("api/tmdb")]
public class TmdbController : ControllerBase
{
    private readonly TmdbSyncService _syncService;
    private readonly DvdDbContext _db;
    private readonly ILogger<TmdbController> _logger;

    public TmdbController(TmdbSyncService syncService, DvdDbContext db, ILogger<TmdbController> logger)
    {
        _syncService = syncService;
        _db = db;
        _logger = logger;
    }

    [HttpPost("sync/start")]
    public async Task<ActionResult<object>> StartSync()
    {
        var (status, total, completed, currentTitle) = _syncService.GetStatus();
        if (status == SyncStatus.Running)
        {
            return Conflict(new { message = "A sync is already in progress", status, total, completed });
        }

        await _syncService.StartSyncAsync();

        (status, total, completed, currentTitle) = _syncService.GetStatus();
        return Ok(new { status = status.ToString(), total, completed, currentTitle });
    }

    [HttpGet("sync/status")]
    public ActionResult<object> GetStatus()
    {
        var (status, total, completed, currentTitle) = _syncService.GetStatus();
        return Ok(new { status = status.ToString(), total, completed, currentTitle });
    }

    [HttpGet("settings/key")]
    public async Task<ActionResult<object>> GetApiKey()
    {
        try
        {
            var setting = await _db.AppSettings.FindAsync("TMDB_API_KEY");
            var key = setting?.Value;
            if (string.IsNullOrEmpty(key))
            {
                key = HttpContext.RequestServices.GetRequiredService<IConfiguration>()["TMDB_API_KEY"];
            }

            var masked = key is { Length: > 0 }
                ? new string('•', Math.Max(0, key.Length - 4)) + key[^4..]
                : null;

            return Ok(new { key = masked, hasKey = !string.IsNullOrEmpty(key) });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reading TMDB API key");
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPut("settings/key")]
    public async Task<ActionResult<object>> SetApiKey([FromBody] SetApiKeyRequest request)
    {
        try
        {
            var setting = await _db.AppSettings.FindAsync("TMDB_API_KEY");
            if (setting == null)
            {
                setting = new AppSettingEntity { Key = "TMDB_API_KEY" };
                _db.AppSettings.Add(setting);
            }

            setting.Value = request.Key ?? string.Empty;
            await _db.SaveChangesAsync();

            return Ok(new { message = "API key updated" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving TMDB API key");
            return StatusCode(500, new { error = ex.Message });
        }
    }

    public class SetApiKeyRequest
    {
        public string? Key { get; set; }
    }
}
