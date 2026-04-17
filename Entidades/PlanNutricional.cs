using System;

namespace SistemaDeNutricion.Entidades;

public class PlanNutricional
    {
        public int Id { get; set; }
        public bool Estado { get; set; } = true;
        public required string Nombre { get; set; } 
        public required string Desayuno { get; set; }
        public required string Almuerzo { get; set; }
        public required string Cena { get; set; }
        public string? Meriendas { get; set; }
        public int IdConsulta { get; set; }
        public required Consulta Consulta { get; set; }
    }