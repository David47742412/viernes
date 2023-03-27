using Dulcepastel.Models.tipoDocumento;
using Microsoft.AspNetCore.Mvc;

namespace Dulcepastel.Controllers.tipoDocumento;

public class TipoDocumentoController : Controller
{
    private readonly TipoDocumento _tipoDocumento;

    public TipoDocumentoController(TipoDocumento tipoDocumento)
    {
        _tipoDocumento = tipoDocumento;
    }

    public IActionResult Index()
    {
        return View(_tipoDocumento.Find("", ""));
    }

}

