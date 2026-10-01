using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ClinicaOdontologica.Servicios
{
    public class AuthService : IAuthServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string correo, string password)
        {
            var usuarios = CRUD<Usuario>.GetAll();

            var usuario = usuarios.FirstOrDefault(u =>
                u.correo.Equals(correo, StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                return false;
            }

            bool passwordCorrecta =
                BCrypt.Net.BCrypt.Verify(password, usuario.password);

            if (!passwordCorrecta)
            {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.nombre),
                new Claim(ClaimTypes.Email, usuario.correo),
                new Claim(
                    ClaimTypes.NameIdentifier,
                    usuario.id.ToString()
                ),
                new Claim(
                    "NombreUsuario",
                    usuario.nombreUsuario
                )
            };

            var identity = new ClaimsIdentity(
                claims,
                "Cookies"
            );

            var principal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext!.SignInAsync(
                "Cookies",
                principal
            );

            return true;
        }

        public async Task<bool> Register(
            string nombre,
            string apellido,
            string correo,
            string nombreUsuario,
            string password)
        {
            var usuarios = CRUD<Usuario>.GetAll();

            var existe = usuarios.Any(u =>
                u.correo.Equals(
                    correo,
                    StringComparison.OrdinalIgnoreCase
                ));

            if (existe)
            {
                return false;
            }

            var usuario = new Usuario
            {
                nombre = nombre,
                apellido = apellido,
                correo = correo,
                nombreUsuario = nombreUsuario,
                password = password
            };

            CRUD<Usuario>.Create(usuario);

            return true;
        }
    }
}

