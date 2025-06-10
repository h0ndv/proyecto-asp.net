using System.Collections.Generic;

namespace MVC.Models
{

    public class Ventas
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }

        // Relación 1:N con DetalleVenta
        public List<DetalleVenta> Detalles { get; set; }

        public Ventas() 
        {
            Detalles = new List<DetalleVenta>();
        }
    }
}
