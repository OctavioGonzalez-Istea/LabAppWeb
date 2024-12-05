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
        public Task<string> ValidarMesa(int MesaId); // Validamos que la Mesa se encuentre Libre

        public Task<bool> ExisteComanda(int ComandaId); // Verificamos que exista la mesa
        public Task ActualizarEstadoMesa(int MesaId, int EstadoId); // Actualizamos el Estado de la Mesa

        public Task<bool> ValidarMozo(int MozoId); // Validamos que la Mesa se encuentre Libre
    }
}
