using Frontend_ScaleM.Models;
using Frontend_ScaleM.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_ScaleM.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesService _service;

        public ClientesController(IClientesService service)
        {
            _service = service;
        }

        // GET: /Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _service.ObtenerClientesAsync();
            return View("~/Views/Clientes/Index.cshtml", clientes);
        }

        // Mantén esta acción útil para probar la vista sin datos externos
        public IActionResult ViewPing()
        {
            var prueba = new List<Cliente>
            {
                new Cliente { Id = 99, CustomerName = "Ping Test", Phone = "000-000-0000" }
            };
            return View("~/Views/Clientes/Index.cshtml", prueba);
        }

        // Devuelve los datos (mock o API) como JSON para depurar rápido
        public async Task<IActionResult> JsonTest()
        {
            var clientes = await _service.ObtenerClientesAsync();
            return Json(clientes);
        }
    }
}
