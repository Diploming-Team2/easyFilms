namespace backend.Models
{
    public class UserWatchHistory
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public Guid? MediaItemId { get; set; }
        public MediaItem? MediaItem { get; set; } = null!;

        public Guid? EpisodeId { get; set; }
        public Episode? Episode { get; set; }

        public DateTime LastWatchedAt { get; set; } = DateTime.UtcNow;
        public int SecondsWatched { get; set; }
        public bool IsFinished { get; set; }
    }
}
