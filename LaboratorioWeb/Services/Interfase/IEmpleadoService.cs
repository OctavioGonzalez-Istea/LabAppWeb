using LaboratorioWeb.DTO;

namespace LaboratorioApi.Services
{
    public interface IEmpleadoService
    {
        // Obtener todos los empleados
        Task<List<EmpleadoDTO>> GetAllEmpleadosAsync(); // Cambiamos a DTO

        // Obtener un empleado por ID
        Task<EmpleadoDTO> GetEmpleadoByIdAsync(int id); // Cambiamos a DTO

        // Crear un nuevo empleado
        Task<EmpleadoDTO> CreateEmpleadoAsync(EmpleadoDTO empleadoDTO); // Cambiamos a DTO

        // Actualizar un empleado existente
        Task<bool> UpdateEmpleadoAsync(int id, EmpleadoDTO empleadoActualizadoDTO); // Cambiamos a DTO

        // Eliminar un empleado
        Task<bool> DeleteEmpleadoAsync(int id);
    }
}
