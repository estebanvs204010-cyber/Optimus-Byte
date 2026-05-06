using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Mvc;
using VistaPrincipal.Models;
using VistaPrincipal.Models.ViewModels;
using VistaPrincipal.Data;
using Microsoft.EntityFrameworkCore;

namespace VistaPrincipal.Controllers
{
    public class LoginController : Controller
    {
        private readonly optimusDBContext _db;

        public LoginController(optimusDBContext db) => _db = db;

        // GET: /Login
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Login/Index.cshtml");
        }

        // POST: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = _db.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.Correo == model.Correo && u.Activo);

            if (usuario == null || !BC.Verify(model.Contrasena, usuario.ContrasenaHash))
            {
                // Registrar intento fallido
                _db.IntentosFallidos.Add(new IntentoFallido
                {
                    Correo = model.Correo
                });
                _db.SaveChanges();

                ModelState.AddModelError("", "Correo o contraseña incorrectos");
                return View(model);
            }

            // Guardar sesión
            HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
            HttpContext.Session.SetString("UsuarioNombre", usuario.NombreCompleto);
            HttpContext.Session.SetString("UsuarioRol", usuario.Rol.NombreRol);

            // Registrar en auditoría
            _db.LogAuditoria.Add(new LogAuditoria
            {
                IdUsuario = usuario.IdUsuario,
                Accion = "Inicio de sesión exitoso",
                Modulo = "Autenticación"
            });
            _db.SaveChanges();

            // Redirigir a la vista principal
            return RedirectToAction("Index", "Home");
        }

        // ================= REGISTRO =================
        [HttpGet]
        public IActionResult Registro()
        {
            return View("~/Views/Registro/Index.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    NombreCompleto = model.NombreCompleto,
                    Correo = model.Correo,
                    Telefono = model.Telefono,
                    ContrasenaHash = BC.HashPassword(model.Contrasena),
                    Activo = true,
                    IdRol = 4 // Cliente (ajústalo si tienes otro)
                };

                _db.Usuarios.Add(usuario);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // ================= LOGOUT =================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}