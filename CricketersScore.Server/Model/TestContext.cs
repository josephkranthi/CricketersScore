using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CricketersScore.Server.Model;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cricketer> Cricketers { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cricketer>(entity =>
        {
            entity.HasKey(e => e.Rank).HasName("PK__Crickete__CAA8FCA09ED3663F");

            entity.Property(e => e.Rank)
                .ValueGeneratedNever()
                .HasColumnName("rank");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Score).HasColumnName("score");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
