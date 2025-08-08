using Microsoft.AspNetCore.Mvc;

namespace Frontend_ScaleM.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Gestión de Pedidos";
            ViewData["ActivePage"] = "Pedidos"; // Usado para marcar el menú activo
            return View();
        }
    }
}
