using System.Xml.Serialization;
using DVDCollectRAPI.Data;
using DVDCollectRShared.DVDProfiler;
using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Services;

public class XmlImportService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IWebHostEnvironment _env;

    public XmlImportService(IServiceProvider serviceProvider, IWebHostEnvironment env)
    {
        _serviceProvider = serviceProvider;
        _env = env;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DvdDbContext>();

        await db.Database.MigrateAsync(cancellationToken);

        var xmlPath = Path.Combine(_env.ContentRootPath, "Data", "Collection.xml");
        if (!File.Exists(xmlPath))
        {
            return;
        }

        var serializer = new XmlSerializer(typeof(Collection));
        Collection collection;
        using (var stream = File.OpenRead(xmlPath))
        {
            collection = (Collection)serializer.Deserialize(stream)!;
        }

        var existing = await db.DVDs.Include(d => d.Genres).ToDictionaryAsync(d => d.ProfileId, cancellationToken);
        var genreCache = new Dictionary<string, GenreEntity>(StringComparer.OrdinalIgnoreCase);

        foreach (var existingGenre in await db.Genres.ToListAsync(cancellationToken))
        {
            genreCache[existingGenre.Name] = existingGenre;
        }

        foreach (var dvd in collection.DVD)
        {
            var entity = Map(dvd);

            if (existing.TryGetValue(entity.ProfileId, out var existingEntity))
            {
                entity.Id = existingEntity.Id;
                entity.CreatedAt = existingEntity.CreatedAt;
                entity.UpdatedAt = DateTime.UtcNow.ToString("O");
                db.Entry(existingEntity).CurrentValues.SetValues(entity);
                entity = existingEntity;
            }
            else
            {
                entity.CreatedAt = DateTime.UtcNow.ToString("O");
                entity.UpdatedAt = entity.CreatedAt;
                db.DVDs.Add(entity);
            }

            var genres = ResolveGenres(dvd.Genres, genreCache);
            entity.Genres.Clear();
            foreach (var g in genres)
            {
                entity.Genres.Add(g);
            }
        }

        await db.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private static DvdEntity Map(CollectionDVD source)
    {
        var entity = new DvdEntity
        {
            ProfileId = source.ID ?? string.Empty,
            Title = source.Title ?? string.Empty,
            OriginalTitle = string.IsNullOrEmpty(source.OriginalTitle) ? null : source.OriginalTitle,
            SortTitle = string.IsNullOrEmpty(source.SortTitle) ? null : source.SortTitle,
            ProductionYear = source.ProductionYear != 0 ? source.ProductionYear : null,
            Released = source.ReleasedSpecified ? source.Released.ToString("yyyy-MM-dd") : null,
            RunningTime = source.RunningTime != 0 ? source.RunningTime : null,
            Rating = string.IsNullOrEmpty(source.Rating) ? null : source.Rating,
            RatingSystem = string.IsNullOrEmpty(source.RatingSystem) ? null : source.RatingSystem,
            RatingAge = source.RatingAge != 0 ? source.RatingAge : null,
            RatingDetails = string.IsNullOrEmpty(source.RatingDetails) ? null : source.RatingDetails,
            CountryOfOrigin = string.IsNullOrEmpty(source.CountryOfOrigin) ? null : source.CountryOfOrigin,
            UPC = string.IsNullOrEmpty(source.UPC) ? null : source.UPC,
            CollectionNumber = source.CollectionNumber != 0 ? source.CollectionNumber : null,
            CaseType = string.IsNullOrEmpty(source.CaseType) ? null : source.CaseType,
            Overview = string.IsNullOrEmpty(source.Overview) ? null : source.Overview,
            MediaTypes = FormatMediaTypes(source.MediaTypes),
            Regions = source.Regions is { Length: > 0 } ? string.Join(", ", source.Regions) : null,
            Studios = source.Studios is { Length: > 0 } ? string.Join(", ", source.Studios) : null,
            Director = ExtractDirector(source.Credits),
            Actors = FormatActors(source.Actors),
            AudioTracks = FormatAudioTracks(source.Audio),
            Subtitles = source.Subtitles is { Length: > 0 } ? string.Join(", ", source.Subtitles) : null,
            DiscCount = source.Discs?.Length,
                PurchaseDate = source.PurchaseInfo?.PurchaseDate is DateTime pd
                    ? pd.ToString("yyyy-MM-dd")
                    : null,
            PurchasePrice = source.PurchaseInfo?.PurchasePrice?.Value,
            PurchasePlace = source.PurchaseInfo?.PurchasePlace?.ToString(),
            WishPriority = source.WishPriority != 0 ? source.WishPriority : null,
            LastEdited = source.LastEdited != default ? source.LastEdited.ToString("O") : null,
        };

        return entity;
    }

    private static List<GenreEntity> ResolveGenres(string[]? sourceGenres, Dictionary<string, GenreEntity> cache)
    {
        var result = new List<GenreEntity>();
        if (sourceGenres == null)
        {
            return result;
        }

        foreach (var name in sourceGenres)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }
            var trimmed = name.Trim();
            if (!cache.TryGetValue(trimmed, out var genre))
            {
                genre = new GenreEntity { Name = trimmed };
                cache[trimmed] = genre;
            }
            result.Add(genre);
        }

        return result;
    }

    private static string? FormatMediaTypes(CollectionDVDMediaTypes? mt)
    {
        if (mt == null)
        {
            return null;
        }
        var types = new List<string>();
        if (mt.DVD)
        {
            types.Add("DVD");
        }
        if (mt.HDDVD)
        {
            types.Add("HD DVD");
        }
        if (mt.BluRay)
        {
            types.Add("Blu-ray");
        }
        return types.Count > 0 ? string.Join(", ", types) : null;
    }

    private static string? ExtractDirector(CollectionDVDCredits? credits)
    {
        if (credits?.Items == null)
        {
            return null;
        }
        foreach (var item in credits.Items)
        {
            if (item is CollectionDVDCreditsCredit credit &&
                string.Equals(credit.CreditType, "Director", StringComparison.OrdinalIgnoreCase))
            {
                var parts = new[] { credit.FirstName, credit.MiddleName, credit.LastName };
                return string.Join(" ", parts.Where(p => !string.IsNullOrEmpty(p)));
            }
        }
        return null;
    }

    private static string? FormatActors(CollectionDVDActors? actors)
    {
        if (actors?.Items == null)
        {
            return null;
        }
        var list = new List<string>();
        foreach (var item in actors.Items)
        {
            if (item is CollectionDVDActorsActor actor)
            {
                var name = string.Join(" ",
                    new[] { actor.FirstName, actor.MiddleName, actor.LastName }
                    .Where(p => !string.IsNullOrEmpty(p)));

                if (!string.IsNullOrEmpty(actor.Role))
                {
                    list.Add($"{name} ({actor.Role})");
                }
                else
                {
                    list.Add(name);
                }
            }
        }
        return list.Count > 0 ? string.Join(", ", list) : null;
    }

    private static string? FormatAudioTracks(CollectionDVDAudioTrack[]? tracks)
    {
        if (tracks == null || tracks.Length == 0)
        {
            return null;
        }
        var list = new List<string>();
        foreach (var t in tracks)
        {
            var parts = new[] { t.AudioContent, t.AudioFormat, t.AudioChannels };
            var desc = string.Join(" / ", parts.Where(p => !string.IsNullOrEmpty(p)));
            if (!string.IsNullOrEmpty(desc))
            {
                list.Add(desc);
            }
        }
        return list.Count > 0 ? string.Join("; ", list) : null;
    }
}
