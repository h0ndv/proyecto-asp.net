using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly MVCContext _context;

        public LoginController(MVCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Verificar(string usuario, string contrasena)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Contrasena == contrasena);
            if (user == null)
                return View("Index");

            TempData["UserName"] = user.Usuario;
            return RedirectToAction("Index", "Home");
        }
    }
}
