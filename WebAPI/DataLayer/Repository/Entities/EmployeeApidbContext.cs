using System;
using System.Collections.Generic;
using EmployeeWebApi.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Repository.Entities;

public partial class EmployeeApidbContext : DbContext
{
    public EmployeeApidbContext()
    {
    }

    public EmployeeApidbContext(DbContextOptions<EmployeeApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeMst> EmployeeMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=EmployeeAPIDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC072AF91FF6");

            entity.ToTable("EmployeeMst");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
