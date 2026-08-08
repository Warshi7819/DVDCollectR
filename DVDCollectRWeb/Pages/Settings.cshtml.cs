using System.Text.Json;
using DVDCollectRShared.APIClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DVDCollectRWeb.Pages;

public class SettingsModel : PageModel
{
    private readonly DvdApiClient _api;
    private readonly ILogger<SettingsModel> _logger;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public SettingsModel(DvdApiClient api, ILogger<SettingsModel> logger)
    {
        _api = api;
        _logger = logger;
    }

    [BindProperty]
    public string? ApiKey { get; set; }

    public TmdbSyncStatus SyncStatus { get; set; } = new();

    public string? ErrorMessage { get; set; }

    public async Task OnGetAsync()
    {
        try
        {
            var keyInfo = await _api.GetTmdbApiKeyAsync();
            ApiKey = keyInfo.Key;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to fetch TMDB API key");
            ErrorMessage = $"Failed to load API key: {ex.Message}";
        }

        try
        {
            SyncStatus = await _api.GetTmdbSyncStatusAsync();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to fetch sync status");
            if (ErrorMessage == null)
                ErrorMessage = $"Failed to load sync status: {ex.Message}";
        }
    }

    public async Task<IActionResult> OnPostSaveKeyAsync()
    {
        try
        {
            await _api.SetTmdbApiKeyAsync(ApiKey ?? string.Empty);
            TempData["Saved"] = "API key saved.";
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to save TMDB API key");
            ErrorMessage = $"Failed to save API key: {ex.Message}";
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostStartSyncAsync()
    {
        try
        {
            var status = await _api.StartTmdbSyncAsync();
            return new JsonResult(status, JsonOptions);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to start TMDB sync");
            return new JsonResult(new TmdbSyncStatus { Status = "Error" }, JsonOptions)
            {
                StatusCode = 500
            };
        }
    }

    public async Task<IActionResult> OnGetSyncStatusAsync()
    {
        try
        {
            var status = await _api.GetTmdbSyncStatusAsync();
            return new JsonResult(status, JsonOptions);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to get sync status");
            return new JsonResult(new TmdbSyncStatus { Status = "Error" }, JsonOptions)
            {
                StatusCode = 500
            };
        }
    }
}
