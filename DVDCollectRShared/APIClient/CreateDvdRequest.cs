namespace DVDCollectRShared.APIClient;

public class CreateDvdRequest
{
    public string Title { get; set; } = string.Empty;
    public string? ProfileId { get; set; }
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
    public List<string>? Genres { get; set; }
}
