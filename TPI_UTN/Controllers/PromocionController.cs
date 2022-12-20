using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models;

namespace TPI_UTN.Controllers
{
    public class PromocionController : Controller
    {
        PromocionDatos promocionDatos = new PromocionDatos();


        public IActionResult Index()
        {
            var oLista = promocionDatos.Listar();

            return View(oLista);
        }


        public IActionResult Guardar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(Promocion objeto)
        {
            var respuesta = promocionDatos.Guardar(objeto);

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

            var objeto = promocionDatos.Obtener(id);
            return View(objeto);
        }
        [HttpPost]

        public IActionResult Editar(Promocion objeto)
        {
            var respuesta = promocionDatos.Editar(objeto);

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
            var objeto = promocionDatos.Obtener(id);
            return View(objeto);
        }


        [HttpPost]
        public IActionResult Eliminar(Promocion objeto)
        {
            var respuesta = promocionDatos.Eliminar(objeto.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }
    }
}
