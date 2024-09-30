using Entidades;
using LaboratorioApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LaboratorioWeb.DTO;

namespace LaboratorioApi.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public EmpleadoService(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Obtener todos los empleados
        public async Task<List<EmpleadoDTO>> GetAllEmpleadosAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();
            return _mapper.Map<List<EmpleadoDTO>>(empleados); // Mapear de entidad a DTO
        }

        // Obtener un empleado por ID
        public async Task<EmpleadoDTO> GetEmpleadoByIdAsync(int id)
        {
            var empleado = await _context.Empleados
                .Include(e => e.Sector)  // Solo incluir la relación si es necesaria
                .Include(e => e.Rol)
                .FirstOrDefaultAsync(e => e.EmpleadoId == id);

            return _mapper.Map<EmpleadoDTO>(empleado); // Mapear de entidad a DTO
        }

        // Crear un nuevo empleado
        public async Task<EmpleadoDTO> CreateEmpleadoAsync(EmpleadoDTO empleadoDTO)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDTO); // Mapear de DTO a entidad
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpleadoDTO>(empleado); // Mapear de entidad a DTO
        }

        // Actualizar un empleado existente
        public async Task<bool> UpdateEmpleadoAsync(int id, EmpleadoDTO empleadoActualizadoDTO)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _mapper.Map(empleadoActualizadoDTO, empleado); // Mapear de DTO a entidad para la actualización

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
