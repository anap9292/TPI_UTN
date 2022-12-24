using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Models;
using System.Diagnostics;
using TPI_UTN.Models;
using TPI_UTN.Datos;
namespace TPI_UTN.Controllers
{
    public class OrdenController : Controller
    {

        OrdenDatos ordenDatos = new OrdenDatos();
        ProductoDatos productoDatos = new ProductoDatos();


        public IActionResult Index()
        {
            var listaOrden = ordenDatos.Listar();
            return View(listaOrden);
        }

        public IActionResult GenerarOrden(int id)
        {
            var listaProducto = productoDatos.Listar();
            Producto producto = listaProducto.First(prod => prod.id == id);

            Orden oOrden = new Orden();
            oOrden.id = 0;
            oOrden.producto = producto.id;
            oOrden.productoNombre = producto.nombre;
            oOrden.productoImagen = producto.imagen;
            oOrden.productoDescripcion = producto.descripcion;
            oOrden.empleado = 11;
            oOrden.cliente = 48;
            oOrden.descuento = 0.00m;

            return View(oOrden);
        }

        [HttpPost]
        public IActionResult GenerarOrden(Orden orden)
        {
          //  orden.descuento = 0.01m;

            var respuesta = ordenDatos.Guardar(orden);

            if (respuesta)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(orden);
            }
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Orden orden)
        {
            var respuesta = ordenDatos.Guardar(orden);
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
            var orden = ordenDatos.Obtener(id);
            return View(orden);
        }

        [HttpPost]
        public IActionResult Editar(Orden orden)
        {
            var respuesta = ordenDatos.Editar(orden);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(orden);
            }
        }

        public IActionResult Eliminar(int id)
        {
            var orden = ordenDatos.Obtener(id);
            return View(orden);
        }

        [HttpPost]
        public IActionResult Eliminar(Orden orden)
        {
            var respuesta = ordenDatos.Eliminar(orden.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(orden);
            }
        }

        public IActionResult Cancelar(int id)
        {
            var orden = ordenDatos.Obtener(id);
            return View(orden);
        }

        [HttpPost]
        public IActionResult Cancelar(Orden orden)
        {
            var respuesta = ordenDatos.Cancelar(orden.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(orden);
            }
        }

    }

    
}