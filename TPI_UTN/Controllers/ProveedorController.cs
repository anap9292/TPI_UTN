using Microsoft.AspNetCore.Mvc;
using practica2.Models.Proveedor;
using System.Diagnostics;
using practica2.Models;

using practica2.Datos;
namespace practica2.Controllers
{
    public class ProveedorController : Controller
    {

        ProveedorDatos proveedorDatos = new ProveedorDatos();
        

        public IActionResult Index()
        {
            var listaProducto = proveedorDatos.Listar();
            return View(listaProducto);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Proveedor producto)
        {
            var respuesta = proveedorDatos.Guardar(producto);

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
            var objeto = proveedorDatos.Obtener(id);
            return View(objeto);
        }

        [HttpPost]
        public IActionResult Editar(Proveedor objeto)
        {
            var respuesta = proveedorDatos.Editar(objeto);

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
            var objeto = proveedorDatos.Obtener(id);
            return View(objeto);
        }

        [HttpPost]
        public IActionResult Eliminar(Proveedor objeto)
        {
            var respuesta = proveedorDatos.Eliminar(objeto.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Categorias(int id)
        {
            List<Categoria> objeto = proveedorDatos.ListarCategorias(id);
            Proveedor proveedor = new Proveedor() { id = id, categorias = objeto};
            return View(proveedor);
        }

        public IActionResult AgregarCategoria(int id)
        {
            var objeto = proveedorDatos.Obtener(id);
            return View(objeto);      
        }


        [HttpPost]
        public IActionResult AgregarCategoria(Proveedor p )
        {
            CategoriaProveedor cp = new CategoriaProveedor() { proveedor = p.id, categoria = p.categoria};
            var respuesta = proveedorDatos.AgregarCategoria(cp);

            if (respuesta)
            {
                return RedirectToAction("Categorias");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EliminarCategoria(Proveedor p)
        {
            CategoriaProveedor cp = new CategoriaProveedor() { proveedor = p.id, categoria = p.categoria };

            return View(cp);
        }

        [HttpPost]
        public IActionResult EliminarCategoria(CategoriaProveedor cp)
        {
            var respuesta = proveedorDatos.EliminarCategoria(cp);

            if (respuesta)
            {
                return RedirectToAction("Categoria");
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