namespace backend.Models
{
    public class UserFavorite
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public Guid MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; } = null!;

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
