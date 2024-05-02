using System;
using System.Collections.Generic;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Context;

public partial class CategoriesDbContext : DbContext
{
    public CategoriesDbContext()
    {
    }

    public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<event_category> event_categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Database=EventManagementSystem;Username=postgres;Password=root;Host=localhost;Port=5432;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<event_category>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("event_categories_pkey");

            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
