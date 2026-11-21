namespace backend.Models
{
    public class Season
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int SeasonNumber { get; set; }
        public int? EpisodeCount { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        //public DateTime AddedDate { get; set; } = DateTime.UtcNow; //maybe remove, its only useful for "New Season Just Added" badge

        public Guid MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; } = null!;

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
