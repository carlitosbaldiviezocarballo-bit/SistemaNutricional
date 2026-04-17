using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeNutricion.Entidades;

public class Paciente
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public required string CI { get; set; }
        public required string Objetivo { get; set; }
        public string? Alergias { get; set; }
        public decimal PesoInicial { get; set; }
        public decimal TallaInicial { get; set; }
    }