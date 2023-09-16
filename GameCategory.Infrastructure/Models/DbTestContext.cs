using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GameCategory.Infrastructure.Models;

public partial class DbTestContext : DbContext
{
    public DbTestContext()
    {
    }

    public DbTestContext(DbContextOptions<DbTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("host=localhost; Database=db_test; username=admin; password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("(0)::bit(1)")
                .HasColumnType("bit(1)")
                .HasColumnName("active");
            entity.Property(e => e.DescripcionCategory)
                .HasMaxLength(100)
                .HasColumnName("descripcion_category");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(50)
                .HasColumnName("name_category");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("game_pkey");

            entity.ToTable("game");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("(0)::bit(1)")
                .HasColumnType("bit(1)")
                .HasColumnName("active");
            entity.Property(e => e.Descripcption)
                .HasMaxLength(200)
                .HasColumnName("descripcption");
            entity.Property(e => e.NameGame)
                .HasMaxLength(50)
                .HasColumnName("name_game");
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => e.GameCategoryId).HasName("game_category_pkey");

            entity.ToTable("game_category");

            entity.Property(e => e.GameCategoryId).HasColumnName("game_category_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("(0)::bit(1)")
                .HasColumnType("bit(1)")
                .HasColumnName("active");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");

            entity.HasOne(d => d.Category).WithMany(p => p.GameCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_category_category_id_fkey");

            entity.HasOne(d => d.Game).WithMany(p => p.GameCategories)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_category_game_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
