using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFTrainingLibrary.Models;

public partial class EYTrainingDB2Context : DbContext
{
    public EYTrainingDB2Context()
    {
    }

    public EYTrainingDB2Context(DbContextOptions<EYTrainingDB2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<Training> Training { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=EYTrainingDB2; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB9951D46317");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.TechnologyId).HasName("PK__Technolo__7057015883A9EB02");

            entity.ToTable("Technology");

            entity.Property(e => e.TechnologyId).ValueGeneratedNever();
            entity.Property(e => e.TechnologyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TechnologyType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => new { e.TrainingId, e.EmpId }).HasName("PK__Trainee__6225C63BFCF7DD4A");

            entity.ToTable("Trainee");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Emp).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trainee__EmpId__440B1D61");

            entity.HasOne(d => d.Training).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trainee__Trainin__4316F928");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__366A1A7CC0B362AA");

            entity.ToTable("Trainer");

            entity.Property(e => e.TrainerId).ValueGeneratedNever();
            entity.Property(e => e.TrainerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TrainerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TrainerPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TrainerType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.TrainingId).HasName("PK__Training__E8D71D8278A9F5D1");

            entity.Property(e => e.TrainingId).ValueGeneratedNever();

            entity.HasOne(d => d.Technology).WithMany(p => p.Training)
                .HasForeignKey(d => d.TechnologyId)
                .HasConstraintName("FK__Training__Techno__3E52440B");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Training)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Training__Traine__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
