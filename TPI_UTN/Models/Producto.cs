namespace TPI_UTN.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? proveedor { get; set; }
        public decimal stock { get; set; }
        public decimal precio { get; set; }
        public string? imagen { get; set; }
        public string? descripcion { get; set; }

    }
}
