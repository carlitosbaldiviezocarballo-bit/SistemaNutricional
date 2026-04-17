using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNutricion.Data;
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
        public async Task<ActionResult<Diagnostico>> PostDiagnostico([FromBody] Diagnostico diagnostico)
        {
     var consultaExiste = await _context.Consultas
        .AnyAsync(c => c.Id == diagnostico.IdConsulta);

      if (!consultaExiste)
        return BadRequest("La consulta no existe");

      _context.Diagnosticos.Add(diagnostico);
       await _context.SaveChangesAsync();

       return CreatedAtAction(nameof(GetPorId), new { id = diagnostico.Id }, diagnostico);
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
