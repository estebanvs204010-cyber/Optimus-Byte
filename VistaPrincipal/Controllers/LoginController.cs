using Microsoft.AspNetCore.Mvc;

namespace VistaPrincipal.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
