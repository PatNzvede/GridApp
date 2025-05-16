using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GridApp.Models;

public partial class PalkDbContext : DbContext
{
    public PalkDbContext()
    {
    }

    public PalkDbContext(DbContextOptions<PalkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GridDetail> GridDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GridDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestData__3213E83F4F049D01");

            entity.ToTable("GridDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
