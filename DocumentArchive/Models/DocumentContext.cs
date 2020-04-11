using System;
using DocumentArchive.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DocumentArchive.Filter;

namespace DocumentArchive.Models
{
    public partial class DocumentContext : DbContext
    {
        public DocumentContext()
        {
        }

        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Document> Document { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NO39NB8\MSSQLSERVER01;Initial Catalog=document;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("AUTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => new { e.DateCreated, e.Name })
                    .HasName("PKDOCUMENT");

                entity.ToTable("DOCUMENT");

                entity.HasIndex(e => e.Name)
                    .HasName("NameUQ")
                    .IsUnique();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category).HasColumnName("CATEGORY");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("CATEGORYFK");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("AUTORFK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
