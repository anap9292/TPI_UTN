using Microsoft.AspNetCore.Mvc;
using practica2.Models;
using System.Diagnostics;
using practica2.Datos;
using Microsoft.AspNetCore.Authorization;

namespace practica2.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        ProductoDatos productoDatos = new ProductoDatos();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listaProducto = productoDatos.Listar();
            return View(listaProducto);
        }

        public IActionResult VerMas(int id)
        {
            var listaProducto = productoDatos.Listar();
            Producto producto = listaProducto.First(prod => prod.id == id);
            return View(producto);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}