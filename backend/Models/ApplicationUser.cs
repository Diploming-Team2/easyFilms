using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public enum UserPrivilege
        {
            User,
            Admin
        }
        public string? ProfilePictureUrl { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        public UserPrivilege Privilege { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<UserFavorite> Favorites { get; set; } = new List<UserFavorite>();
        public ICollection<UserWatchHistory> WatchHistory { get; set; } = new List<UserWatchHistory>();
    }
}
