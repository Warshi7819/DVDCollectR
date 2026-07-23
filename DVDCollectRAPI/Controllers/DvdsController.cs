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
        var query = _db.DVDs.Include(d => d.Genres).Include(d => d.Tmdb).AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(d => EF.Functions.Like(d.Title, $"%{title}%"));
        }

        if (!string.IsNullOrWhiteSpace(actor))
        {
            query = query.Where(d => d.Actors != null && EF.Functions.Like(d.Actors, $"%{actor}%"));
        }

        if (!string.IsNullOrWhiteSpace(genre))
        {
            query = query.Where(d => d.Genres.Any(g => EF.Functions.Like(g.Name, genre)));
        }

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
        var dvd = await _db.DVDs.Include(d => d.Genres).Include(d => d.Tmdb).FirstOrDefaultAsync(d => d.Id == id);
        if (dvd == null)
        {
            return NotFound();
        }

        return MapToResponse(dvd);
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
            TmdbPosterPath = entity.Tmdb?.PosterPath,
            TmdbVoteAverage = entity.Tmdb?.VoteAverage,
            TmdbVoteCount = entity.Tmdb?.VoteCount,
            TmdbOverview = entity.Tmdb?.Overview,
            TmdbLastUpdated = entity.Tmdb?.LastUpdated,
        };
    }
}
