using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Models;
using System.Diagnostics;
using TPI_UTN.Datos;
using Microsoft.AspNetCore.Authorization;

namespace TPI_UTN.Controllers
{

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