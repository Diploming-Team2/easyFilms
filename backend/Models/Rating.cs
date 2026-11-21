namespace backend.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Score {  get; set; }

        public Guid MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; } = null!;

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
