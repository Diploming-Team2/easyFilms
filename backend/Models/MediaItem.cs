namespace backend.Models
{
    public class MediaItem
    {
        public enum MediaType
        {
            Movie,
            Trailer,
            Series,
            Interview,
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DurationInSeconds { get; set; }
        public MediaType Type { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public string? HlsPlaylistUrl { get; set; }

        public ICollection<Season> Seasons { get; set; } = new List<Season>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
