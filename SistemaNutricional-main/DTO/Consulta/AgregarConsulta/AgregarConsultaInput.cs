using System;

namespace SistemaDeNutricion.DTO.Consulta.AgregarConsulta;

public class AgregarConsultaInput
{
    public DateTime Fecha { get; set; }
    public string? Motivo { get; set; }
    public string Estado { get; set; } = "Programada";
    public int IdPaciente { get; set; }
}
