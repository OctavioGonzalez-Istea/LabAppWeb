using Entidades;
using Microsoft.EntityFrameworkCore;
using LaboratorioApi.Data;

namespace LaboratorioApi.Services
{
    public class ComandaService
    {
        private readonly RestauranteContext _context;

        public ComandaService(RestauranteContext context)
        {
            _context = context;
        }

        // Obtener todas las comandas
        public async Task<List<Comanda>> GetAllComandasAsync()
        {
            return await _context.Comandas.ToListAsync();
        }

        // Obtener una comanda por ID
        public async Task<Comanda> GetComandaByIdAsync(int id)
        {
            return await _context.Comandas.FindAsync(id);
        }

        // Crear una nueva comanda
        public async Task<Comanda> CreateComandaAsync(Comanda comanda)
        {
            _context.Comandas.Add(comanda);
            await _context.SaveChangesAsync();
            return comanda;
        }

        // Actualizar una comanda existente
        public async Task<bool> UpdateComandaAsync(int id, Comanda comandaActualizada)
        {
            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda == null)
            {
                return false;
            }

            // Aquí actualizamos las propiedades de la comanda
            comanda.NombreCliente = comandaActualizada.NombreCliente;
            // Actualiza otras propiedades según sea necesario

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
