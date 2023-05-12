using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Poli.Models;

namespace Prueba_Tecnica_Poli.Controllers
{
    public class TipoDoctoController : Controller
    {
        private readonly DbAppPoliContext _context;

        public TipoDoctoController(DbAppPoliContext context)
        {
            _context = context;
        }

        // GET: TipoDocto
        public async Task<IActionResult> Index()
        {
              return _context.TipoDoctos != null ? 
                          View(await _context.TipoDoctos.ToListAsync()) :
                          Problem("Entity set 'DbAppPoliContext.TipoDoctos'  is null.");
        }

        // GET: TipoDocto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDoctos == null)
            {
                return NotFound();
            }

            var tipoDocto = await _context.TipoDoctos
                .FirstOrDefaultAsync(m => m.IdTipoDocto == id);
            if (tipoDocto == null)
            {
                return NotFound();
            }

            return View(tipoDocto);
        }

        // GET: TipoDocto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoDocto,Nombre")] TipoDocto tipoDocto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocto);
        }

        // GET: TipoDocto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDoctos == null)
            {
                return NotFound();
            }

            var tipoDocto = await _context.TipoDoctos.FindAsync(id);
            if (tipoDocto == null)
            {
                return NotFound();
            }
            return View(tipoDocto);
        }

        // POST: TipoDocto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDocto,Nombre")] TipoDocto tipoDocto)
        {
            if (id != tipoDocto.IdTipoDocto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDoctoExists(tipoDocto.IdTipoDocto))
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
            return View(tipoDocto);
        }

        // GET: TipoDocto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDoctos == null)
            {
                return NotFound();
            }

            var tipoDocto = await _context.TipoDoctos
                .FirstOrDefaultAsync(m => m.IdTipoDocto == id);
            if (tipoDocto == null)
            {
                return NotFound();
            }

            return View(tipoDocto);
        }

        // POST: TipoDocto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDoctos == null)
            {
                return Problem("Entity set 'DbAppPoliContext.TipoDoctos'  is null.");
            }
            var tipoDocto = await _context.TipoDoctos.FindAsync(id);
            if (tipoDocto != null)
            {
                _context.TipoDoctos.Remove(tipoDocto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDoctoExists(int id)
        {
          return (_context.TipoDoctos?.Any(e => e.IdTipoDocto == id)).GetValueOrDefault();
        }
    }
}
