namespace MVC.Models
{
    public class Perifericos
    {
        public int IdPeriferico { get; set; }
        public string NombrePeriferico { get; set; }
        public string IpAdress { get; set; }
        public string MacAdress { get; set; }
        public bool Estado { get; set; }

        public Perifericos() { }

        public Perifericos(int idPeriferico, string nombrePeriferico, string ipAdress, string macAdress, bool estado)
        {
            IdPeriferico = idPeriferico;
            NombrePeriferico = nombrePeriferico;
            IpAdress = ipAdress;
            MacAdress = macAdress;
            Estado = estado;
        }
    }
}
