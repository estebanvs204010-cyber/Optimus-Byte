using Microsoft.AspNetCore.Mvc;

namespace VistaPrincipal.Models
{
    public class Cliente : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
