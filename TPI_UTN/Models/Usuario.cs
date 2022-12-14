using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_UTN.Models
{
    public class Usuario
    {

        public int usuario_id { get; set; }
        public string? user_nombre { get; set; }
        public string? user_contrasena{ get; set; }
        public int user_tipo { get; set; }


    }
}
