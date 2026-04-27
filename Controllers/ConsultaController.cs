using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Data;
using SistemaDeNutricion.DTO.Consulta.AgregarConsulta;
using SistemaDeNutricion.Entidades;

namespace SistemaDeNutricion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
         private readonly AppDbContext _context;

    public ConsultaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultas()
    {
        return await _context.Consultas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Consulta>> GetConsulta(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id);

        if (consulta == null)
            return NotFound();

        return consulta;
    }

    [HttpPost]
public async Task<ActionResult<AgregarConsultaOutput>> PostConsulta([FromBody] AgregarConsultaInput input)
{
    var paciente = await _context.Pacientes.FindAsync(input.IdPaciente);
    if (paciente == null)
        return BadRequest("El paciente no existe");

    var pacienterep = await _context.Consultas
        .AnyAsync(c => c.IdPaciente == input.IdPaciente 
                    && c.Fecha.Date == input.Fecha.Date);

    if (pacienterep)
        return BadRequest("El paciente ya tiene una consulta registrada para este día.");

    var consulta = new Consulta
    {
        Fecha = input.Fecha, 
        Motivo = input.Motivo,
        Estado = input.Estado ?? "Programada",
        IdPaciente = input.IdPaciente,
        Paciente = paciente
    };

    _context.Consultas.Add(consulta);
    await _context.SaveChangesAsync();

    var output = new AgregarConsultaOutput
    {
        Id = consulta.Id,
        Fecha = consulta.Fecha,
        Motivo = consulta.Motivo,
        Estado = consulta.Estado,
        IdPaciente = consulta.IdPaciente
    };

    return CreatedAtAction(nameof(GetConsulta), new { id = consulta.Id }, output);
}

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsulta(int id, Consulta consulta)
    {
        if (id != consulta.Id)
            return BadRequest();

        var pacienteExiste = await _context.Pacientes
            .AnyAsync(p => p.Id == consulta.IdPaciente);

        if (!pacienteExiste)
            return BadRequest("El paciente no existe");

        _context.Entry(consulta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Consultas.Any(e => e.Id== id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsulta(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id);

        if (consulta == null)
            return NotFound();

        _context.Consultas.Remove(consulta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
  }
}

