using System;

namespace SistemaDeNutricion.DTO.Diagnostico.AgregarDiagnostico;

public class AgregarDiagnosticoInput
{
    public string Recomendacion {get; set;} = string.Empty;
    public string Descripcion{get;set;} = string.Empty;
    public int IdConsulta {get; set;}
}
