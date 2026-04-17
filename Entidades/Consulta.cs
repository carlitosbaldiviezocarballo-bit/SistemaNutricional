using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeNutricion.Entidades;

public class Consulta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Motivo { get; set; }
        public string Estado { get; set; } = "Programada";
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; } 
    }