namespace practica2.Models.Proveedor
{
    public class Proveedor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string? direccion { get; set; }
        public string cuit { get; set; }

        //Necesarios para categoria-proveedor
        public List<Categoria> categorias { get; set; }
        public string categoria { get; set; }

    }
}
