using LaboratorioWeb.DTO;

namespace LaboratorioWeb.Services.Interfase
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> GetAllPedidosAsync(); // Cambiamos a DTO

        Task<PedidoDTO> GetPedidoByIdAsync(int id); // Cambiamos a DTO

        Task<PedidoDTO> CreatePedidoAsync(PedidoDTO pedidoDTO); // Cambiamos a DTO

        Task<bool> UpdateEstadoPedidoAsync(int pedidoId, int nuevoEstado);

        Task<List<EstadoPedidoDTO>> GetEstadoPedidosAsync(); // Cambiamos a DTO
    }
}
