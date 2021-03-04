using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AcibademCaseStudy.Entities;

namespace AcibademCaseStudy.Context
{
    public partial class CaseStudayContext : DbContext
    {
        public CaseStudayContext()
        {
        }

        public CaseStudayContext(DbContextOptions<CaseStudayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Hospitals> Hospitals { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SEFADEDE\\SQLEXPRESS01;Database=ACIBADEM;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.Property(e => e.Date_).HasColumnType("datetime");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_Appointments_Hospitals");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointments_Patients");
            });

            modelBuilder.Entity<Hospitals>(entity =>
            {
                entity.HasKey(e => e.HospitalId);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.HospitalName).HasMaxLength(40);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(40);

                entity.Property(e => e.PhoneNo).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
