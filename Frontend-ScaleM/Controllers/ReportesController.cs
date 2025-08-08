using Microsoft.AspNetCore.Mvc;

namespace Frontend_ScaleM.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Reportes de Rendimiento";
            ViewData["ActivePage"] = "Reportes"; // Usado para marcar el menú activo
            return View();
        }
    }
}
