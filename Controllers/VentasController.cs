using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class VentasController : Controller
    {
        private readonly MVCContext _context;
        public VentasController(MVCContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public IActionResult Index()
        {
            var ventas = _context.Ventas.Include(v => v.Detalles).ToList();
            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewBag.Productos = _context.Productos.ToList();
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ventas venta, List<int> IdProducto, List<int> Cantidad, List<decimal> Descuento)
        {
            if (IdProducto == null || Cantidad == null || IdProducto.Count != Cantidad.Count)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto.");
                ViewBag.Productos = _context.Productos.ToList();
                return View(venta);
            }

            venta.FechaVenta = DateTime.Now;
            venta.Detalles = new List<DetalleVenta>();
            decimal total = 0;

            for (int i = 0; i < IdProducto.Count; i++)
            {
                var producto = _context.Productos.Find(IdProducto[i]);
                if (producto == null) continue;

                var precioUnitario = producto.Precio;
                var descuento = (Descuento != null && Descuento.Count > i) ? Descuento[i] : 0;
                var cantidad = Cantidad[i];
                var subtotal = (precioUnitario * cantidad) - descuento;

                venta.Detalles.Add(new DetalleVenta
                {
                    IdProducto = producto.IdProducto,
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    Descuento = descuento,
                    Subtotal = subtotal
                });

                total += subtotal;
            }

            venta.TotalVenta = total;
            _context.Ventas.Add(venta);
            _context.SaveChanges();

            // Opcional: Redirigir a recibo/detalle
            return RedirectToAction("Details", new { id = venta.IdVenta });
        }

        // GET: Ventas/Details/5
        public IActionResult Details(int id)
        {
            var venta = _context.Ventas
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefault(v => v.IdVenta == id);

            if (venta == null)
                return NotFound();

            return View(venta);
        }
    }
}