using System;
namespace SistemaDeNutricion.DTO.Paciente;
public class Agregarpacienteoutput()
	{
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string CI { get; set; } = string.Empty;
        public required string Objetivo { get; set; }
        public string? Alergias { get; set; }
        public decimal PesoInicial { get; set; }
        public decimal TallaInicial { get; set; }
    }
