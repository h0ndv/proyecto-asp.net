namespace MVC.Models
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public Productos() { }

        public Productos(int idProducto, int idCategoria, string nombre, int cantidad, int precio)
        {
            IdProducto = idProducto;
            IdCategoria = idCategoria;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
