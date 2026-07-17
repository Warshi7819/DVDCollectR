using DVDCollectRShared.APIClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DVDCollectRWeb.Pages;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly DvdApiClient _api;
    private readonly IWebHostEnvironment _env;

    public DetailsModel(DvdApiClient api, IWebHostEnvironment env)
    {
        _api = api;
        _env = env;
    }

    public DvdResponse Dvd { get; set; } = null!;

    public string FrontCoverPath => $"/images/DVDs/{Dvd.ProfileId}f.jpg";
    public string BackCoverPath => $"/images/DVDs/{Dvd.ProfileId}b.jpg";
    public bool HasFrontCover { get; private set; }
    public bool HasBackCover { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var dvd = await _api.GetByIdAsync(id);
        if (dvd is null)
        {
            return NotFound();
        }

        Dvd = dvd;

        if (!string.IsNullOrEmpty(Dvd.ProfileId))
        {
            var frontPath = Path.Combine(_env.WebRootPath, "images", "DVDs", $"{Dvd.ProfileId}f.jpg");
            var backPath = Path.Combine(_env.WebRootPath, "images", "DVDs", $"{Dvd.ProfileId}b.jpg");
            HasFrontCover = System.IO.File.Exists(frontPath);
            HasBackCover = System.IO.File.Exists(backPath);
        }

        return Page();
    }
}
