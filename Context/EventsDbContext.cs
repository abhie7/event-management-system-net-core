using System;
using System.Collections.Generic;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Context;

public partial class EventsDbContext : DbContext
{
    public EventsDbContext()
    {
    }

    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<eventstable> eventstables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Database=EventManagementSystem;Username=postgres;Password=root;Host=localhost;Port=5432;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<eventstable>(entity =>
        {
            entity.HasKey(e => e.event_id).HasName("events_pkey");

            entity.Property(e => e.event_id).HasDefaultValueSql("nextval('events_event_id_seq'::regclass)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
