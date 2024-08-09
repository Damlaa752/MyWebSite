using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;
using Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Domain.IdentityEntities; // Ensure this namespace is correct

namespace Persistence.Contexts
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.ID);
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(u => u.Role)
                    .HasMaxLength(50);
                entity.Property(u => u.Email)
                    .IsRequired();
            });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => ur.ID);
                entity.Property(ur => ur.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasOne(ur => ur.User)
                    .WithMany(ur => ur.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(ut => ut.ID);
                entity.Property(ut => ut.Token)
                    .IsRequired();
                entity.Property(ut => ut.Expiration)
                    .IsRequired();
                entity.HasOne(ut => ut.User)
                    .WithMany(ut => ut.UserTokens)
                    .HasForeignKey(ut => ut.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
