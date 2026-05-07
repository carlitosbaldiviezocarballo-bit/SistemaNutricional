namespace SistemaDeNutricion.DTO.PlanNutricional.AgregarPlanNutricional
{
    public class AgregarPlanNutricionalOutput
    {
        public int Id { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdDiagnostico { get; set; }
        public List<DiaPlanOutput> Dias { get; set; } = new();
    }

    public class DiaPlanOutput
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public string Desayuno { get; set; } = string.Empty;
        public string Almuerzo { get; set; } = string.Empty;
        public string Cena { get; set; } = string.Empty;
        public string? Meriendas { get; set; }
    }
}
