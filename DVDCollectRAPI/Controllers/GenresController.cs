using DVDCollectRAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly DvdDbContext _db;

    public GenresController(DvdDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetAll()
    {
        var genres = await _db.Genres
            .Select(g => g.Name)
            .Distinct()
            .OrderBy(n => n)
            .ToListAsync();

        return genres;
    }
}
