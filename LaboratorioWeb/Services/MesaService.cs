using Entidades;
using LaboratorioApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class MesaService
    {
        private readonly RestauranteContext _context;

        public MesaService(RestauranteContext context)
        {
            _context = context;
        }

        // Obtener todas las mesas
        public async Task<List<Mesa>> GetAllMesasAsync()
        {
            return await _context.Mesas.Include(m => m.EstadoMesa).ToListAsync();
        }

        // Obtener una mesa por ID
        public async Task<Mesa> GetMesaByIdAsync(int id)
        {
            return await _context.Mesas.Include(m => m.EstadoMesa).FirstOrDefaultAsync(m => m.MesaId == id);
        }

        // Cambiar el estado de una mesa
        public async Task<bool> CambiarEstadoMesaAsync(int MesaId, int nuevoEstado)
        {
            var mesa = await _context.Mesas.FindAsync(MesaId);
            if (mesa == null) return false;

            mesa.EstadoId = nuevoEstado; // Cambiamos el estado de la mesa
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
