namespace SistemaDeNutricion.Entidades
{
    public class DiaPlan
    {
        public int Id { get; set; }
        public required string DiaSemana { get; set; } // "Lunes", "Martes", etc.
        public required string Desayuno { get; set; }
        public required string Almuerzo { get; set; }
        public required string Cena { get; set; }
        public string? Meriendas { get; set; }
        public int IdPlanNutricional { get; set; }
        public required PlanNutricional PlanNutricional { get; set; }
    }
}
