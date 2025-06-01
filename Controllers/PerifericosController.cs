using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class PerifericosController : Controller
    {
        private readonly MVCContext _context;

        public PerifericosController(MVCContext context)
        {
            _context = context;
        }

        // Mostrar perifericos en comboBox
        [HttpPost]
        public IActionResult comboxBoxPerifericos(int IdPeriferico)
        {
            // Recargar el comboBox con los datos de perifericos
            ViewBag.IdPeriferico = new SelectList(
                _context.Perifericos.ToList(),
                "IdPeriferico",
                "NombrePeriferico",
                IdPeriferico
            );

            // Obtener el periferico seleccionado para mostrar sus detalles
            var perifericoSeleccionado = _context.Perifericos.FirstOrDefault(p => p.IdPeriferico == IdPeriferico);
            ViewBag.PerifericoSeleccionado = perifericoSeleccionado;

            // Reenviar la vista Index con los datos
            var perifericos = _context.Perifericos.ToList();
            return View("Index", perifericos);
        }

        [HttpPost]
        public IActionResult CambiarEstado(int IdPeriferico, bool NuevoEstado)
        {
            var periferico = _context.Perifericos.FirstOrDefault(p => p.IdPeriferico == IdPeriferico);
            if (periferico != null)
            {
                periferico.Estado = NuevoEstado;
                _context.SaveChanges();
            }

            // Recargar combo y vista
            ViewBag.IdPeriferico = new SelectList(_context.Perifericos.ToList(), "IdPeriferico", "NombrePeriferico", IdPeriferico);
            ViewBag.PerifericoSeleccionado = periferico;

            var perifericos = _context.Perifericos.ToList();
            return View("Index", perifericos);
        }

        // GET: Perifericos
        public async Task<IActionResult> Index()
        {
            ViewBag.IdPeriferico = new SelectList(
                    await _context.Perifericos.ToListAsync(),
                    "IdPeriferico",
                    "NombrePeriferico"
                );
            return View(await _context.Perifericos.ToListAsync());
        }

        // GET: Perifericos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perifericos = await _context.Perifericos
                .FirstOrDefaultAsync(m => m.IdPeriferico == id);
            if (perifericos == null)
            {
                return NotFound();
            }

            return View(perifericos);
        }

        // GET: Perifericos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perifericos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriferico,NombrePeriferico,IpAdress,MacAdress,Estado")] Perifericos perifericos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perifericos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perifericos);
        }

        // GET: Perifericos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perifericos = await _context.Perifericos.FindAsync(id);
            if (perifericos == null)
            {
                return NotFound();
            }
            return View(perifericos);
        }

        // POST: Perifericos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriferico,NombrePeriferico,IpAdress,MacAdress,Estado")] Perifericos perifericos)
        {
            if (id != perifericos.IdPeriferico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perifericos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerifericosExists(perifericos.IdPeriferico))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(perifericos);
        }

        // GET: Perifericos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perifericos = await _context.Perifericos
                .FirstOrDefaultAsync(m => m.IdPeriferico == id);
            if (perifericos == null)
            {
                return NotFound();
            }

            return View(perifericos);
        }

        // POST: Perifericos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perifericos = await _context.Perifericos.FindAsync(id);
            if (perifericos != null)
            {
                _context.Perifericos.Remove(perifericos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerifericosExists(int id)
        {
            return _context.Perifericos.Any(e => e.IdPeriferico == id);
        }
    }
}
