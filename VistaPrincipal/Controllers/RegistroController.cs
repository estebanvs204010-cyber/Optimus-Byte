using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Mvc;
using VistaPrincipal.Models;
using VistaPrincipal.Data;
using Microsoft.EntityFrameworkCore;

namespace VistaPrincipal.Controllers
{
    public class RegistroController : Controller
    {
        private readonly optimusDBContext _db;

        public RegistroController(optimusDBContext db) => _db = db;

        // GET: /Registro
        [HttpGet]
        public IActionResult Index()
        {
            // Si ya hay sesión activa, redirigir al inicio
            if (HttpContext.Session.GetString("UsuarioId") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: /Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Usuario model)
        {
            // Verificar si el correo ya existe
            bool correoExiste = _db.Usuarios.Any(u => u.Correo == model.Correo);
            if (correoExiste)
            {
                ModelState.AddModelError("Correo", "Este correo ya está registrado en el sistema.");
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            var nuevoUsuario = new Usuario
            {
                NombreCompleto = model.NombreCompleto,
                Correo = model.Correo,
                Telefono = model.Telefono,
                // Hashear la contraseña con BCrypt antes de guardar
                ContrasenaHash = BC.HashPassword(model.Contrasena),
                Activo = true,
                IdRol = 4  // Rol Cliente por defecto
            };

            _db.Usuarios.Add(nuevoUsuario);
            _db.SaveChanges();

            // Mensaje de éxito y redirigir al login
            TempData["RegistroExitoso"] = $"¡Cuenta creada! Bienvenido {model.NombreCompleto}, ya puedes iniciar sesión.";
            return RedirectToAction("Index", "Login");
        }
    }
}

