using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Data;

namespace MVC.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly MVCContext _context;

        public int TotalProductos { get; set; }
        public int TotalUsuarios { get; set; }

        public DashboardModel(MVCContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            TotalProductos = _context.Productos.Count();
            TotalUsuarios = _context.Usuarios.Count();
        }
    }
}