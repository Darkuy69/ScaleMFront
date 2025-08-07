using Frontend_ScaleM.Models;

namespace Frontend_ScaleM.Services
{
    // Contrato: cualquier servicio de clientes debe implementar este método
    public interface IClientesService
    {
        // Devuelve la lista de clientes de forma asíncrona (mock o API real)
        Task<List<Cliente>> ObtenerClientesAsync();
    }
}
