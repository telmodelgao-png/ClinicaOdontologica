using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

namespace ClinicaOdontologica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultoriosController : ControllerBase
    {
        private readonly ClinicaOdontologicaAPIContext _context;

        public ConsultoriosController(ClinicaOdontologicaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Consultorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultorio>>> GetConsultorios()
        {
            return await _context.Consultorio.ToListAsync();
        }

        // GET: api/Consultorios/5
        [HttpGet("{idconsultorio}")]
        public async Task<ActionResult<Consultorio>> GetConsultorio(int idconsultorio)
        {
            var consultorio = await _context.Consultorio.FindAsync(idconsultorio);

            if (consultorio == null)
            {
                return NotFound();
            }

            return consultorio;
        }

        // PUT: api/Consultorios/5
        [HttpPut("{idconsultorio}")]
        public async Task<IActionResult> PutConsultorio(int idconsultorio, Consultorio consultorio)
        {
            if (idconsultorio != consultorio.idConsultorio)
            {
                return BadRequest();
            }

            _context.Entry(consultorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultorioExists(idconsultorio))
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

        // POST: api/Consultorios
        [HttpPost]
        public async Task<ActionResult<Consultorio>> PostConsultorio(Consultorio consultorio)
        {
            _context.Consultorio.Add(consultorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsultorio), new { idconsultorio = consultorio.idConsultorio }, consultorio);
        }

        // DELETE: api/Consultorios/5
        [HttpDelete("{idconsultorio}")]
        public async Task<IActionResult> DeleteConsultorio(int idconsultorio)
        {
            var consultorio = await _context.Consultorio.FindAsync(idconsultorio);
            if (consultorio == null)
            {
                return NotFound();
            }

            _context.Consultorio.Remove(consultorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultorioExists(int idconsultorio)
        {
            return _context.Consultorio.Any(e => e.idConsultorio == idconsultorio);
        }
    }
}