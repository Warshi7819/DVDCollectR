namespace DVDCollectRShared.APIClient;

public class TmdbSyncStatus
{
    public string Status { get; set; } = "Idle";
    public int Total { get; set; }
    public int Completed { get; set; }
    public string? CurrentTitle { get; set; }
}
