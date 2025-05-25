namespace MVC.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public int IdCargo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public Usuarios() { }

        public Usuarios(int idUsuario, int idCargo, string usuario, string contrasena)
        {
            IdUsuario = idUsuario;
            IdCargo = idCargo;
            Usuario = usuario;
            Contrasena = contrasena;
        }
    }
}
