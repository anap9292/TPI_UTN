using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models;

namespace TPI_UTN.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDatos clienteDatos = new ClienteDatos();


        //Listar
        public IActionResult Index()
        {
            var oLista = clienteDatos.ListarCliente();

            return View(oLista);
        }
        /*-----------------------------------------------------------*/
        //Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        //Metodo para la logica, para guardar
        [HttpPost]
        public IActionResult Guardar(Cliente oCliente)
        {
            var respuesta = clienteDatos.GuardarCliente(oCliente);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        /// --------------------------------------------------------------
        //Editar
        public IActionResult Editar(int id)
        {
            /*ClienteViewModel clienteViewModelo = new ClienteViewModel();
            {
                Cliente = clienteDatos.ObtenerCliente(id);
                ListaClientes = clienteDatos.ListarCliente();
            };
            return View(clienteViewModelo);*/
            //Este metodo devuelve la vista segun el ID
            var oCliente = clienteDatos.ObtenerCliente(id);
            return View(oCliente);
        }
        [HttpPost]

        //Metodo para la logica, para modificar
        public IActionResult Editar(Cliente oCliente)
        {
            var respuesta = clienteDatos.EditarCliente(oCliente);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        /*Eliminar*/

        public IActionResult Eliminar(int id)
        {
            var oCliente = clienteDatos.ObtenerCliente(id);
            return View(oCliente);
        }

        //Metodo para la logica de eliminar el registro
        [HttpPost]
        public IActionResult Eliminar(Cliente oCliente)
        {
            var respuesta = clienteDatos.EliminarCliente(oCliente.clie_id);

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
