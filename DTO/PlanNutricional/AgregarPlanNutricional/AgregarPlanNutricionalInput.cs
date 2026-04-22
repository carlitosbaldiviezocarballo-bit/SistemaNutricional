namespace SistemaDeNutricion.DTO.PlanNutricional.AgregarPlanNutricional
{
    public class AgregarPlanNutricionalInput
    {
        public string Nombre { get; set; } = string.Empty;
        public int IdConsulta { get; set; }
        public List<DiaPlanInput> Dias { get; set; } = new();
    }

    public class DiaPlanInput
    {
        public string DiaSemana { get; set; } = string.Empty;
        public string Desayuno { get; set; } = string.Empty;
        public string Almuerzo { get; set; } = string.Empty;
        public string Cena { get; set; } = string.Empty;
        public string? Meriendas { get; set; }
    }
}
