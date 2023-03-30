using System.Security.Claims;
using Dulcepastel.Models.utility.jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Dulcepastel.Controllers.Login;

[AutoValidateAntiforgeryToken]
public class LoginController : Controller
{

    private readonly Models.login.Login _login = new();

    [HttpGet]
    public IActionResult Index()
    {
        if (HttpContext.User.Identity is { IsAuthenticated: true })
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(Models.login.Login user)
    {
        var usuario = _login.IsValidUser(user);
        if (usuario is null)
        {
            TempData["ErrorLogin"] = "Email y contraseñas incorrectos";
            TempData["EmailLogin"] = user.Email;
            TempData["PasswordLogin"] = user.Password;
            return RedirectToAction("Index", "Login");
        }
        var data = JwtConfig.CreateToken(usuario);
        var authproperties = new AuthenticationProperties
        {
            IsPersistent = true,
            AllowRefresh = true
        };
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    { new (ClaimTypes.Name, data), },
                CookieAuthenticationDefaults.AuthenticationScheme)), authproperties);
        return RedirectToAction("Index", "Home");
    }
}