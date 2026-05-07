using System;

namespace SistemaDeNutricion.DTO.Diagnostico.AgregarDiagnostico;

public class AgregarDiagnosticooutput
{
    public int Id {get; set;}
    public string Recomendacion {get; set;} = string.Empty;
    public string Descripcion{get;set;} = string.Empty;
    public int IdConsulta {get; set;}
}
