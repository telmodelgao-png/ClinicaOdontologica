using ClinicaOdontologica.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaOdontologica.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthServices _authService;

        public AccountController(IAuthServices authService)
        {
            _authService = authService;
        }

        // GET: /Account/Index
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated) {
                return RedirectToAction(
                    "Index",
                    "Home"
                    );
            }
            return View();
        }

        // POST: /Account/Index
        [HttpPost]
        public async Task<IActionResult> Index(
            string correo,
            string password)
        {
            if (string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Ingrese el correo y la contraseña.";
                return View();
            }

            correo = correo.Trim().ToLower();

            var resultado = await _authService.Login(
                correo,
                password
            );

            if (!resultado)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }

            return RedirectToAction(
                "Index",
                "Home"
            );
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(
                    "Index",
                    "Home"
                    );
            }
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(
            string nombre,
            string apellido,
            string correo,
            string nombreUsuario,
            string password,
            string confirmarPassword)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Todos los campos son obligatorios.";
                return View();
            }

            if (password != confirmarPassword)
            {
                ViewBag.Error = "Las contraseñas no coinciden.";
                return View();
            }

            correo = correo.Trim().ToLower();

            var resultado = await _authService.Register(
                nombre,
                apellido,
                correo,
                nombreUsuario,
                password
            );

            if (!resultado)
            {
                ViewBag.Error = "Ya existe un usuario con ese correo.";
                return View();
            }

            TempData["Mensaje"] =
                "Registro exitoso. Ahora puede iniciar sesión.";

            return RedirectToAction("Index");
        }

        // POST: /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Index","Account");
        }
    }
}