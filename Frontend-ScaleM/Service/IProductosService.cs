using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend_ScaleM.Services
{
    /// <summary>
    /// Contrato para consumir endpoints de PRODUCTOS (líneas de producto, etc.).
    /// Implementaremos este contrato en ProductosService.
    /// </summary>
    public interface IProductosService
    {
        /// <summary>
        /// Obtiene las líneas de producto desde el backend (GET /api/AllProductLine).
        /// </summary>
        Task<List<ProductLineDTO>> ObtenerLineasAsync();
    }

    /// <summary>
    /// DTO mínimo para mapear la respuesta de /api/AllProductLine.
    /// Ajustaremos propiedades si el backend devuelve otros nombres/campos.
    /// </summary>
    public class ProductLineDTO
    {
        public string ProductLine { get; set; } = string.Empty;   // nombre de la línea
        public string? TextDescription { get; set; }              // descripción (puede venir null)
        // Si el backend usa "Description" en lugar de "TextDescription", lo cambiamos luego.
    }
}
