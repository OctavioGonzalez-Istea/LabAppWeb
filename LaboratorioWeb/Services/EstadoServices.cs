using Entidades;
using LaboratorioApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class EstadoService
    {
        private readonly RestauranteContext _context;

        public EstadoService(RestauranteContext context)
        {
            _context = context;
        }

        // Crear un estado de pedido
        public async Task<EstadoPedido> CrearEstadoPedidoAsync(EstadoPedido estado)
        {
            _context.EstadosPedidos.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        // Editar un estado de pedido
        public async Task<bool> EditarEstadoPedidoAsync(int EstadoId, EstadoPedido estadoActualizado)
        {
            var estado = await _context.EstadosPedidos.FindAsync(EstadoId);
            if (estado == null) return false;

            estado.Descripcion = estadoActualizado.Descripcion;
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un estado de pedido
        public async Task<bool> EliminarEstadoPedidoAsync(int EstadoId)
        {
            var estado = await _context.EstadosPedidos.FindAsync(EstadoId);
            if (estado == null) return false;

            _context.EstadosPedidos.Remove(estado);
            await _context.SaveChangesAsync();
            return true;
        }

        // Crear un estado de mesa
        public async Task<EstadoMesa> CrearEstadoMesaAsync(EstadoMesa estado)
        {
            _context.EstadosMesas.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        // Editar un estado de mesa
        public async Task<bool> EditarEstadoMesaAsync(int EstadoId, EstadoMesa estadoActualizado)
        {
            var estado = await _context.EstadosMesas.FindAsync(EstadoId);
            if (estado == null) return false;

            estado.Descripcion = estadoActualizado.Descripcion;
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un estado de mesa
        public async Task<bool> EliminarEstadoMesaAsync(int EstadoId)
        {
            var estado = await _context.EstadosMesas.FindAsync(EstadoId);
            if (estado == null) return false;

            _context.EstadosMesas.Remove(estado);
            await _context.SaveChangesAsync();
            return true;
        }

        // Obtener un estado de pedido por ID
        public async Task<EstadoPedido> GetEstadoPedidoByIdAsync(int EstadoId)
        {
            return await _context.EstadosPedidos.FindAsync(EstadoId);
        }

        // Obtener un estado de mesa por ID
        public async Task<EstadoMesa> GetEstadoMesaByIdAsync(int EstadoId)
        {
            return await _context.EstadosMesas.FindAsync(EstadoId);
        }
    }
}
