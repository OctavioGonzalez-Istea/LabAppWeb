using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace LaboratorioApi.Services
{
    public class EstadoMesaService : IEstadoMesaService
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public EstadoMesaService(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Obtener todos los estados de mesa
        public async Task<List<EstadoMesa>> GetAllEstadosMesaAsync()
        {
            return await _context.EstadosMesas.ToListAsync();
        }

        // Obtener un estado de mesa por ID
        public async Task<EstadoMesa> GetEstadoMesaByIdAsync(int id)
        {
            return await _context.EstadosMesas.FindAsync(id);
        }

        // Crear un nuevo estado de mesa
        public async Task<EstadoMesaDTO> CreateEstadoMesaAsync(EstadoMesaDTO estadoMesaDTO)
        {
            var estadoMesa = _mapper.Map<EstadoMesa>(estadoMesaDTO);
            _context.EstadosMesas.Add(estadoMesa);
            await _context.SaveChangesAsync();
            return estadoMesaDTO;
        }

        // Actualizar un estado de mesa existente
        public async Task<bool> UpdateEstadoMesaAsync(int id, EstadoMesaDTO estadoMesaDTO)
        {
            var estadoMesa = await _context.EstadosMesas.FindAsync(id);
            if (estadoMesa == null) return false;

            estadoMesa.Descripcion = estadoMesaDTO.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un estado de mesa
        public async Task<bool> DeleteEstadoMesaAsync(int id)
        {
            var estadoMesa = await _context.EstadosMesas.FindAsync(id);
            if (estadoMesa == null) return false;

            _context.EstadosMesas.Remove(estadoMesa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
