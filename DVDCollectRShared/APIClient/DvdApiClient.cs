using System.Net.Http.Json;
using System.Text.Json;
using DVDCollectRShared.Dtos;

namespace DVDCollectRShared.APIClient;

public class DvdApiClient
{
    private readonly HttpClient _http;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public DvdApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<PagedResult<DvdResponse>> GetAllAsync(
        string? title = null, string? actor = null, string? genre = null,
        int page = 1, int pageSize = 10)
    {
        var queryParams = new List<string>
        {
            $"page={page}",
            $"pageSize={pageSize}"
        };

        if (!string.IsNullOrWhiteSpace(title))
        {
            queryParams.Add($"title={Uri.EscapeDataString(title)}");
        }
        if (!string.IsNullOrWhiteSpace(actor))
        {
            queryParams.Add($"actor={Uri.EscapeDataString(actor)}");
        }
        if (!string.IsNullOrWhiteSpace(genre))
        {
            queryParams.Add($"genre={Uri.EscapeDataString(genre)}");
        }

        var response = await _http.GetAsync($"/api/dvds?{string.Join("&", queryParams)}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PagedResult<DvdResponse>>(JsonOptions)
            ?? new PagedResult<DvdResponse> { Page = page, PageSize = pageSize };
    }

    public async Task<DvdResponse?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"/api/dvds/{id}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DvdResponse>(JsonOptions);
    }


    public async Task<List<string>> GetGenresAsync()
    {
        var response = await _http.GetAsync("/api/genres");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<string>>(JsonOptions)
            ?? [];
    }

    public async Task<TmdbSyncStatus> StartTmdbSyncAsync()
    {
        var response = await _http.PostAsync("/api/tmdb/sync/start", null);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TmdbSyncStatus>(JsonOptions)
            ?? new TmdbSyncStatus();
    }

    public async Task<TmdbSyncStatus> GetTmdbSyncStatusAsync()
    {
        var response = await _http.GetAsync("/api/tmdb/sync/status");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TmdbSyncStatus>(JsonOptions)
            ?? new TmdbSyncStatus();
    }

    public async Task<TmdbApiKeyResponse> GetTmdbApiKeyAsync()
    {
        var response = await _http.GetAsync("/api/tmdb/settings/key");
        await EnsureSuccessOrThrowAsync(response);
        return await response.Content.ReadFromJsonAsync<TmdbApiKeyResponse>(JsonOptions)
            ?? new TmdbApiKeyResponse();
    }

    public async Task SetTmdbApiKeyAsync(string key)
    {
        var response = await _http.PutAsJsonAsync("/api/tmdb/settings/key", new { key });
        await EnsureSuccessOrThrowAsync(response);
    }

    public async Task<List<ThemeDto>> GetThemesAsync()
    {
        var response = await _http.GetAsync("/api/themes");
        await EnsureSuccessOrThrowAsync(response);
        return await response.Content.ReadFromJsonAsync<List<ThemeDto>>(JsonOptions) ?? [];
    }

    public async Task<ThemeDto?> GetThemeAsync(int id)
    {
        var response = await _http.GetAsync($"/api/themes/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        await EnsureSuccessOrThrowAsync(response);
        return await response.Content.ReadFromJsonAsync<ThemeDto>(JsonOptions);
    }

    public async Task<ThemeDto?> CreateThemeAsync(ThemeDto dto)
    {
        var response = await _http.PostAsJsonAsync("/api/themes", dto);
        await EnsureSuccessOrThrowAsync(response);
        return await response.Content.ReadFromJsonAsync<ThemeDto>(JsonOptions);
    }

    public async Task UpdateThemeAsync(int id, ThemeDto dto)
    {
        var response = await _http.PutAsJsonAsync($"/api/themes/{id}", dto);
        await EnsureSuccessOrThrowAsync(response);
    }

    public async Task DeleteThemeAsync(int id)
    {
        var response = await _http.DeleteAsync($"/api/themes/{id}");
        await EnsureSuccessOrThrowAsync(response);
    }

    private static async Task EnsureSuccessOrThrowAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(
                $"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase}). Body: {body}");
        }
    }
}

public class TmdbApiKeyResponse
{
    public string? Key { get; set; }
    public bool HasKey { get; set; }
}
