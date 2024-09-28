using Entidades;
using LaboratorioApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class PedidoService
    {
        private readonly RestauranteContext _context;

        public PedidoService(RestauranteContext context)
        {
            _context = context;
        }

        // Obtener todos los pedidos
        public async Task<List<Pedido>> GetAllPedidosAsync()
        {
            return await _context.Pedidos.Include(p => p.EstadoPedido).Include(p => p.Producto).ToListAsync();
        }

        // Obtener un pedido por ID
        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            return await _context.Pedidos.Include(p => p.EstadoPedido).Include(p => p.Producto).FirstOrDefaultAsync(p => p.PedidoId == id);
        }

        // Crear un nuevo pedido
        public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        // Actualizar el estado de un pedido
        public async Task<bool> UpdateEstadoPedidoAsync(int PedidoId, int nuevoEstado)
        {
            var pedido = await _context.Pedidos.FindAsync(PedidoId);
            if (pedido == null) return false;

            pedido.EstadoId = nuevoEstado; // Actualizamos el estado del pedido
            await _context.SaveChangesAsync();
            return true;
        }

        // Obtener los estados de todos los pedidos
        public async Task<List<EstadoPedido>> GetEstadoPedidosAsync()
        {
            return await _context.EstadosPedidos.ToListAsync();
        }
    }
}
