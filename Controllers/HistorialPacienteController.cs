using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Data;
using SistemaDeNutricion.DTO.HistorialPaciente.AgregarHistorialPaciente;
using SistemaDeNutricion.Entidades;

namespace SistemaDeNutricion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class HistorialPacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialPacienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgregarHistorialPacienteOutput>>> GetHistoriales()
        {
            var historiales = await _context.HistorialesPaciente.ToListAsync();

            var output = historiales.Select(h => new AgregarHistorialPacienteOutput
            {
                Id = h.Id,
                Fecha = h.Fecha,
                Peso = h.Peso,
                Talla = h.Talla,
                IMC = h.IMC,
                IdPaciente = h.IdPaciente
            });

            return Ok(output);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgregarHistorialPacienteOutput>> GetHistorial(int id)
        {
            var historial = await _context.HistorialesPaciente.FindAsync(id);

            if (historial == null)
                return NotFound();

            var output = new AgregarHistorialPacienteOutput
            {
                Id = historial.Id,
                Fecha = historial.Fecha,
                Peso = historial.Peso,
                Talla = historial.Talla,
                IMC = historial.IMC,
                IdPaciente = historial.IdPaciente
            };

            return Ok(output);
        }


        [HttpPost]
        public async Task<ActionResult<AgregarHistorialPacienteOutput>> PostHistorial([FromBody] AgregarHistorialPacientelInput input)
        {
            var paciente = await _context.Pacientes.FindAsync(input.IdPaciente);
            if (paciente == null)
                return BadRequest("El paciente no existe.");

            var imc = input.Peso / (input.Talla * input.Talla);

            var historial = new HistorialPaciente
            {
                Fecha = input.Fecha,
                Peso = input.Peso,
                Talla = input.Talla,
                IMC = Math.Round(imc, 1),
                IdPaciente = input.IdPaciente,
                Paciente = paciente
            };

            _context.HistorialesPaciente.Add(historial);
            await _context.SaveChangesAsync();

            var output = new AgregarHistorialPacienteOutput
            {
                Id = historial.Id,
                Fecha = historial.Fecha,
                Peso = historial.Peso,
                Talla = historial.Talla,
                IMC = historial.IMC,
                IdPaciente = historial.IdPaciente
            };

            return CreatedAtAction(nameof(GetHistorial), new { id = historial.Id }, output);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            var historial = await _context.HistorialesPaciente.FindAsync(id);

            if (historial == null)
                return NotFound();

            _context.HistorialesPaciente.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
