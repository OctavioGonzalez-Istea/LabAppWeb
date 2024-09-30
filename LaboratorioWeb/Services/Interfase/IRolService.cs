using Entidades;
using LaboratorioWeb.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioApi.Services
{
    public interface IRolService
    {
        Task<List<Rol>> GetAllRolesAsync(); // Puede seguir devolviendo entidades, ya que el mapeo a DTO se realiza en el controlador.
        Task<Rol> GetRolByIdAsync(int id); // Lo mismo aquí, el mapeo se hace en el controlador.
        Task<Rol> CreateRolAsync(Rol rol); // El controlador mapea el DTO a entidad.
        Task<bool> UpdateRolAsync(int id, Rol rolActualizado);
        Task<bool> DeleteRolAsync(int id);
    }
}
