using LaboratorioWeb.DTO;

namespace LaboratorioApi.Services
{
    public interface IComandaService
    {
        // Obtener todas las comandas
        Task<List<ComandaDTO>> GetAllComandasAsync(); // Devolver una lista de DTO

        // Obtener una comanda por ID
        Task<ComandaDTO> GetComandaByIdAsync(int id); // Devolver un DTO

        // Crear una nueva comanda
        Task<ComandaDTO> CreateComandaAsync(ComandaDTO comandadDTO); // Devolver un DTO

        // Actualizar una comanda existente
        Task<bool> UpdateComandaAsync(int id, ComandaDTO comandaActualizadaDTO); // Recibir un DTO
    }
}
