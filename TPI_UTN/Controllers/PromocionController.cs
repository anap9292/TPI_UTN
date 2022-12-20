using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models;
using TPI_UTN.Models.Proveedor;

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

        public IActionResult Productos(int id)
        {
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
            return View(pps);
        }

        //public IActionResult AgregarProducto(int id)
        //{
        //    var objeto = promocionDatos.Obtener(id);
        //    return View(objeto);
        //}


        //[HttpPost]
        //public IActionResult AgregarProducto(Promocion p)
        //{
        //    PromocionProducto pp = new PromocionProducto() { promocion = p.id, categoria = p.categoria };
        //    var respuesta = proveedorDatos.AgregarCategoria(cp);

        //    if (respuesta)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpGet]
        //public IActionResult EliminarCategoria(int proveedor, string categoria)
        //{
        //    CategoriaProveedor cp = new CategoriaProveedor();
        //    cp.proveedor = proveedor;
        //    cp.categoria = categoria;

        //    return View(cp);
        //}

        //[HttpPost]
        //public IActionResult EliminarCategoria(CategoriaProveedor cp)
        //{

        //    var respuesta = proveedorDatos.EliminarCategoria(cp);

        //    if (respuesta)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(cp);
        //    }
        //}




    }
}
