using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure
{
    public class AppDbContext : IndentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<MediaItem> MediaItems { get; set; } = default!;
        public DbSet<Rating> Ratings { get; set; } = default!;
        public DbSet<Season> Seasons { get; set; } = default!;
        public DbSet<UserFavorite> UserFavorites { get; set; } = default!;
        public DbSet<UserWatchHistory> UserWatchHistories { get; set; } = default!;


    }
}
