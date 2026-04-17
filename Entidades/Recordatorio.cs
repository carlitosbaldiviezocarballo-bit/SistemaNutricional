using System;

namespace SistemaDeNutricion.Entidades;

public class Recordatorio
    {
        public int Id { get; set; }  
        public DateTime FechaHora { get; set; }      
        public string Mensaje { get; set; } = string.Empty;
        public bool Completado { get; set; } = false;
        public int IdPaciente { get; set; }
        public required Paciente Paciente { get; set; }
    }