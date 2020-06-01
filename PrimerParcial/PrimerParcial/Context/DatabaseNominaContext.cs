using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial.Context
{
    public partial class DatabaseNominaContext : DbContext
    {
        public DatabaseNominaContext()
        {
        }

        public DatabaseNominaContext(DbContextOptions<DatabaseNominaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Excluyentes> Excluyentes { get; set; }
        public virtual DbSet<Nomina> Nomina { get; set; }
        public virtual DbSet<Rango1> Rango1 { get; set; }
        public virtual DbSet<Rango2> Rango2 { get; set; }
        public virtual DbSet<Rango3> Rango3 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NCA9IOO\\SQLEXPRESS01;Initial Catalog=DatabaseNomina;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Excluyentes>(entity =>
            {
                entity.ToTable("excluyentes");

                entity.Property(e => e.Afp)
                    .HasColumnName("afp")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ars)
                    .HasColumnName("ars")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Irs)
                    .HasColumnName("IRS")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sip)
                    .HasColumnName("sip")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoBruto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoNeto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalRetencion).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SueldoBruto).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Rango1>(entity =>
            {
                entity.Property(e => e.Afp)
                    .HasColumnName("afp")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ars)
                    .HasColumnName("ars")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Irs)
                    .HasColumnName("IRS")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sip)
                    .HasColumnName("sip")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoBruto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoNeto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalRetencion).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Rango2>(entity =>
            {
                entity.Property(e => e.Afp)
                    .HasColumnName("afp")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ars)
                    .HasColumnName("ars")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Irs)
                    .HasColumnName("IRS")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sip)
                    .HasColumnName("sip")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoBruto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoNeto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalRetencion).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Rango3>(entity =>
            {
                entity.Property(e => e.Afp)
                    .HasColumnName("afp")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ars)
                    .HasColumnName("ars")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Irs)
                    .HasColumnName("IRS")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sip)
                    .HasColumnName("sip")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoBruto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SueldoNeto).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalRetencion).HasColumnType("decimal(8, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
