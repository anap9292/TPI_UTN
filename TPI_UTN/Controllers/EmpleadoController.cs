using TPI_UTN.Datos;
using TPI_UTN.Models;
using Microsoft.AspNetCore.Mvc;

namespace TPI_UTN.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoDatos empleadoDatos = new EmpleadoDatos();


        //Listar Empleado

        public IActionResult Index()
        {
            var oLista = empleadoDatos.ListarEmpleado();

            return View(oLista);
        }

        //Guardar Empleado Vista--------------------------------------------------------------------
        public IActionResult Guardar()
        {
            return View();
        }

        //Metodo para la logica, para guardar
        [HttpPost]
        public IActionResult Guardar(Empleado oEmpleado)
        {
            var respuesta = empleadoDatos.GuardarEmpleado(oEmpleado);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /*Editar------------------------------------------------*/
        public IActionResult Editar(int id)
        {
            /*ClienteViewModel clienteViewModelo = new ClienteViewModel();
            {
                Cliente = clienteDatos.ObtenerCliente(id);
                ListaClientes = clienteDatos.ListarCliente();
            };
            return View(clienteViewModelo);*/
            //Este metodo devuelve la vista segun el ID
            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);
            return View(oEmpleado);
        }
        [HttpPost]

        //Metodo para la logica, para modificar
        public IActionResult Editar(Empleado oEmpleado)
        {
            var respuesta = empleadoDatos.EditarEmpleado(oEmpleado);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        /*Eliminar----------------------------------------------------*/

        public IActionResult Eliminar(int id)
        {
            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);
            return View(oEmpleado);
        }

        //Metodo para la logica de eliminar el registro
        [HttpPost]
        public IActionResult Eliminar(Empleado oEmpleado)
        {
            var respuesta = empleadoDatos.EliminarEmpleado(oEmpleado.empl_id);

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
