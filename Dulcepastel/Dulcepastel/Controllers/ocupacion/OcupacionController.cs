using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dulcepastel.Models.ocupacion;
using Microsoft.AspNetCore.Authorization;

namespace Dulcepastel.Controllers.ocupacion;

[Authorize]
[AutoValidateAntiforgeryToken]
public class OcupacionController : Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

}

