using System;

namespace SistemaDeNutricion.DTO.HistorialPaciente.AgregarHistorialPaciente;

public class AgregarHistorialPacienteOutput
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Peso { get; set; }
    public decimal Talla { get; set; }
    public decimal IMC { get; set; }
    public int IdPaciente { get; set; }
}