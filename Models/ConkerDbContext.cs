using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectConker.Models
{ 
    public partial class ConkerDbContext : IdentityDbContext
    {
        public ConkerDbContext()
        {
        }

        public ConkerDbContext(DbContextOptions<ConkerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Roadmap> Roadmaps { get; set; }
        public virtual DbSet<RoadmapTag> RoadmapTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ConkerDb;User Id=wasiim;Password=$Juice749");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Roadmap>(entity =>
            {
                entity.Property(e => e.RoadmapId).HasColumnName("RoadmapID");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RoadmapTag>(entity =>
            {
                entity.HasKey(e => new { e.RoadmapId, e.TagId })
                    .HasName("PK__RoadmapT__26D2B1FC8F1494C5");

                entity.Property(e => e.RoadmapId).HasColumnName("RoadmapID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Roadmap)
                    .WithMany(p => p.RoadmapTags)
                    .HasForeignKey(d => d.RoadmapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoadmapTa__Roadm__70DDC3D8");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.RoadmapTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoadmapTa__TagID__71D1E811");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TagDesc).HasMaxLength(40);

                entity.Property(e => e.TagName).HasMaxLength(10);
            });
        }
    }
}
