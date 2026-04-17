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
        public DbSet<Recordatorio> Recordatorios { get; set; }
        public DbSet<Diagnostico> Diagnosticos {get; set; }
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
                .HasMaxLength(20);
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
                .HasOne(x => x.Consulta)
                .WithMany()
                .HasForeignKey(x => x.IdConsulta)
                .OnDelete(DeleteBehavior.Cascade);
 
            modelBuilder.Entity<Recordatorio>()
                .ToTable("Recordatorios");
            modelBuilder.Entity<Recordatorio>()
                .HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recordatorio>()
                .Property(x => x.Mensaje)
                .HasMaxLength(200);
           modelBuilder.Entity<Diagnostico>()
              .HasOne(d => d.Consulta)
              .WithMany()
              .HasForeignKey(d => d.IdConsulta);
        }
}
