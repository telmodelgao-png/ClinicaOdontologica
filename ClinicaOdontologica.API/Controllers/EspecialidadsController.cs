using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class EspecialidadsController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public EspecialidadsController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Especialidad
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidad()
    {
        return await _context.Especialidad.ToListAsync();
    }

    // GET: api/Especialidad/5
    [HttpGet("{idespeciliadad}")]
    public async Task<ActionResult<Especialidad>> GetEspecialidad(int idespeciliadad)
    {
        var especialidad = await _context.Especialidad.FindAsync(idespeciliadad);

        if (especialidad == null)
        {
            return NotFound();
        }

        return especialidad;
    }

    // PUT: api/Especialidad/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idespeciliadad}")]
    public async Task<IActionResult> PutEspecialidad(int? idespeciliadad, Especialidad especialidad)
    {
        if (idespeciliadad != especialidad.idEspeciliadad)
        {
            return BadRequest();
        }

        _context.Entry(especialidad).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EspecialidadExists(idespeciliadad))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Especialidad
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Especialidad>> PostEspecialidad(Especialidad especialidad)
    {
        _context.Especialidad.Add(especialidad);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEspecialidad", new { idespeciliadad = especialidad.idEspeciliadad }, especialidad);
    }

    // DELETE: api/Especialidad/5
    [HttpDelete("{idespeciliadad}")]
    public async Task<IActionResult> DeleteEspecialidad(int? idespeciliadad)
    {
        var especialidad = await _context.Especialidad.FindAsync(idespeciliadad);
        if (especialidad == null)
        {
            return NotFound();
        }

        _context.Especialidad.Remove(especialidad);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EspecialidadExists(int? idespeciliadad)
    {
        return _context.Especialidad.Any(e => e.idEspeciliadad == idespeciliadad);
    }
}
