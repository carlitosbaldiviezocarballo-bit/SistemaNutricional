using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Data;
using SistemaDeNutricion.DTO.Diagnostico.AgregarDiagnostico;
using SistemaDeNutricion.Entidades;

namespace SistemaDeNutricion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DiagnosticoController (AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnostico>>> GetDiagnosticos()
        {
            return await _context.Diagnosticos.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Diagnostico>> GetPorId(int Id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(Id);

        if (diagnostico == null)
            return NotFound();
        return Ok(diagnostico);
        }
       [HttpPost]
public async Task<ActionResult<AgregarDiagnosticooutput>> PostDiagnostico([FromBody] AgregarDiagnosticoInput input)
{
   
    var consulta = await _context.Consultas.FindAsync(input.IdConsulta);
    if (consulta == null)
        return BadRequest("La consulta no existe");

    var existe = await _context.Diagnosticos
        .AnyAsync(d => d.IdConsulta == input.IdConsulta);

    if (existe)
        return BadRequest("Esta consulta ya tiene un diagnóstico registrado.");

    var diagnostico = new Diagnostico
    {
        Descripcion = input.Descripcion,
        Recomendacion = input.Recomendacion,
        IdConsulta = input.IdConsulta,
        Consulta = consulta
    };

    _context.Diagnosticos.Add(diagnostico);
    await _context.SaveChangesAsync();

    var output = new AgregarDiagnosticooutput
    {
        Id = diagnostico.Id,
        Descripcion = diagnostico.Descripcion,
        Recomendacion = diagnostico.Recomendacion,
        IdConsulta = diagnostico.IdConsulta
    };

    return CreatedAtAction(nameof(GetPorId), new { id = diagnostico.Id }, output);
}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnostico(int id, [FromBody]Diagnostico diagnostico)
        {
        if (id != diagnostico.Id)
            return BadRequest("Id no coincide");

        _context.Entry(diagnostico).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Diagnosticos.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
        }
    }
}
