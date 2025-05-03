using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databace
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PermissionResourceType> PermissionResourceTypes { get; set; }
        public DbSet<AccessControlEntry> AccessControlEntries { get; set; }
        public DbSet<JwtSettings> JwtSettings { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccessControlEntry>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessControlEntry>()
                .HasOne(a => a.PermissionResourceType)
                .WithMany()
                .HasForeignKey(a => a.PermissionResourceTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
