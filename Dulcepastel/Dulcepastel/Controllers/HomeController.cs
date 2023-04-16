using Dulcepastel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.cookie;
using Microsoft.AspNetCore.Authorization;
using static Dulcepastel.Models.usuario.Usuario;

namespace Dulcepastel.Controllers;

[Authorize]
[AutoValidateAntiforgeryToken]
public class HomeController : Controller 
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userLogin = await GetCookie.GetData(HttpContext);
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    { 
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
