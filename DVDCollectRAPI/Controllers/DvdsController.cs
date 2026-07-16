using DVDCollectRAPI.Data;
using DVDCollectRAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DvdsController : ControllerBase
{
    private readonly DvdDbContext _db;

    public DvdsController(DvdDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<DvdResponse>>> GetAll(
        [FromQuery] string? title,
        [FromQuery] string? actor,
        [FromQuery] string? genre,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = _db.DVDs.Include(d => d.Genres).AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(d => EF.Functions.Like(d.Title, $"%{title}%"));

        if (!string.IsNullOrWhiteSpace(actor))
            query = query.Where(d => d.Actors != null && EF.Functions.Like(d.Actors, $"%{actor}%"));

        if (!string.IsNullOrWhiteSpace(genre))
            query = query.Where(d => d.Genres.Any(g => EF.Functions.Like(g.Name, genre)));

        var totalCount = await query.CountAsync();

        var dvds = await query
            .OrderBy(d => d.Title)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<DvdResponse>
        {
            Items = dvds.Select(MapToResponse).ToList(),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DvdResponse>> GetById(int id)
    {
        var dvd = await _db.DVDs.Include(d => d.Genres).FirstOrDefaultAsync(d => d.Id == id);
        if (dvd == null)
            return NotFound();

        return MapToResponse(dvd);
    }

    [HttpPost]
    public async Task<ActionResult<DvdResponse>> Create([FromBody] CreateDvdRequest request)
    {
        var entity = new DvdEntity
        {
            ProfileId = string.IsNullOrWhiteSpace(request.ProfileId)
                ? Guid.NewGuid().ToString()
                : request.ProfileId,
            Title = request.Title,
            OriginalTitle = request.OriginalTitle,
            SortTitle = request.SortTitle,
            ProductionYear = request.ProductionYear,
            Released = request.Released,
            RunningTime = request.RunningTime,
            Rating = request.Rating,
            RatingSystem = request.RatingSystem,
            RatingAge = request.RatingAge,
            RatingDetails = request.RatingDetails,
            CountryOfOrigin = request.CountryOfOrigin,
            UPC = request.UPC,
            CollectionNumber = request.CollectionNumber,
            CaseType = request.CaseType,
            Overview = request.Overview,
            MediaTypes = request.MediaTypes,
            Regions = request.Regions,
            Studios = request.Studios,
            Director = request.Director,
            Actors = request.Actors,
            AudioTracks = request.AudioTracks,
            Subtitles = request.Subtitles,
            DiscCount = request.DiscCount,
            PurchaseDate = request.PurchaseDate,
            PurchasePrice = request.PurchasePrice,
            PurchasePlace = request.PurchasePlace,
            WishPriority = request.WishPriority,
        };

        if (request.Genres is { Count: > 0 })
        {
            var existingGenres = await _db.Genres.ToListAsync();
            foreach (var name in request.Genres)
            {
                if (string.IsNullOrWhiteSpace(name)) continue;
                var trimmed = name.Trim();
                var genre = existingGenres.FirstOrDefault(g =>
                    g.Name.Equals(trimmed, StringComparison.OrdinalIgnoreCase));
                if (genre == null)
                {
                    genre = new GenreEntity { Name = trimmed };
                    _db.Genres.Add(genre);
                    existingGenres.Add(genre);
                }
                entity.Genres.Add(genre);
            }
        }

        _db.DVDs.Add(entity);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MapToResponse(entity));
    }

    private static DvdResponse MapToResponse(DvdEntity entity)
    {
        return new DvdResponse
        {
            Id = entity.Id,
            ProfileId = entity.ProfileId,
            Title = entity.Title,
            OriginalTitle = entity.OriginalTitle,
            SortTitle = entity.SortTitle,
            ProductionYear = entity.ProductionYear,
            Released = entity.Released,
            RunningTime = entity.RunningTime,
            Rating = entity.Rating,
            RatingSystem = entity.RatingSystem,
            RatingAge = entity.RatingAge,
            RatingDetails = entity.RatingDetails,
            CountryOfOrigin = entity.CountryOfOrigin,
            UPC = entity.UPC,
            CollectionNumber = entity.CollectionNumber,
            CaseType = entity.CaseType,
            Overview = entity.Overview,
            MediaTypes = entity.MediaTypes,
            Regions = entity.Regions,
            Studios = entity.Studios,
            Director = entity.Director,
            Actors = entity.Actors,
            AudioTracks = entity.AudioTracks,
            Subtitles = entity.Subtitles,
            DiscCount = entity.DiscCount,
            PurchaseDate = entity.PurchaseDate,
            PurchasePrice = entity.PurchasePrice,
            PurchasePlace = entity.PurchasePlace,
            WishPriority = entity.WishPriority,
            LastEdited = entity.LastEdited,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Genres = entity.Genres.Select(g => g.Name).OrderBy(n => n).ToList(),
        };
    }
}
