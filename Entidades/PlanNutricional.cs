using System;

namespace SistemaDeNutricion.Entidades;

public class PlanNutricional
{
    public int Id { get; set; }
    public bool Estado { get; set; } = true;
    public required string Nombre { get; set; }
    public int IdDiagnostico { get; set; }
    public required Diagnostico Diagnostico { get; set; }
    public List<DiaPlan> Dias { get; set; } = new();
}