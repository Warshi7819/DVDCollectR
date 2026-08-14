using System.Text.Json;
using DVDCollectRShared.APIClient;
using DVDCollectRShared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DVDCollectRWeb.Pages.Settings;

public class ThemesModel : PageModel
{
    private const string ThemeCookieName = "DVDCollectRTheme";

    private readonly DvdApiClient _api;

    public ThemesModel(DvdApiClient api)
    {
        _api = api;
    }

    public List<ThemeDto> Themes { get; set; } = [];
    public int? ActiveThemeId { get; set; }
    public ThemeDto? EditTheme { get; set; }
    public bool IsEditing => Request.Query.ContainsKey("edit");
    public bool IsCopying => Request.Query.ContainsKey("copy");

    public async Task OnGetAsync()
    {
        ActiveThemeId = GetActiveThemeId();
        await LoadThemes();

        if (IsEditing)
        {
            var sourceId = int.Parse(Request.Query["edit"]!);
            EditTheme = await _api.GetThemeAsync(sourceId);
        }
        else if (IsCopying)
        {
            var sourceId = int.Parse(Request.Query["copy"]!);
            EditTheme = await _api.GetThemeAsync(sourceId);
        }
    }

    public async Task<IActionResult> OnPostSelectAsync(int id)
    {
        var theme = await _api.GetThemeAsync(id);
        if (theme is null)
        {
            return RedirectToPage();
        }

        SetThemeCookie(theme);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCreateAsync(ThemeDto dto)
    {
        var created = await _api.CreateThemeAsync(dto);
        if (created is not null)
        {
            SetThemeCookie(created);
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateAsync(int id, ThemeDto dto)
    {
        await _api.UpdateThemeAsync(id, dto);

        if (GetActiveThemeId() == id)
        {
            var updated = await _api.GetThemeAsync(id);
            if (updated is not null)
            {
                SetThemeCookie(updated);
            }
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _api.DeleteThemeAsync(id);

        if (GetActiveThemeId() == id)
        {
            Response.Cookies.Delete(ThemeCookieName);
        }

        return RedirectToPage();
    }

    private int? GetActiveThemeId()
    {
        var cookie = Request.Cookies[ThemeCookieName];
        if (string.IsNullOrEmpty(cookie))
        {
            return null;
        }

        if (cookie == "light")
        {
            return 1;
        }

        if (cookie == "dark")
        {
            return 2;
        }
        if (cookie.StartsWith('{'))
        {
            try { return JsonSerializer.Deserialize<JsonElement>(cookie).GetProperty("Id").GetInt32(); }
            catch { return null; }
        }
        return null;
    }

    private void SetThemeCookie(ThemeDto theme)
    {
        string cookieValue;
        if (theme.IsBuiltIn)
        {
            cookieValue = theme.Name.ToLowerInvariant();
        }
        else
        {
            cookieValue = JsonSerializer.Serialize(new
            {
                Id = theme.Id,
                theme.BodyBg, theme.BodyColor, theme.CardBg, theme.CardBorderColor,
                theme.PrimaryColor, theme.NavbarBg, theme.NavbarTextColor,
                theme.FooterBg, theme.MutedColor
            });
        }

        Response.Cookies.Append(ThemeCookieName, cookieValue, new CookieOptions
        {
            MaxAge = TimeSpan.FromDays(365),
            IsEssential = true,
            SameSite = SameSiteMode.Lax
        });
    }

    private async Task LoadThemes()
    {
        Themes = await _api.GetThemesAsync();
    }
}