namespace TPI_UTN.Models
{
    public class Promocion
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public decimal? descuento { get; set;}
        public string? imagen { get; set; }
        public string? descripcion { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFinal { get; set; }



        public List<Producto>? productos { get; set; }
        public int promocionProducto { get; set; }

    }
}
