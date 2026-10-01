using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;
using BCrypt.Net;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public UsuariosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _context.Usuario.ToListAsync();
    }

    // GET: api/Usuarios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuarios(int id)
    {
        var usuarios = await _context.Usuario.FindAsync(id);

        if (usuarios == null)
        {
            return NotFound();
        }

        return usuarios;
    }

    // PUT: api/Usuarios/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuarios(int? id, Usuario usuarios)
    {
        if (id != usuarios.id)
        {
            return BadRequest();
        }
        var usuarioExistente = await _context.Usuario.FindAsync(id);
        if (usuarioExistente == null) {
            return NotFound();
        }
        usuarioExistente.nombre = usuarios.nombre;
        usuarioExistente.apellido = usuarios.apellido;
        usuarioExistente.correo= usuarios.correo;
        usuarioExistente.nombreUsuario=usuarios.nombreUsuario;
        if (!string.IsNullOrEmpty(usuarios.password)) 
        { 
        usuarioExistente.password=BCrypt.Net.BCrypt.HashPassword(usuarios.password);
        }
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // POST: api/Usuarios
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuarios(Usuario usuarios)
    {
        var existeUsuario = await _context.Usuario.AnyAsync(u=>u.correo.ToLower()== usuarios.correo.ToLower());

        if (existeUsuario)
        {
            return Conflict("ya se registro ese correo");
        }
        usuarios.password = BCrypt.Net.BCrypt.HashPassword(usuarios.password);
        _context.Usuario.Add(usuarios);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUsuarios),new { id=usuarios.id},usuarios);
    }

    // DELETE: api/Usuarios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuarios(int? id)
    {
        var usuarios = await _context.Usuario.FindAsync(id);
        if (usuarios == null)
        {
            return NotFound();
        }

        _context.Usuario.Remove(usuarios);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuariosExists(int? id)
    {
        return _context.Usuario.Any(e => e.id == id);
    }
}
