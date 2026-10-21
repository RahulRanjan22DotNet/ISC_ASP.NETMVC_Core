using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ISC_EFCore_DBFirstDemo.Models;

public partial class DbfirstDemoContext : DbContext
{
    public DbfirstDemoContext()
    {
    }

    public DbfirstDemoContext(DbContextOptions<DbfirstDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("cpk_sid");

            entity.ToTable("Course");

            entity.Property(e => e.CourseDuration)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sid");

            entity.ToTable("Student");

            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Sname)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
