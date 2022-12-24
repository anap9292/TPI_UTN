namespace TPI_UTN.Models
{
    public class Promocion
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public decimal? descuento { get; set;}
        public string? imagen { get; set; }
        public string? descripcion { get; set; }
        public string? fechaInicio { get; set; }
        public string? fechaFinal { get; set; }

        public List<PromocionProducto>? PP { get; set; }

        public List<Producto>? productos { get; set; }
        public int promocionProducto { get; set; }

    }
}
