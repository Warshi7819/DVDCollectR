using DVDCollectRShared.APIClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DVDCollectRWeb.Pages;

public class CollectionModel : PageModel
{
    private readonly DvdApiClient _api;

    public CollectionModel(DvdApiClient api)
    {
        _api = api;
    }

    [BindProperty(SupportsGet = true, Name = "p")]
    public int CurrentPage { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public string? SearchTitle { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchActor { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchGenre { get; set; }

    public int PageSize { get; set; } = 10;
    public PagedResult<DvdResponse>? Result { get; set; }
    public List<string> Genres { get; set; } = [];

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => Result != null && CurrentPage < Result.TotalPages;

    public async Task OnGetAsync()
    {
        Genres = await _api.GetGenresAsync();
        Result = await _api.GetAllAsync(
            title: SearchTitle,
            actor: SearchActor,
            genre: SearchGenre,
            page: CurrentPage,
            pageSize: PageSize);
    }
}
