using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models.Proveedor;

namespace TPI_UTN.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDatos categoriaDatos = new CategoriaDatos();


        public IActionResult Index()
        {
            var oLista = categoriaDatos.Listar();

            return View(oLista);
        }


        public IActionResult Guardar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(Categoria objeto)
        {
            var respuesta = categoriaDatos.Guardar(objeto);

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

            var objeto = categoriaDatos.Obtener(id);
            return View(objeto);
        }
        [HttpPost]

        public IActionResult Editar(Categoria objeto)
        {
            var respuesta = categoriaDatos.Editar(objeto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(objeto);
            }
        }


        public IActionResult Eliminar(int id)
        {
            var objeto = categoriaDatos.Obtener(id);
            return View(objeto);
        }

     
        [HttpPost]
        public IActionResult Eliminar(Categoria objeto)
        {
            var respuesta = categoriaDatos.Eliminar(objeto.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(objeto);
            }


        }
    }
}
