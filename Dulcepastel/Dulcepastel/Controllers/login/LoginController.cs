using Azure;
using Dulcepastel.Models.usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Debugger.Contracts.HotReload;

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
        if (Usuario.User != null)
        {
            return RedirectToAction("Index", "Home", Usuario.User);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Login(Models.login.Login user)
    {
        Usuario? usuario = _login.IsValidUser(user);

        if (usuario is null)
        {
            ModelState.AddModelError("", "Error Credenciales no validas");
            return RedirectToAction("Index", "Login");
        }

        Usuario.User = usuario;
        return RedirectToAction("Index", "Home", usuario);
    }
}