using System;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Entidades;

namespace SistemaDeNutricion.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<PlanNutricional> PlanesNutricionales { get; set; }
        public DbSet<HistorialPaciente> HistorialesPaciente { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<DiaPlan>DiasPlan { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>()
                .ToTable("Pacientes");
            modelBuilder.Entity<Paciente>()
                .Property(x => x.Nombre)
                .HasMaxLength(100);
            modelBuilder.Entity<Paciente>()
                .Property(x => x.Apellido)
                .HasMaxLength(100);
            modelBuilder.Entity<Paciente>()
                .Property(x => x.CI)
                .HasMaxLength(9);
            modelBuilder.Entity<Paciente>()
                .HasIndex(x => x.CI)
                .IsUnique();
            modelBuilder.Entity<Paciente>()
                .Property(x => x.PesoInicial)
                .HasColumnType("decimal(6,2)");
            modelBuilder.Entity<Paciente>()
                .Property(x => x.TallaInicial)
                .HasColumnType("decimal(3,2)");
            modelBuilder.Entity<Consulta>()
                .ToTable("Consultas");
            modelBuilder.Entity<Consulta>()
                .HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HistorialPaciente>()
                .ToTable("HistorialesPacientes");
            modelBuilder.Entity<HistorialPaciente>()
                .HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HistorialPaciente>()
                .Property(x => x.Peso)
                .HasColumnType("decimal(6,2)");
            modelBuilder.Entity<HistorialPaciente>()
                .Property(x => x.Talla)
                .HasColumnType("decimal(3,2)");
            modelBuilder.Entity<HistorialPaciente>()
                .Property(x => x.IMC)
                .HasColumnType("decimal(4,1)");
            modelBuilder.Entity<PlanNutricional>()
                .ToTable("PlanesNutricionales");
            modelBuilder.Entity<PlanNutricional>()
                .HasOne(x => x.Diagnostico)
                .WithMany()
                .HasForeignKey(x => x.IdDiagnostico)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DiaPlan>()
                .ToTable("DiasPlan");
            modelBuilder.Entity<DiaPlan>()
                .HasOne(x => x.PlanNutricional)
                .WithMany(x => x.Dias)
                .HasForeignKey(x => x.IdPlanNutricional)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DiaPlan>()
                .Property(x => x.DiaSemana)
                .HasMaxLength(20);
            modelBuilder.Entity<DiaPlan>()
                .Property(x => x.Desayuno)
                .HasMaxLength(300);
            modelBuilder.Entity<DiaPlan>()
                .Property(x => x.Almuerzo)
                .HasMaxLength(300);
            modelBuilder.Entity<DiaPlan>()
                .Property(x => x.Cena)
                .HasMaxLength(300);
            modelBuilder.Entity<DiaPlan>()
                .Property(x => x.Meriendas)
                .HasMaxLength(300);
            modelBuilder.Entity<Diagnostico>()
              .HasOne(d => d.Consulta)
              .WithMany()
              .HasForeignKey(d => d.IdConsulta);
    }
}
