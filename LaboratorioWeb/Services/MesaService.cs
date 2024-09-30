using AutoMapper;
using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;


namespace LaboratorioApi.Services
{
    public class MesaService : IMesaService
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public MesaService(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Obtener todas las mesas
        public async Task<List<MesaDTO>> GetAllMesasAsync()
        {
            var mesas = await _context.Mesas.Include(m => m.EstadoMesa).ToListAsync();

            // Mapear de entidad Mesa a DTO MesaDTO
            return _mapper.Map<List<MesaDTO>>(mesas);
        }

        // Obtener una mesa por ID
        public async Task<MesaDTO> GetMesaByIdAsync(int id)
        {
            var mesa = await _context.Mesas.Include(m => m.EstadoMesa).FirstOrDefaultAsync(m => m.MesaId == id);
            if (mesa == null) return null;

            // Mapear de entidad Mesa a DTO MesaDTO
            return _mapper.Map<MesaDTO>(mesa);
        }

        // Crear una nueva mesa
        public async Task<MesaDTO> CreateMesaAsync(MesaDTO mesaDTO)
        {
            // Mapear de DTO MesaDTO a entidad Mesa
            var mesa = _mapper.Map<Mesa>(mesaDTO);

            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();

            // Mapear de nuevo la entidad creada a DTO
            return _mapper.Map<MesaDTO>(mesa);
        }

        // Cambiar el estado de una mesa
        public async Task<bool> CambiarEstadoMesaAsync(int mesaId, int nuevoEstado)
        {
            var mesa = await _context.Mesas.FindAsync(mesaId);
            if (mesa == null) return false;

            mesa.EstadoId = nuevoEstado; // Cambiar el estado de la mesa
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
