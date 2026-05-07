using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SistemaDeNutricion.Data;
using SistemaDeNutricion.DTO.PlanNutricional.AgregarPlanNutricional;
using SistemaDeNutricion.Entidades;

namespace SistemaDeNutricion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanNutricionalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanNutricionalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgregarPlanNutricionalOutput>>> GetPlanes()
        {
            var planes = await _context.PlanesNutricionales
                .Include(x => x.Dias)
                .ToListAsync();

            var output = planes.Select(plan => new AgregarPlanNutricionalOutput
            {
                Id = plan.Id,
                Estado = plan.Estado,
                Nombre = plan.Nombre,
                IdDiagnostico = plan.IdDiagnostico,
                Dias = plan.Dias.Select(d => new DiaPlanOutput
                {
                    Id = d.Id,
                    DiaSemana = d.DiaSemana,
                    Desayuno = d.Desayuno,
                    Almuerzo = d.Almuerzo,
                    Cena = d.Cena,
                    Meriendas = d.Meriendas
                }).ToList()
            });

            return Ok(output);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgregarPlanNutricionalOutput>> GetPlan(int id)
        {
            var plan = await _context.PlanesNutricionales
                .Include(x => x.Dias)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (plan == null)
                return NotFound();

            var output = new AgregarPlanNutricionalOutput
            {
                Id = plan.Id,
                Estado = plan.Estado,
                Nombre = plan.Nombre,
                IdDiagnostico = plan.IdDiagnostico,
                Dias = plan.Dias.Select(d => new DiaPlanOutput
                {
                    Id = d.Id,
                    DiaSemana = d.DiaSemana,
                    Desayuno = d.Desayuno,
                    Almuerzo = d.Almuerzo,
                    Cena = d.Cena,
                    Meriendas = d.Meriendas
                }).ToList()
            };

            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<AgregarPlanNutricionalOutput>> PostPlan([FromBody] AgregarPlanNutricionalInput input)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(input.IdDiagnostico);
            if (diagnostico == null)
                return BadRequest("La consulta especificada no existe.");

            var plan = new PlanNutricional
            {
                Nombre = input.Nombre,
                IdDiagnostico = input.IdDiagnostico,
                Diagnostico = diagnostico,
                Dias = input.Dias.Select(d => new DiaPlan
                {
                    DiaSemana = d.DiaSemana,
                    Desayuno = d.Desayuno,
                    Almuerzo = d.Almuerzo,
                    Cena = d.Cena,
                    Meriendas = d.Meriendas,
                    PlanNutricional = null!
                }).ToList()
            };

            _context.PlanesNutricionales.Add(plan);
            await _context.SaveChangesAsync();

            var output = new AgregarPlanNutricionalOutput
            {
                Id = plan.Id,
                Estado = plan.Estado,
                Nombre = plan.Nombre,
                IdDiagnostico = plan.IdDiagnostico,
                Dias = plan.Dias.Select(d => new DiaPlanOutput
                {
                    Id = d.Id,
                    DiaSemana = d.DiaSemana,
                    Desayuno = d.Desayuno,
                    Almuerzo = d.Almuerzo,
                    Cena = d.Cena,
                    Meriendas = d.Meriendas
                }).ToList()
            };

            return CreatedAtAction(nameof(GetPlan), new { id = plan.Id }, output);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, [FromBody] AgregarPlanNutricionalInput input)
        {
            var plan = await _context.PlanesNutricionales
                .Include(x => x.Dias)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (plan == null)
                return NotFound();

            plan.Nombre = input.Nombre;
            plan.IdDiagnostico = input.IdDiagnostico;

            _context.DiasPlan.RemoveRange(plan.Dias);
            plan.Dias = input.Dias.Select(d => new DiaPlan
            {
                DiaSemana = d.DiaSemana,
                Desayuno = d.Desayuno,
                Almuerzo = d.Almuerzo,
                Cena = d.Cena,
                Meriendas = d.Meriendas,
                PlanNutricional = null!
            }).ToList();

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
