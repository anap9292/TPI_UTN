using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models;
using TPI_UTN.Models.Proveedor;

namespace TPI_UTN.Controllers
{
    public class PromocionController : Controller
    {
        PromocionDatos promocionDatos = new PromocionDatos();
        ProductoDatos productoDatos = new ProductoDatos();


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
                return View(objeto);
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
                return View(objeto);
            }


        }

        public IActionResult Productos(int id)
        {
            Promocion promocion = promocionDatos.Obtener(id);
            List<Producto> productos = promocionDatos.ListarProducto(id);
            List<PromocionProducto> pps = promocionDatos.ListarPP(id);
            foreach (var item in pps)
            {
                foreach (var producto in productos)
                {
                    if (producto.id == item.producto)
                    {
                        item.oProducto = producto;
                    }
                }
            }

            promocion.PP = pps;

            return View(promocion);
        }

        public IActionResult AgregarProducto(int id)
        {
            var promocion = promocionDatos.Obtener(id);
            PromocionProducto pp = new PromocionProducto();
            pp.promocion = id;
            pp.oPromocion = promocion;
            return View(pp);
        }


        [HttpPost]
        public IActionResult AgregarProducto(PromocionProducto pp)
        {
            var respuesta = promocionDatos.AgregarProducto(pp);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                pp.oPromocion = promocionDatos.Obtener(pp.promocion);
                return View(pp);
            }
        }

        public IActionResult EliminarProducto(int id, int promocion, int producto)
        {
            PromocionProducto pp = new PromocionProducto();
            pp.oPromocion = promocionDatos.Obtener(promocion);
            pp.oProducto = productoDatos.Obtener(producto);
            pp.id = id;
            pp.promocion = promocion;
            pp.producto = producto;
            return View(pp);
        }

        [HttpPost]
        public IActionResult EliminarProducto(PromocionProducto pp)
        {

            var respuesta = promocionDatos.EliminarPP(pp.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                pp.oPromocion = promocionDatos.Obtener(pp.promocion);
                pp.oProducto = productoDatos.Obtener(pp.producto);
                return View(pp);
            }
        }

        public IActionResult EditarProducto(int id, int promocion, int producto)
        {
            PromocionProducto pp = new PromocionProducto();
            pp.oPromocion = promocionDatos.Obtener(promocion);
            pp.oProducto = productoDatos.Obtener(producto);
            pp.id = id;
            pp.promocion = promocion;
            pp.producto = producto;
            return View(pp);
        }


        [HttpPost]
        public IActionResult EditarProducto(PromocionProducto pp)
        {
            var respuesta = promocionDatos.EditarPP(pp);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                pp.oPromocion = promocionDatos.Obtener(pp.promocion);
                pp.oProducto = productoDatos.Obtener(pp.producto);
                return View(pp);
            }
        }




    }
}
