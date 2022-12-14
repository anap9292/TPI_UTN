using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TPI_UTN.Models
{
    public class Cliente
    {

        public int clie_id { get; set; }
        public string? clie_nombre { get; set; }
        public string? clie_apellido { get; set; }
        public string? clie_cuil { get; set; }
        public string? clie_dni { get; set; }
        public string? clie_razon_social { get; set; }
        public int clie_user { get; set; }
        public int clie_tipo { get; set; }

    }
}
