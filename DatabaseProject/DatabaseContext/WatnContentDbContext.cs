using System;
using System.Collections.Generic;
using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.DatabaseContext;

public partial class WatnContentDbContext : DbContext
{
    public WatnContentDbContext()
    {
    }

    public WatnContentDbContext(DbContextOptions<WatnContentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<PostContent> PostContents { get; set; }

    public virtual DbSet<PostType> PostTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Author1)
                .HasMaxLength(50)
                .HasColumnName("Author");
        });

        modelBuilder.Entity<PostContent>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.DatePublished).HasColumnType("datetime");
            entity.Property(e => e.ImageSource)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PostTypeId).HasColumnName("PostTypeID");
            entity.Property(e => e.Title).HasMaxLength(200);

            //entity.HasOne(d => d.Author).WithMany(p => p.PostContents)
            //    .HasForeignKey(d => d.AuthorId)
            //    .HasConstraintName("FK_PostContents_Authors");

            //entity.HasOne(d => d.PostType).WithMany(p => p.PostContents)
            //    .HasForeignKey(d => d.PostTypeId)
            //    .HasConstraintName("FK_PostContents_PostType");
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.ToTable("PostType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostType1)
                .HasMaxLength(20)
                .HasColumnName("PostType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
