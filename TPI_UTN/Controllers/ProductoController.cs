using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Models;
using System.Diagnostics;
using TPI_UTN.Models;
using TPI_UTN.Datos;
namespace TPI_UTN.Controllers
{
    public class ProductoController : Controller
    {

        ProductoDatos productoDatos = new ProductoDatos();
        

        public IActionResult Index()
        {
            var listaProducto = productoDatos.Listar();
            return View(listaProducto);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Producto producto)
        {
            var respuesta = productoDatos.Guardar(producto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Editar(int id)
        {
            var producto = productoDatos.Obtener(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            var respuesta = productoDatos.Editar(producto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int id)
        {
            var producto = productoDatos.Obtener(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto producto)
        {
            var respuesta = productoDatos.Eliminar(producto.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}