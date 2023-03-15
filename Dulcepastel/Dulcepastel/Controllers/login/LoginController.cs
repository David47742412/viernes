using Azure;
using Dulcepastel.Models.usuario;
using Microsoft.AspNetCore.Mvc;

namespace Dulcepastel.Controllers.Login;

public class LoginController : Controller
{

    private readonly Models.login.Login _login;

    public LoginController(Models.login.Login login)
    {
        _login = login;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Models.login.Login user)
    {
        Usuario? usuario = _login.IsValidUser(user);

        if (usuario is null)
        {
            ModelState.AddModelError("", "Error Credenciales no validas");
            return View("Index");
        }
        else
        {
            return RedirectToAction("Index", "Home", usuario);            
        }
    }
}