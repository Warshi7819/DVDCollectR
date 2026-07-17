using System.Net.Http.Json;
using System.Text.Json;

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
}
