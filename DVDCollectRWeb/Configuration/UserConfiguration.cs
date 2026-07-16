namespace DVDCollectRWeb.Configuration
{
    public class UserConfiguration
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool UseSHA256 { get; set; } = false;
    }
}
