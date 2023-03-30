using System.Globalization;
using Dulcepastel.Models.cliente;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.cookie;
using Dulcepastel.Models.utility.transformable.cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dulcepastel.Controllers.cliente;

[Authorize]
[AutoValidateAntiforgeryToken]
public class ClienteController : Controller
{
    private readonly Cliente _clienteRepository = new();
    

    public IActionResult Index(string data = "", string param = "", bool isFecha = false)
    {
        if(data.IsNullOrEmpty() && param.IsNullOrEmpty() && isFecha == false)
            return View(_clienteRepository.Find(data, param, isFecha));

        var client = _clienteRepository.Find(data, param, isFecha);
        if (client.Count != 0) ViewData["cliente"] = client.First();
        return View(client);

    }

    [HttpPost]
    public async Task<IActionResult> Action(string accion, 
        [Bind("Id", 
            "Nombre",
            "Apellido",
            "TipoDocId",
            "NroDoc",
            "Direccion",
            "Celular",
            "TelFijo",
            "Email",
            "FNacimiento")]
        Cliente client)
    {
        var user = await GetCookie.GetData(HttpContext);
        return accion switch
        {
            "1" => await Insert(client, user, 'N'),
            "2" => await Insert(client, user, 'M'),
            "3" => await Insert(client, user, 'E'),
            _ => RedirectToAction("Index", "Cliente")
        };
    }

    [HttpPost]
    public async Task<IActionResult> Insert(Cliente cliente, Usuario user, char opc)
    {
        try
        {
            var message = await _clienteRepository.Crud(cliente, user, opc);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return RedirectToAction("Index", "Cliente");
    }
}
