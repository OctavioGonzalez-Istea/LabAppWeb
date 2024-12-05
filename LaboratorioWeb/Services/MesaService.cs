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
        private readonly IEmpleadoService _EmpleadoService;
        private readonly IMapper _mapper;

        public MesaService(RestauranteContext context, IMapper mapper, IEmpleadoService empleadoService)
        {
            _context = context;
            _mapper = mapper;
            _EmpleadoService = empleadoService;

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

        public async Task<bool> MesaLibre(int mesaId)
        {
            // Consulta para verificar que la mesa esté libre (EstadoId = 4) -- Mesa Cerrada
            return await _context.Mesas.AnyAsync(m => m.MesaId == mesaId && m.EstadoId == 4);
        }

        public async Task<bool> ExisteMesa(int mesaId)
        {
            // Consulta para verificar si la mesa existe en la base de datos
            return await _context.Mesas.AnyAsync(m => m.MesaId == mesaId);
        }

        public async Task ActualizarEstadoMesa(int MesaId, int EstadoId)
        {
            // Recuperar el producto de la base de datos
            Mesa? mesa = await _context.Mesas
                                         .FirstOrDefaultAsync(m => m.MesaId == MesaId);

            // Actualizar el Estado de la Mesa
            mesa.EstadoId = EstadoId;

            // Guardar los cambios en la base de datos
            _context.Mesas.Update(mesa);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidarSocio(int SocioId)
        {
            EmpleadoDTO obj = await _EmpleadoService.GetEmpleadoByIdAsync(SocioId);

            if (obj.RolId == 5) return true;

            return false;
        }

        public async Task<bool> ValidarMozoSocio(int EmpleadoId)
        {
            EmpleadoDTO obj = await _EmpleadoService.GetEmpleadoByIdAsync(EmpleadoId);

            if (obj.RolId == 5 || obj.RolId == 1) return true;

            return false;
        }
    }
}
