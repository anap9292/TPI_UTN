using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models;


namespace TPI_UTN.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();


        //este muestra el login
        public IActionResult Index()
        {
            var oLista = usuarioDatos.ListarUsuario();

            return View(oLista);
        }

        public IActionResult IndexUsuario()
        {
            var oListaUsuario = usuarioDatos.ListarUsuarioTipo();

            return View(oListaUsuario);
        }

        /*-----------------------------------------------------------*/

        //Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        //Metodo para la logica, para guardar
        [HttpPost]
        public IActionResult Guardar(Usuario oUsuario)
        {
            var respuesta = usuarioDatos.GuardarUsuario(oUsuario);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        /*------------------------------------------------------------------*/

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
            var oUsuario = usuarioDatos.ObtenerUsuarioTipo(id);
            return View(oUsuario);
        }
        [HttpPost]

        public IActionResult Editar(Usuario oUsuario)
        {
            var respuesta = usuarioDatos.EditarUsuario(oUsuario);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /*-------------------------------------------------------------------*/

        //Eliminar

        public IActionResult Eliminar(int id)
        {
            var oUsuario = usuarioDatos.ObtenerUsuarioTipo(id);
            return View(oUsuario);
        }

        //Metodo para la logica de eliminar el registro
        [HttpPost]
        public IActionResult Eliminar(Usuario oUsuario)
        {
            var respuesta = usuarioDatos.EliminarUsuario(oUsuario.usuario_id);

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
