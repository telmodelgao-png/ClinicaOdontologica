using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class DetalleCitasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public DetalleCitasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/DetalleCita
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetalleCita>>> GetDetalleCita()
    {
        return await _context.DetalleCita.ToListAsync();
    }

    // GET: api/DetalleCita/5
    [HttpGet("{iddetalle}")]
    public async Task<ActionResult<DetalleCita>> GetDetalleCita(int iddetalle)
    {
        var detallecita = await _context.DetalleCita.FindAsync(iddetalle);

        if (detallecita == null)
        {
            return NotFound();
        }

        return detallecita;
    }

    // PUT: api/DetalleCita/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{iddetalle}")]
    public async Task<IActionResult> PutDetalleCita(int? iddetalle, DetalleCita detallecita)
    {
        if (iddetalle != detallecita.IdDetalle)
        {
            return BadRequest();
        }

        _context.Entry(detallecita).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DetalleCitaExists(iddetalle))
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

    // POST: api/DetalleCita
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DetalleCita>> PostDetalleCita(DetalleCita detallecita)
    {
        _context.DetalleCita.Add(detallecita);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDetalleCita", new { iddetalle = detallecita.IdDetalle }, detallecita);
    }

    // DELETE: api/DetalleCita/5
    [HttpDelete("{iddetalle}")]
    public async Task<IActionResult> DeleteDetalleCita(int? iddetalle)
    {
        var detallecita = await _context.DetalleCita.FindAsync(iddetalle);
        if (detallecita == null)
        {
            return NotFound();
        }

        _context.DetalleCita.Remove(detallecita);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DetalleCitaExists(int? iddetalle)
    {
        return _context.DetalleCita.Any(e => e.IdDetalle == iddetalle);
    }
}
