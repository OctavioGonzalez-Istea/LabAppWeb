using LaboratorioWeb.DTO;

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
    }
}
