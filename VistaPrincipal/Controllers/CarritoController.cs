using Microsoft.AspNetCore.Mvc;
using VistaPrincipal.Models;

public class CarritoController : Controller
{
    private static List<CarritoItem> carrito = new List<CarritoItem>();

    public IActionResult Index()
    {
        return View(carrito);
    }

    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(CarritoItem item)
    {
        item.Id = carrito.Count + 1;
        carrito.Add(item);
        return RedirectToAction("Index");
    }

    //  ELIMINAR
    public IActionResult Eliminar(int id)
    {
        var item = carrito.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            carrito.Remove(item);
        }
        return RedirectToAction("Index");
    }

    //  EDITAR (GET)
    public IActionResult Editar(int id)
    {
        var item = carrito.FirstOrDefault(x => x.Id == id);
        return View(item);
    }

    //  EDITAR (POST)
    [HttpPost]
    public IActionResult Editar(CarritoItem item)
    {
        var existente = carrito.FirstOrDefault(x => x.Id == item.Id);

        if (existente != null)
        {
            existente.Nombre = item.Nombre;
            existente.Precio = item.Precio;
            existente.Cantidad = item.Cantidad;
        }

        return RedirectToAction("Index");
    }
}