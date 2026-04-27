using System;
namespace SistemaDeNutricion.Entidades;

public class Paciente
    {
        public int Id { get; set; }
        public required string Nombre { get; set; } 
        public required string Apellido { get; set; } 
        public required string CI { get; set; }
        public required string Objetivo { get; set; }
        public string? Alergias { get; set; }
        public decimal PesoInicial { get; set; }
        public decimal TallaInicial { get; set; }
    }