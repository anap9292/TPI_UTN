using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_UTN.Models.Proveedor;

namespace TPI_UTN.Models
{
    public class Usuario
    {

        public int usuario_id { get; set; }
        public string? user_nombre { get; set; } //en el ejemplo del profe es email
        public string? user_contrasena{ get; set; }
       
        //Fk 
        public int user_tipo { get; set; }


        //objeto de tipo de usuarios
        public TipoUsuario? rolAsociado { get; set; } 



        //public string usuarioTipo { get; set; } // esto se lo agregué porque no me deja crear un nuevo objeto
    }
}
