namespace backend.Models
{
    public class Episode
    {
        public Guid Id { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DurationInSeconds { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string HlsPlaylistUrl { get; set; } = string.Empty;

        public Guid SeasonId { get; set; }
        public Season Season { get; set; } = null!;
    }
}
