using Entidades;
using LaboratorioApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class SectorService
    {
        private readonly RestauranteContext _context;

        public SectorService(RestauranteContext context)
        {
            _context = context;
        }

        // Crear un nuevo sector
        public async Task<Sector> CrearSectorAsync(Sector sector)
        {
            _context.Sectores.Add(sector);
            await _context.SaveChangesAsync();
            return sector;
        }

        // Editar un sector existente
        public async Task<bool> EditarSectorAsync(int SectorId, Sector sectorActualizado)
        {
            var sector = await _context.Sectores.FindAsync(SectorId);
            if (sector == null) return false;

            // Actualizamos las propiedades del sector
            sector.Descripcion = sectorActualizado.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un sector
        public async Task<bool> EliminarSectorAsync(int SectorId)
        {
            var sector = await _context.Sectores.FindAsync(SectorId);
            if (sector == null) return false;

            _context.Sectores.Remove(sector);
            await _context.SaveChangesAsync();
            return true;
        }

        // Asignar un empleado a un sector
        public async Task<bool> AsignarEmpleadoASectorAsync(int EmpleadoId, int SectorId)
        {
            var empleado = await _context.Empleados.FindAsync(EmpleadoId);
            var sector = await _context.Sectores.FindAsync(SectorId);

            if (empleado == null || sector == null) return false;

            // Asignamos el sector al empleado
            empleado.SectorId = SectorId;

            await _context.SaveChangesAsync();
            return true;
        }

        // Ver empleados por sector
        public async Task<List<Empleado>> VerEmpleadosPorSectorAsync(int SectorId)
        {
            return await _context.Empleados
                                 .Where(e => e.SectorId == SectorId)
                                 .ToListAsync();
        }
    }
}
