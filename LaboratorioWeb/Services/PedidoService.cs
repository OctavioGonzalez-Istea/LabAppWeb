using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;
using AutoMapper; // Asegúrate de importar AutoMapper
using LaboratorioWeb.DTO;

namespace LaboratorioApi.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper; // Inyectar el mapeador

        public PedidoService(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; // Inicializar el mapeador
        }

        // Obtener todos los pedidos
        public async Task<List<PedidoDTO>> GetAllPedidosAsync()
        {
            var pedidos = await _context.Pedidos.Include(p => p.EstadoPedido).Include(p => p.Producto).ToListAsync();
            return _mapper.Map<List<PedidoDTO>>(pedidos); // Mapeo de entidad a DTO
        }

        // Obtener un pedido por ID
        public async Task<PedidoDTO> GetPedidoByIdAsync(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.EstadoPedido).Include(p => p.Producto).FirstOrDefaultAsync(p => p.PedidoId == id);
            return _mapper.Map<PedidoDTO>(pedido); // Mapeo de entidad a DTO
        }

        // Crear un nuevo pedido
        public async Task<PedidoDTO> CreatePedidoAsync(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO); // Mapeo de DTO a entidad
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoDTO>(pedido); // Mapeo de entidad a DTO
        }

        // Actualizar el estado de un pedido
        public async Task<bool> UpdateEstadoPedidoAsync(int pedidoId, int nuevoEstado)
        {
            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido == null) return false;

            pedido.EstadoId = nuevoEstado; // Actualizamos el estado del pedido
            await _context.SaveChangesAsync();
            return true;
        }

        // Obtener los estados de todos los pedidos
        public async Task<List<EstadoPedidoDTO>> GetEstadoPedidosAsync()
        {
            var estados = await _context.EstadosPedidos.ToListAsync();
            return _mapper.Map<List<EstadoPedidoDTO>>(estados); // Mapeo de entidad a DTO
        }
    }
}
