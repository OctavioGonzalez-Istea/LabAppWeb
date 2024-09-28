using Entidades;
using LaboratorioApi.Data; 
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class EmpleadoService
    {
        private readonly RestauranteContext _context;

        public EmpleadoService(RestauranteContext context)
        {
            _context = context;
        }

        // Obtener todos los empleados
        public async Task<List<Empleado>> GetAllEmpleadosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        // Obtener un empleado por ID
        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        // Crear un nuevo empleado
        public async Task<Empleado> CreateEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        // Actualizar un empleado existente
        public async Task<bool> UpdateEmpleadoAsync(int id, Empleado empleadoActualizado)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            // Actualizamos las propiedades necesarias
            empleado.Nombre = empleadoActualizado.Nombre;
            empleado.Usuario = empleadoActualizado.Usuario;
            empleado.Password = empleadoActualizado.Password;
            empleado.SectorId = empleadoActualizado.SectorId;
            empleado.RolId = empleadoActualizado.RolId;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un empleado
        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
