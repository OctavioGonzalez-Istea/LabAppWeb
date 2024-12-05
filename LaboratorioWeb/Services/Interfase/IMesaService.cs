using LaboratorioWeb.DTO;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWeb.Services.Interfase
{
    public interface IMesaService
    {
        // Obtener todas las mesas con DTOs
        Task<List<MesaDTO>> GetAllMesasAsync();

        // Obtener una mesa por ID utilizando DTO
        Task<MesaDTO> GetMesaByIdAsync(int id);

        // Crear una nueva mesa utilizando DTO
        Task<MesaDTO> CreateMesaAsync(MesaDTO mesaDTO);

        // Cambiar el estado de una mesa
        Task<bool> CambiarEstadoMesaAsync(int mesaId, int nuevoEstado);
        public Task<bool> MesaLibre(int mesaId); // Verificamos que la mesa este libre
        public Task<bool> ExisteMesa(int mesaId); // Verificamos que exista la mesa
        public Task ActualizarEstadoMesa(int MesaId, int EstadoId); // Actualizamos el Estado de la Mesa
        public Task<bool> ValidarSocio(int SocioId); // Checkeamos que el usuario a cerrar mesa es un socio
        public Task<bool> ValidarMozoSocio(int EmpleadoId); // Checkeamos que el usuario a cerrar mesa es un socio
       
    }
}
