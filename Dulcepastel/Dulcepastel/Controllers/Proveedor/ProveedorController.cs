using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.cookie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dulcepastel.Controllers.Proveedor;

[Authorize]
[AutoValidateAntiforgeryToken]
public class ProveedorController : Controller
{

    private readonly Models.proveedor.Proveedor _repository = new();
    
    public IActionResult Index(string data = "", string param = "", bool isFecha = false)
    {
        if(data.IsNullOrEmpty() && param.IsNullOrEmpty() && isFecha == false)
            return View(_repository.Find(data, param, isFecha));

        var proveedor = _repository.Find(data, param, isFecha);
        if (proveedor.Count != 0) ViewData["proveedor"] = proveedor.First();
        return View(proveedor);

    }

    [HttpPost]
    public async Task<IActionResult> Action(string accion, 
        [Bind("Id", 
            "Ruc",
            "Ncomercial",
            "RazonSocial",
            "Celular",
            "Telefono",
            "PaginaWeb",
            "Email",
            "Direccion",
            "Descripcion",
            "TipoDocId")]
        Models.proveedor.Proveedor client)
    {
        var user = await GetCookie.GetData(HttpContext);
        return accion switch
        {
            "1" => await Insert(client, user, 'N'),
            "2" => await Insert(client, user, 'M'),
            "3" => await Insert(client, user, 'E'),
            _ => RedirectToAction("Index", "Proveedor")
        };
    }

    [HttpPost]
    public async Task<IActionResult> Insert(Models.proveedor.Proveedor cliente, Usuario user, char opc)
    {
        try
        {
            var message = await _repository.Crud(cliente, user, opc);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return RedirectToAction("Index", "Proveedor");
    }
}