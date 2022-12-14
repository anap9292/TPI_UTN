using Microsoft.AspNetCore.Mvc;
using TPI_UTN.Datos;
using TPI_UTN.Models;


namespace TPI_UTN.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();


        //Listar usuario
        public IActionResult Index()
        {
            var oLista = usuarioDatos.ListarUsuario();

            return View(oLista);
        }
    }
}
