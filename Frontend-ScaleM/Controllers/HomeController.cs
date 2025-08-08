using System.Diagnostics;
using Frontend_ScaleM.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_ScaleM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Inicio";
            ViewData["ActivePage"] = "Home";  // Establece la página activa
            return View();
        }

        public IActionResult Productos()
        {
            ViewData["Title"] = "Productos";
            ViewData["ActivePage"] = "Productos";  // Establece la página activa
            return View();
        }

        public IActionResult Pedidos()
        {
            ViewData["Title"] = "Pedidos";
            ViewData["ActivePage"] = "Pedidos";  // Establece la página activa
            return View();
        }

        public IActionResult Reportes()
        {
            ViewData["Title"] = "Reportes";
            ViewData["ActivePage"] = "Reportes";  // Establece la página activa
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacidad";
            ViewData["ActivePage"] = "Privacy";  // Establece la página activa
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
