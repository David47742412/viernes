using Dulcepastel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Dulcepastel.Models.usuario;
using static Dulcepastel.Models.usuario.Usuario;

namespace Dulcepastel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Usuario? usuario)
        {
            if (usuario?.Id != null)
            {
                return View(usuario);
            }

            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}