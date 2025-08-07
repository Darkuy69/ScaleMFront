using Microsoft.AspNetCore.Mvc;
using Frontend_ScaleM.Services;

namespace Frontend_ScaleM.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductosService _service;

        public ProductosController(IProductosService service)
        {
            _service = service;
        }

        // GET: /Productos/JsonLines
        public async Task<IActionResult> JsonLines()
        {
            var lineas = await _service.ObtenerLineasAsync();
            return Json(lineas);
        }
    }
}
