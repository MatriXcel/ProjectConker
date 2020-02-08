using System;
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

        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<ChatTag> ChatTag { get; set; }
        public virtual DbSet<Roadmap> Roadmap { get; set; }
        public virtual DbSet<RoadmapTag> RoadmapTag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

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

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.ChatId)
                    .HasColumnName("ChatID");
                   // .ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(70);

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<ChatTag>(entity =>
            {
                entity.HasKey(e => new { e.ChatId, e.TagId })
                .HasName("PK_ChatTag");

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatTag)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatTag_Chat");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ChatTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatTag_Tag");
            });

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
                    .WithMany(p => p.RoadmapTag)
                    .HasForeignKey(d => d.RoadmapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoadmapTa__Roadm__70DDC3D8");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.RoadmapTag)
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
