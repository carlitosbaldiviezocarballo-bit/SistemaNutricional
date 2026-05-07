using System;

namespace SistemaDeNutricion.DTO.HistorialPaciente.AgregarHistorialPaciente;

public class AgregarHistorialPacientelInput
{
    public DateTime Fecha { get; set; }
    public decimal Peso { get; set; }
    public decimal Talla { get; set; }
    public int IdPaciente { get; set; }
}