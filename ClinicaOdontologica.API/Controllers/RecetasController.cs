using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class RecetasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public RecetasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Receta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Receta>>> GetReceta()
    {
        return await _context.Receta.ToListAsync();
    }

    // GET: api/Receta/5
    [HttpGet("{idrecetas}")]
    public async Task<ActionResult<Receta>> GetReceta(int idrecetas)
    {
        var receta = await _context.Receta.FindAsync(idrecetas);

        if (receta == null)
        {
            return NotFound();
        }

        return receta;
    }

    // PUT: api/Receta/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idrecetas}")]
    public async Task<IActionResult> PutReceta(int? idrecetas, Receta receta)
    {
        if (idrecetas != receta.idRecetas)
        {
            return BadRequest();
        }

        _context.Entry(receta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RecetaExists(idrecetas))
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

    // POST: api/Receta
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Receta>> PostReceta(Receta receta)
    {
        _context.Receta.Add(receta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReceta", new { idrecetas = receta.idRecetas }, receta);
    }

    // DELETE: api/Receta/5
    [HttpDelete("{idrecetas}")]
    public async Task<IActionResult> DeleteReceta(int? idrecetas)
    {
        var receta = await _context.Receta.FindAsync(idrecetas);
        if (receta == null)
        {
            return NotFound();
        }

        _context.Receta.Remove(receta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RecetaExists(int? idrecetas)
    {
        return _context.Receta.Any(e => e.idRecetas == idrecetas);
    }
}
