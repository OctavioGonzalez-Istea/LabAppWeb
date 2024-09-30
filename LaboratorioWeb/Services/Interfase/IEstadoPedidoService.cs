using Entidades;
using LaboratorioWeb.DTO;
using AutoMapper;

namespace LaboratorioApi.Services
{
    public interface IEstadoPedidoService
    {
        // Obtener todos los estados de pedido
        Task<List<EstadoPedidoDTO>> GetAllEstadosPedidoAsync();

        // Obtener un estado de pedido por ID
        Task<EstadoPedidoDTO> GetEstadoPedidoByIdAsync(int id);

        // Crear un nuevo estado de pedido
        Task<EstadoPedidoDTO> CreateEstadoPedidoAsync(EstadoPedidoDTO estadoPedidoDTO);

        // Actualizar un estado de pedido existente
        Task<bool> UpdateEstadoPedidoAsync(int id, EstadoPedidoDTO estadoPedidoActualizado);

        // Eliminar un estado de pedido
        Task<bool> DeleteEstadoPedidoAsync(int id);
        //Task CreateEstadoPedidoAsync(EstadoPedido estado);
    }
}

