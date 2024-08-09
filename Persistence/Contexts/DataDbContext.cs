using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AboutMe configuration
            modelBuilder.Entity<AboutMe>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ImageUrl1).HasMaxLength(255);
                entity.Property(e => e.ImageUrl2).HasMaxLength(255);
            });

            // BlogPost configuration
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.BlogPosts)
                      .HasForeignKey(e => e.UserID);
            });

            // Comment configuration
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasOne(e => e.BlogPost)
                      .WithMany(b => b.Comments)
                      .HasForeignKey(e => e.BlogPostID);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(e => e.UserID);
            });

            // ContactMessage configuration
            modelBuilder.Entity<ContactMessage>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Subject).HasMaxLength(100);
            });

            // Education configuration
            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Degree).HasMaxLength(50);
                entity.Property(e => e.School).HasMaxLength(100);
                entity.HasOne(e => e.User);
            });

            // Experience configuration
            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Company).HasMaxLength(100);
                entity.HasOne(e => e.User);
            });

            // PersonalInfo configuration
            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.About).HasMaxLength(300);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            // Project configuration
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Projects)
                      .HasForeignKey(e => e.UserID);
            });

            // Service configuration
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

        }
    }
}
