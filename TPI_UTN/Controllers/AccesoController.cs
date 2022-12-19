using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPI_UTN.Datos;
using TPI_UTN.Models;


namespace TPI_UTN.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        /*public IActionResult Index (Usuario _user)
        {
            UsuarioDatos InfoUsuario = new UsuarioDatos();

            var usuarioAutenticado = InfoUsuario.ValidarUsuario(_user.user_nombre, _user.user_contrasena);

            if (usuarioAutenticado != null)


            return View();
        }*/
        public async Task<IActionResult> Index(Usuario _user)
        {
            UsuarioDatos InfoUsuario = new UsuarioDatos();

            var usuario = InfoUsuario.AutenticarUsuario(_user.user_nombre, _user.user_contrasena);
            //AutenticarUsuario(_user.user_nombre, _user.user_contrasena);


            if (usuario != null  )
            {
                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, usuario.user_nombre)
                   // new Claim( usuario.UsuarioEmail) esto no lo tengo
                };

                claims.Add(new Claim(ClaimTypes.Role, usuario.rolAsociado.tipo_descripcion));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Mensaje"] = "El usuario no existe!";
                return View();
            }

        }
        //Salir del home de vuelta a la vista login
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }





    }

}









