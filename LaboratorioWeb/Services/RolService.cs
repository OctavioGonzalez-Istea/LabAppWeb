using Entidades;
using LaboratorioApi.Data;
using LaboratorioApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioWeb.Services
{
    public class RolService : IRolService
    {
        private readonly RestauranteContext _context;

        public RolService(RestauranteContext context)
        {
            _context = context;
        }

        // Obtener todos los roles
        public async Task<List<Rol>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        // Obtener un rol por ID
        public async Task<Rol> GetRolByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        // Crear un nuevo rol
        public async Task<Rol> CreateRolAsync(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        // Actualizar un rol existente
        public async Task<bool> UpdateRolAsync(int id, Rol rolActualizado)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return false;
            }

            rol.Descripcion = rolActualizado.Descripcion;
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un rol
        public async Task<bool> DeleteRolAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return false;
            }

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
