using Microsoft.AspNetCore.Routing.Constraints;

namespace TPI_UTN.Models
{
    public class Orden
    {
        /*--- Detalle ---*/
        public int id { get; set; } //de orden, no detalle
        public decimal? cantidad { get; set; }
        public decimal? descuento { get; set; }
        public decimal? precioUnitario { get; set; }
        public DateTime? fecha { get; set; }

        /*--- Cliente ---*/
        public int? cliente { get; set; }
        public string? clienteNombre { get; set; }
        public string? clienteApellido { get; set; }

        /*--- Empleado ---*/
        public int? empleado { get; set; }
        public string? empleadoNombre { get; set; }
        public string? empleadoApellido { get; set; }

        /*--- Producto ---*/
        public int? producto { get; set; }
        public string? productoNombre { get; set; }
        public string? productoImagen { get; set; }
        public string? productoDescripcion { get; set; }
        public Producto? oProducto { get; set; }




    }
}
