using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JugueteriadelCaribe.Models;

namespace JugueteriadelCaribe.Controllers
{
    public class JuguetesController : Controller
    {
        private readonly JugueteriadbContext _context;

        public JuguetesController(JugueteriadbContext context)
        {
            _context = context;
        }

        // GET: Juguetes
        public async Task<IActionResult> Index()
        {
              return _context.Juguetes != null ? 
                          View(await _context.Juguetes.ToListAsync()) :
                          Problem("Entity set 'JugueteriadbContext.Juguetes'  is null.");
        }

        // GET: Juguetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Juguetes == null)
            {
                return NotFound();
            }

            var juguete = await _context.Juguetes
                .FirstOrDefaultAsync(m => m.PkJuguete == id);
            if (juguete == null)
            {
                return NotFound();
            }

            return View(juguete);
        }

        // GET: Juguetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juguetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkJuguete,Nombre,Genero,Costo,Descripcion,FechaIngreso")] Juguete juguete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juguete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juguete);
        }

        // GET: Juguetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Juguetes == null)
            {
                return NotFound();
            }

            var juguete = await _context.Juguetes.FindAsync(id);
            if (juguete == null)
            {
                return NotFound();
            }
            return View(juguete);
        }

        // POST: Juguetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkJuguete,Nombre,Genero,Costo,Descripcion,FechaIngreso")] Juguete juguete)
        {
            if (id != juguete.PkJuguete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juguete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugueteExists(juguete.PkJuguete))
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
            return View(juguete);
        }

        // GET: Juguetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Juguetes == null)
            {
                return NotFound();
            }

            var juguete = await _context.Juguetes
                .FirstOrDefaultAsync(m => m.PkJuguete == id);
            if (juguete == null)
            {
                return NotFound();
            }

            return View(juguete);
        }

        // POST: Juguetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Juguetes == null)
            {
                return Problem("Entity set 'JugueteriadbContext.Juguetes'  is null.");
            }
            var juguete = await _context.Juguetes.FindAsync(id);
            if (juguete != null)
            {
                _context.Juguetes.Remove(juguete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugueteExists(int id)
        {
          return (_context.Juguetes?.Any(e => e.PkJuguete == id)).GetValueOrDefault();
        }
    }
}
