using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_UTN.Models
{
    public class Empleado
    {
        public int empl_id { get; set; }
        public string? empl_nombre { get; set; }
        public string? empl_apellido { get; set; }
        public int? empl_supervisor_id { get; set; }
        public int? empl_user { get; set; }



    }
}
