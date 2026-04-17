using System;
using System.ComponentModel.DataAnnotations;
namespace SistemaDeNutricion.Entidades;

public class Diagnostico
{

    public int Id {get; set;}
    public string Recomendacion {get; set;} = string.Empty;
    public string Descripcion{get;set;} = string.Empty;
    public int IdConsulta {get; set;}
    public Consulta? Consulta {get; set;}

}
    
    
