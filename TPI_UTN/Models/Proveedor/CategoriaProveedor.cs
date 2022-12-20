namespace TPI_UTN.Models.Proveedor
{
    public class CategoriaProveedor
    {
        public int id { get; set; }
        public int? proveedor { get; set; }
        public int? categoriaID { get; set; }
        public string? categoria { get; set; }

        Producto oProducto { get; set; }
        Categoria oCategoria { get; set; }


    }
}
