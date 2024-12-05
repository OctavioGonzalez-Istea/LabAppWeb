using Entidades;
using Microsoft.EntityFrameworkCore;
using LaboratorioApi.Data;
using AutoMapper;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;

namespace LaboratorioApi.Services
{
    public class ComandaService : IComandaService
    {

        private readonly IMesaService _MesaService;
        private readonly IEmpleadoService _EmpleadoService;
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public ComandaService(RestauranteContext context, IMapper mapper, IMesaService MesaService, IEmpleadoService empleadoService)
        {
            _context = context;
            _mapper = mapper;
            _MesaService = MesaService;
            _EmpleadoService = empleadoService;

        }

        // Obtener todas las comandas
        public async Task<List<ComandaDTO>> GetAllComandasAsync()
        {
            var comandas = await _context.Comandas.ToListAsync();
            return _mapper.Map<List<ComandaDTO>>(comandas); // Mapear de entidad a DTO
        }

        // Obtener una comanda por ID
        public async Task<ComandaDTO> GetComandaByIdAsync(int id)
        {
            var comanda = await _context.Comandas.FindAsync(id);
            return _mapper.Map<ComandaDTO>(comanda); // Mapear de entidad a DTO
        }

        // Crear una nueva comanda
        public async Task<ComandaDTO> CreateComandaAsync(ComandaDTO comandaDTO)
        {
            var comanda = _mapper.Map<Comanda>(comandaDTO); // Mapear de DTO a entidad
            _context.Comandas.Add(comanda);
            await _context.SaveChangesAsync();
            return _mapper.Map<ComandaDTO>(comanda); // Mapear de entidad a DTO
        }

        // Actualizar una comanda existente
        public async Task<bool> UpdateComandaAsync(int id, ComandaDTO comandaActualizadaDTO)
        {
            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda == null) return false;

            _mapper.Map(comandaActualizadaDTO, comanda); // Mapear de DTO a entidad para la actualización

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteComanda(int ComandaId)
        {
            // Consulta para verificar si la Comanda existe en la base de datos
            return await _context.Comandas.AnyAsync(m => m.ComandaId == ComandaId);
        }

        #region Validaciones 


        public async Task<string> ValidarMesa(int MesaId)
        {
            string msg = string.Empty;
            if (!await _MesaService.ExisteMesa(MesaId))
            {
                msg = "La mesa seleccionada no existe ";
                return msg;
            }
            if (!await _MesaService.MesaLibre(MesaId))
            {
                msg = "La mesa no se encuentra libre ";
                return msg;
            }

            return msg;
        }

        public async Task ActualizarEstadoMesa(int MesaId, int EstadoId)
        {
            await _MesaService.ActualizarEstadoMesa(MesaId, EstadoId);
        }

        public async Task<bool> ValidarMozo(int MozoId)
        {
            EmpleadoDTO obj = await _EmpleadoService.GetEmpleadoByIdAsync(MozoId);

            if (obj != null && obj.RolId == 1) return true; 

            return false;
        }

        #endregion
    }
}
