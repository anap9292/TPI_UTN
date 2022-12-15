namespace practica2.Models
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

        //public Producto(int id, string nombre, decimal precio, string proveedor, int stock)
        //{
        //    this.id = id;
        //    this.nombre = nombre;
        //    this.proveedor = proveedor;
        //    this.stock = stock;
        //    this.precio = precio;
        //}

        //public Producto(int id, string nombre, decimal precio, string proveedor, int stock, string descripcion, string imagen)
        //{
        //    this.id = id;
        //    this.nombre = nombre;
        //    this.proveedor = proveedor;
        //    this.stock = stock;
        //    this.precio = precio;
        //    this.descripcion = descripcion;
        //    this.imagen = imagen;
        //}

        //public Producto() { }
    }
}
