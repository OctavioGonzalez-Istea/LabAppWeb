using Entidades;
using LaboratorioWeb.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioWeb.Services.Interfase
{
    public interface IEstadoMesaService
    {
        Task<List<EstadoMesa>> GetAllEstadosMesaAsync();
        Task<EstadoMesa> GetEstadoMesaByIdAsync(int id);
        Task<EstadoMesaDTO> CreateEstadoMesaAsync(EstadoMesaDTO estadoMesaDTO);  // Asegurar que coincida con el service
        Task<bool> UpdateEstadoMesaAsync(int id, EstadoMesaDTO estadoMesaDTO);
        Task<bool> DeleteEstadoMesaAsync(int id);
    }
}
