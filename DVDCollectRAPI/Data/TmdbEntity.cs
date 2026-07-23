using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDCollectRAPI.Data;

[Table("Tmdb")]
public class TmdbEntity
{
    [Key]
    public int DvdId { get; set; }

    public string? PosterPath { get; set; }

    public double? VoteAverage { get; set; }

    public int? VoteCount { get; set; }

    public string? Overview { get; set; }

    public DateTime? LastUpdated { get; set; }

    public DvdEntity Dvd { get; set; } = null!;
}
