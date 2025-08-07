using System.Text.Json;
using System.Net.Http.Json;
using Frontend_ScaleM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Frontend_ScaleM.Services
{
    /// <summary>
    /// Implementación del servicio de clientes.
    /// Si ApiBaseUrl está vacío -> usa MOCK (wwwroot/mocks/clientes.json).
    /// Si ApiBaseUrl tiene valor -> consume API real (GET /api/AllCustomers).
    /// </summary>
    public class ClientesService : IClientesService
    {
        private readonly HttpClient _http;
        private readonly string _apiBaseUrl;
        private readonly IWebHostEnvironment _env;

        public ClientesService(HttpClient http, IConfiguration config, IWebHostEnvironment env)
        {
            _http = http;
            _apiBaseUrl = config["ApiBaseUrl"] ?? string.Empty;
            _env = env;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            // Opción 1: MOCK si no hay URL configurada
            if (string.IsNullOrWhiteSpace(_apiBaseUrl))
            {
                var ruta = Path.Combine(_env.WebRootPath, "mocks", "clientes.json");
                if (!File.Exists(ruta)) return new List<Cliente>();

                var json = await File.ReadAllTextAsync(ruta);

                var opciones = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<Cliente>>(json, opciones) ?? new List<Cliente>();
            }

            // Opción 2: API real
            // Ejemplo esperado por el backend del profe:
            // GET {ApiBaseUrl}/api/AllCustomers
            var endpoint = $"{_apiBaseUrl.TrimEnd('/')}/api/AllCustomers";

            var opcionesApi = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // GetFromJsonAsync ya deserializa usando System.Text.Json
            var lista = await _http.GetFromJsonAsync<List<Cliente>>(endpoint, opcionesApi);

            return lista ?? new List<Cliente>();
        }
    }
}
