using Entidades;


namespace LaboratorioWeb.Services.Interfase
{
    public interface ISectorService
    {
        Task<Sector> CrearSectorAsync(Sector sector);
        Task<bool> EditarSectorAsync(int sectorId, Sector sectorActualizado);
        Task<bool> EliminarSectorAsync(int sectorId);
        Task<bool> AsignarEmpleadoASectorAsync(int empleadoId, int sectorId);
        Task<List<Empleado>> VerEmpleadosPorSectorAsync(int sectorId);
    }
}
