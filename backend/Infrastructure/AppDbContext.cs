using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<MediaItem> MediaItems { get; set; } = default!;
        public DbSet<Rating> Ratings { get; set; } = default!;
        public DbSet<Season> Seasons { get; set; } = default!;
        public DbSet<UserFavorite> UserFavorites { get; set; } = default!;
        public DbSet<UserWatchHistory> UserWatchHistories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // parent -> child  relationship
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Privilege)
                .HasConversion<string>();

            //modelBuilder.Entity<Episode>()


            modelBuilder.Entity<MediaItem>()
                .Property(m => m.Type)
                .HasConversion<string>();

            modelBuilder.Entity<MediaItem>()
                .HasMany(m => m.Seasons)
                .WithOne(s => s.MediaItem)
                .HasForeignKey(s => s.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MediaItem>()
                .HasMany(m => m.Ratings)
                .WithOne(r => r.MediaItem)
                .HasForeignKey(r => r.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.ApplicationUser)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Episodes)
                .WithOne(e => e.Season)
                .HasForeignKey(e => e.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavorite>()
                .HasKey(uf => new { uf.UserId, uf.MediaItemId });

            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.MediaItem)
                .WithMany()
                .HasForeignKey(uf => uf.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWatchHistory>()
                .HasOne(wh => wh.MediaItem)
                .WithMany()
                .HasForeignKey(wh => wh.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWatchHistory>()
                .HasOne(wh => wh.Episode)
                .WithMany()
                .HasForeignKey(wh => wh.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWatchHistory>()
                 .HasOne(wh => wh.User)
                .WithMany(u => u.WatchHistory)
                .HasForeignKey(wh => wh.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWatchHistory>()
                .ToTable(t =>
                t.HasCheckConstraint("CK_UserWatchHistory_MediaOrEpisode",
                "(\"MediaItemId\" IS NOT NULL AND \"EpisodeId\" IS NULL) " +
                "OR (\"MediaItemId\" IS NULL AND \"EpisodeId\" IS NOT NULL)"));

            modelBuilder.Entity<UserWatchHistory>()
                .HasIndex(wh => new { wh.UserId, wh.MediaItemId })
                .IsUnique()
                .HasFilter("\"MediaItemId\" IS NOT NULL");

            modelBuilder.Entity<UserWatchHistory>()
                .HasIndex(wh => new { wh.UserId, wh.EpisodeId })
                .IsUnique()
                .HasFilter("\"EpisodeId\" IS NOT NULL");

        }
    }
}
