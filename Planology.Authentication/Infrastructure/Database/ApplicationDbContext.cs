using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PermissionResourceType> PermissionResourceTypes { get; set; }
        public DbSet<AccessControlEntry> AccessControlEntries { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MyDatabase;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
                entity.Property(u => u.MobileNumber).IsRequired().HasMaxLength(20);
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.HasMany(u => u.AccessControlEntries)
                      .WithOne(ace => ace.User)
                      .HasForeignKey(ace => ace.UserId);
                entity.HasMany(u => u.RefreshTokens)
                      .WithOne(rt => rt.User)
                      .HasForeignKey(rt => rt.UserId);
                entity.Property(e => e.CreateDate).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdateDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<UserEntity>()
                .OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Value)
                         .HasColumnName("Email")
                         .IsRequired();
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
