namespace TPI_UTN.Models
{
    public class PromocionProducto
    {
        public int id { get; set; }
        public int? promocion { get; set; }
        public int? producto { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFinal { get; set; }
        public List<Producto>? productos { get; set; }
        public Producto? oProducto { get; set; }

    }
}
