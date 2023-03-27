using System.Globalization;
using Dulcepastel.Models.cliente;
using Dulcepastel.Models.utility.interfaces.transformable.cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dulcepastel.Controllers.cliente;

[Authorize]
[AutoValidateAntiforgeryToken]
public class ClienteController : Controller
{
    private readonly Cliente _clienteRepository;
    private readonly ClienteTransformable _transformable;

    public ClienteController(Cliente clienteRepository, ClienteTransformable transformable)
    {
        _clienteRepository = clienteRepository;
        _transformable = transformable;
    }

    public IActionResult Index(string data = "", string param = "", bool isFecha = false)
    {

        return View(_clienteRepository.Find(data, param, isFecha));
    }

    [HttpPost]
    public async Task<IActionResult> Action(string accion, [FromBody] Cliente client, 
        string data = "", string param = "", bool isFecha = false)
    {
        Console.WriteLine(client.FNacimiento);
        switch (accion)
        {
            case "1":
                return await this.Insert(client);
            case "2":
                return await this.Update(client);
            case "3":
                return await this.Delete(client.Id!);
            default:
                return this.Index(data, param, isFecha);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Insert(Cliente cliente)
    {
        try
        {
            var message = await _clienteRepository.Insert(cliente, HttpContext);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return RedirectToAction("Index", "Cliente");
    }

    [HttpPut]
    public async Task<IActionResult> Update(Cliente client)
    {
        await this._clienteRepository.Update(client, HttpContext);
        return RedirectToAction("Index", "Cliente");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await this._clienteRepository.Delete(id, HttpContext);
        return RedirectToAction("Index", "Cliente");
    }
}
