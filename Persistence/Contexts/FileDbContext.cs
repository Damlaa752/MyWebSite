using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.FileEntities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Contexts
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {

        }
        public DbSet<FileEntity> FileEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntity>(entity =>
            {
                entity.HasKey(f => f.ID);
                entity.Property(f => f.ID)
                    .ValueGeneratedOnAdd();  // Otomatik artan olarak ayarlama
                entity.Property(f => f.FileName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(f => f.FilePath)
                    .IsRequired();
                entity.Property(f => f.ContentType)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(f => f.FileSize)
                    .IsRequired();
                entity.Property(f => f.UploadDate)
                    .IsRequired();
                entity.HasOne(f => f.User)
                    .WithMany(u => u.Files)
                    .HasForeignKey(f => f.UserId);
            });
        }
    }
}
