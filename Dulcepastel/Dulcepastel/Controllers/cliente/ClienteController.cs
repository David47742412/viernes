using Dulcepastel.Models.cliente;
using Dulcepastel.Models.tipoDocumento;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.interfaces.transformable.cliente;
using Dulcepastel.Models.utility.structView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Controllers.cliente
{
    public class ClienteController : Controller
    {
        private readonly Cliente _clienteRepository;
        private readonly ClienteTransformable _transformable;

        public ClienteController(Cliente clienteRepository, ClienteTransformable transformable)
        {
            _clienteRepository = clienteRepository;
            _transformable = transformable;
        }

        public IActionResult Index()
        {
            if (Usuario.User == null) return RedirectToAction("Index", "Login");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Cliente cliente)
        {
            if (Usuario.User == null) return RedirectToAction("Index", "Login");
            
            
            return RedirectToAction("Index", "Cliente");
        }
        
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombre,Apellido,TipoDocId,NroDoc,Direccion,Celular,TelFijo,Email,FNacimiento,IdUserCre,Create,IduserUpd,Update")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'DulcepastelContext.Clientes'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(string id)
        {
          return _context.Cliente.Any(e => e.Id == id);
        }
        */
    }
}
