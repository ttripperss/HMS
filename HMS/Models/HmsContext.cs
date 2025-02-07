using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HMS.Models;

public partial class HmsContext : DbContext
{
    public HmsContext()
    {
    }

    public HmsContext(DbContextOptions<HmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V0V2TMP\\SQLEXPRESS;Database=HH;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Purpose).HasMaxLength(255);
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.ToTable("Billing");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BillingDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContactNumbers).HasMaxLength(50);
            entity.Property(e => e.HeaOfDepartment).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Specialization)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate).HasColumnType("date");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdmissionDate).HasColumnType("datetime");
            entity.Property(e => e.DischargeDate).HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProfilePictureId).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CD86105C3");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.ProfilePictureId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
