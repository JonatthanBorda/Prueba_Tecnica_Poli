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
    public class AutorController : Controller
    {
        private readonly DbAppPoliContext _context;

        public AutorController(DbAppPoliContext context)
        {
            _context = context;
        }

        // GET: Autor
        public async Task<IActionResult> Index()
        {
            var dbAppPoliContext = _context.Autors.Include(a => a.IdTipoDoctoNavigation);
            return View(await dbAppPoliContext.ToListAsync());
        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autors == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors
                .Include(a => a.IdTipoDoctoNavigation)
                .FirstOrDefaultAsync(m => m.IdAutor == id);

            //var libros = _context.Autors
            //    .Include(a => a.Libros)
            //    .FirstOrDefault(a => a.IdAutor == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autor/DetailsBooks/5
        public async Task<IActionResult> DetailsBooks(int? id)
        {
            if (id == null || _context.Autors == null)
            {
                return NotFound();
            }

            var libros = _context.Autors
                .Include(a => a.Libros)
                .FirstOrDefault(a => a.IdAutor == id)?.Libros.ToList();

            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDocto"] = new SelectList(_context.TipoDoctos, "IdTipoDocto", "Nombre");
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutor,Nombre,Apellido,IdTipoDocto,NumDocto,FecNacimiento")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDocto"] = new SelectList(_context.TipoDoctos, "IdTipoDocto", "Nombre", autor.IdTipoDocto);
            return View(autor);
        }

        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autors == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            ViewData["IdTipoDocto"] = new SelectList(_context.TipoDoctos, "IdTipoDocto", "Nombre", autor.IdTipoDocto);
            return View(autor);
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutor,Nombre,Apellido,IdTipoDocto,NumDocto,FecNacimiento")] Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.IdAutor))
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
            ViewData["IdTipoDocto"] = new SelectList(_context.TipoDoctos, "IdTipoDocto", "Nombre", autor.IdTipoDocto);
            return View(autor);
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autors == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors
                .Include(a => a.IdTipoDoctoNavigation)
                .FirstOrDefaultAsync(m => m.IdAutor == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autors == null)
            {
                return Problem("Entity set 'DbAppPoliContext.Autors'  is null.");
            }
            var autor = await _context.Autors.FindAsync(id);
            if (autor != null)
            {
                _context.Autors.Remove(autor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
          return (_context.Autors?.Any(e => e.IdAutor == id)).GetValueOrDefault();
        }
    }
}
