using Microsoft.AspNetCore.Mvc;
using VistaPrincipal.Models;

namespace TuProyecto.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Diagnostico()
        {
            return View();
        }

        public IActionResult Mantenimiento()
        {
            return View();
        }

        public IActionResult Reparaciones()
        {
            return View();
        }

        public IActionResult Electricidad()
        {
            return View();
        }

        public IActionResult Inspecciones()
        {
            return View();
        }
    }
}