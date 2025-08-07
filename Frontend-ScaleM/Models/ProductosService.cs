using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Frontend_ScaleM.Services
{
    /// <summary>
    /// Implementación del servicio para PRODUCTOS.
    /// Selecciona fuente según ApiBaseUrl:
    /// - "" (vacío)  -> MOCK: wwwroot/mocks/productlines.json
    /// - no vacío    -> API real: GET {ApiBaseUrl}/api/AllProductLine
    /// </summary>
    public class ProductosService : IProductosService
    {
        private readonly HttpClient _http;
        private readonly string _apiBaseUrl;
        private readonly IWebHostEnvironment _env;

        public ProductosService(HttpClient http, IConfiguration config, IWebHostEnvironment env)
        {
            _http = http;
            _apiBaseUrl = config["ApiBaseUrl"] ?? string.Empty;
            _env = env;
        }

        public async Task<List<ProductLineDTO>> ObtenerLineasAsync()
        {
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // 1) MOCK si no hay URL configurada
            if (string.IsNullOrWhiteSpace(_apiBaseUrl))
            {
                var ruta = Path.Combine(_env.WebRootPath, "mocks", "productlines.json");
                if (!File.Exists(ruta))
                    return new List<ProductLineDTO>();

                var json = await File.ReadAllTextAsync(ruta);
                return JsonSerializer.Deserialize<List<ProductLineDTO>>(json, opciones) ?? new List<ProductLineDTO>();
            }

            // 2) API real
            var endpoint = $"{_apiBaseUrl.TrimEnd('/')}/api/AllProductLine";
            var lista = await _http.GetFromJsonAsync<List<ProductLineDTO>>(endpoint, opciones);
            return lista ?? new List<ProductLineDTO>();
        }
    }
}
