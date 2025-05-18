namespace MVC.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Password { get; set; }

        public int Cargo { get; set; }

        public Usuarios() { }

        public Usuarios(int id, string nombre, string password, int cargo)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
            Cargo = cargo;
        }
    }
}
