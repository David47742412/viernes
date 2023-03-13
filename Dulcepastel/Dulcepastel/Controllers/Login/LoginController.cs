using Microsoft.AspNetCore.Mvc;

namespace Dulcepastel.Controllers.Login;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}