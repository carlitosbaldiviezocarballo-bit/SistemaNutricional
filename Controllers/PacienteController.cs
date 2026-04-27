using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Data;
using SistemaDeNutricion.Entidades;
using SistemaDeNutricion.DTO.Paciente;

namespace SistemaDeNutricion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

    public PacienteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
    {
        return await _context.Pacientes.ToListAsync();
    }

     // GET: api/paciente/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Paciente>> GetPaciente(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente == null)
            return NotFound();
        return Ok(paciente);
    }
        // POST: api/paciente
        [HttpPost]
        public async Task<ActionResult<Agregarpacienteoutput>> PostPaciente([FromBody] AgregarPacienteinput input)
        {
            var pac = new Paciente
            {
                Nombre = input.Nombre,
                Apellido = input.Apellido,
                CI = input.CI,
                Objetivo = input.Objetivo,
                Alergias = input.Alergias,
                PesoInicial = input.PesoInicial,
                TallaInicial = input.TallaInicial
            };

            _context.Pacientes.Add(pac);
            await _context.SaveChangesAsync();

            var output = new Agregarpacienteoutput
            {
                Id = pac.Id,
                NombreCompleto = pac.Nombre + " " + pac.Apellido,
                CI = pac.CI,
                Objetivo = pac.Objetivo,
                Alergias = pac.Alergias,
                PesoInicial = pac.PesoInicial,
                TallaInicial = pac.TallaInicial
            };

            return CreatedAtAction(nameof(GetPaciente), new { id = pac.Id }, output);
        }
        // PUT: api/paciente/5
        [HttpPut("{id}")]
    public async Task<IActionResult> PutPaciente(int id, [FromBody]Paciente paciente)
    {
        if (id != paciente.Id)
            return BadRequest("Id no coincide");

        _context.Entry(paciente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Pacientes.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/paciente/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaciente(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente == null)
            return NotFound();

        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
}
