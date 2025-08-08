using Microsoft.AspNetCore.Mvc;

namespace Frontend_ScaleM.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Productos";
            ViewData["ActivePage"] = "Productos";  // Establece la página activa
            return View();
        }
    }
}
