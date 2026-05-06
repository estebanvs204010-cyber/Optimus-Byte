using Microsoft.AspNetCore.Mvc;
using VistaPrincipal.Models;

public class FacturasController : Controller
{
    public IActionResult Generar()
    {
        return View();
    }
}