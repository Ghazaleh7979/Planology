using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<PermissionResourceType> PermissionResourceTypes { get; set; }
        public DbSet<AccessControlEntry> AccessControlEntries { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Planology;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.Role)
                      .HasConversion<string>();

                entity.HasMany(u => u.AccessControlEntries)
                      .WithOne()
                      .HasForeignKey(ace => ace.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.RefreshTokens)
                      .WithOne()
                      .HasForeignKey(rt => rt.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PermissionResourceType>(entity =>
            {
                entity.HasKey(prt => prt.Id);
                entity.Property(prt => prt.Name).IsRequired().HasMaxLength(100);
                entity.HasMany(prt => prt.AccessControlEntries)
                      .WithOne(ace => ace.PermissionResourceType)
                      .HasForeignKey(ace => ace.PermissionResourceTypeId);
                entity.Property(e => e.CreateDate).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdateDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<AccessControlEntry>(entity =>
            {
                entity.HasKey(ace => ace.Id);
                entity.Property(ace => ace.Permission).IsRequired();
                entity.Property(e => e.CreateDate).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdateDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(rt => rt.Id);
                entity.Property(rt => rt.Token).IsRequired();
                entity.Property(rt => rt.ExpiryDate).IsRequired();
                entity.Property(e => e.CreateDate).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdateDate).ValueGeneratedOnUpdate();
            });
        }
    }

}
