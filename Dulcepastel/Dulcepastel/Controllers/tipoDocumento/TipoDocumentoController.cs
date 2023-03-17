using Dulcepastel.Models.tipoDocumento;
using Microsoft.AspNetCore.Mvc;

namespace Dulcepastel.Controllers.tipoDocumento
{
    public class TipoDocumentoController : Controller
    {
        private readonly TipoDocumento _tipoDocumento;

        public TipoDocumentoController(TipoDocumento tipoDocumento)
        {
            _tipoDocumento = tipoDocumento;
        }
        
        public IActionResult Index()
        {
            return View(_tipoDocumento.Find("", ""));
        }
        /*
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TipoDocumento == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumento
                .FirstOrDefaultAsync(m => m.TipoDocId == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDocId,IdUserCre,Create,IdUserUpd,Update")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumento);
        }
        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TipoDocumento == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TipoDocId,IdUserCre,Create,IdUserUpd,Update")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.TipoDocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.TipoDocId))
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
            return View(tipoDocumento);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TipoDocumento == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumento
                .FirstOrDefaultAsync(m => m.TipoDocId == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TipoDocumento == null)
            {
                return Problem("Entity set 'DulcepastelContext.TipoDocumento'  is null.");
            }
            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
            if (tipoDocumento != null)
            {
                _context.TipoDocumento.Remove(tipoDocumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoExists(string id)
        {
          return (_context.TipoDocumento?.Any(e => e.TipoDocId == id)).GetValueOrDefault();
        }
        */
    }
    
}
