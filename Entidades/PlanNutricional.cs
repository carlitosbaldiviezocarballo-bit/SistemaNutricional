using System;

namespace SistemaDeNutricion.Entidades;

public class PlanNutricional
{
    public int Id { get; set; }
    public bool Estado { get; set; } = true;
    public required string Nombre { get; set; }
    public int IdConsulta { get; set; }
    public required Consulta Consulta { get; set; }
    public List<DiaPlan> Dias { get; set; } = new();
}