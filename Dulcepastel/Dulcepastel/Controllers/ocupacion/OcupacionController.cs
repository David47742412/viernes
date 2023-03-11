using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dulcepastel.Models.context;
using Dulcepastel.Models.ocupacion;

namespace Dulcepastel.Controllers.ocupacion
{
    public class OcupacionController : Controller
    {
        private readonly DulcepastelContext _context;

        public OcupacionController(DulcepastelContext context)
        {
            _context = context;
        }

        // GET: Ocupacion
        public async Task<IActionResult> Index()
        {
              return _context.Ocupacion != null ? 
                          View(await _context.Ocupacion.ToListAsync()) :
                          Problem("Entity set 'DulcepastelContext.Ocupacion'  is null.");
        }

        // GET: Ocupacion/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Ocupacion == null)
            {
                return NotFound();
            }

            var ocupacion = await _context.Ocupacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            return View(ocupacion);
        }

        // GET: Ocupacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocupacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,UserIdCre,Create,IdUserUpd,Update")] Ocupacion ocupacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocupacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocupacion);
        }

        // GET: Ocupacion/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Ocupacion == null)
            {
                return NotFound();
            }

            var ocupacion = await _context.Ocupacion.FindAsync(id);
            if (ocupacion == null)
            {
                return NotFound();
            }
            return View(ocupacion);
        }

        // POST: Ocupacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Descripcion,UserIdCre,Create,IdUserUpd,Update")] Ocupacion ocupacion)
        {
            if (id != ocupacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocupacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcupacionExists(ocupacion.Id))
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
            return View(ocupacion);
        }

        // GET: Ocupacion/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Ocupacion == null)
            {
                return NotFound();
            }

            var ocupacion = await _context.Ocupacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            return View(ocupacion);
        }

        // POST: Ocupacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Ocupacion == null)
            {
                return Problem("Entity set 'DulcepastelContext.Ocupacion'  is null.");
            }
            var ocupacion = await _context.Ocupacion.FindAsync(id);
            if (ocupacion != null)
            {
                _context.Ocupacion.Remove(ocupacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcupacionExists(string id)
        {
          return (_context.Ocupacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
