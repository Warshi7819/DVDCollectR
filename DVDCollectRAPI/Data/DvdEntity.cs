using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDCollectRAPI.Data;

[Table("DVDs")]
public class DvdEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string ProfileId { get; set; } = string.Empty;

    [Required]
    public string Title { get; set; } = string.Empty;

    public string? OriginalTitle { get; set; }
    public string? SortTitle { get; set; }
    public int? ProductionYear { get; set; }
    public string? Released { get; set; }
    public int? RunningTime { get; set; }
    public string? Rating { get; set; }
    public string? RatingSystem { get; set; }
    public int? RatingAge { get; set; }
    public string? RatingDetails { get; set; }
    public string? CountryOfOrigin { get; set; }
    public string? UPC { get; set; }
    public int? CollectionNumber { get; set; }
    public string? CaseType { get; set; }
    public string? Overview { get; set; }
    public string? MediaTypes { get; set; }
    public string? Regions { get; set; }
    public string? Studios { get; set; }
    public string? Director { get; set; }
    public string? Actors { get; set; }
    public string? AudioTracks { get; set; }
    public string? Subtitles { get; set; }
    public int? DiscCount { get; set; }
    public string? PurchaseDate { get; set; }
    public decimal? PurchasePrice { get; set; }
    public string? PurchasePlace { get; set; }
    public int? WishPriority { get; set; }
    public string? LastEdited { get; set; }
    public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("O");
    public string UpdatedAt { get; set; } = DateTime.UtcNow.ToString("O");

    public ICollection<GenreEntity> Genres { get; set; } = [];
    public TmdbEntity? Tmdb { get; set; }
}
