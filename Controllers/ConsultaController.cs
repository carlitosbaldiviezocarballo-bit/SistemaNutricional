using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Data;
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
    public async Task<ActionResult<Consulta>> PostConsulta(Consulta consulta)
    {
       
        var pacienteExiste = await _context.Pacientes
            .AnyAsync(p => p.Id == consulta.IdPaciente);

        if (!pacienteExiste)
            return BadRequest("El paciente no existe");

        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetConsulta), new { id = consulta.Id }, consulta);
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

