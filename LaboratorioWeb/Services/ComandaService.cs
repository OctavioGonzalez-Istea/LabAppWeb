using Entidades;
using Microsoft.EntityFrameworkCore;
using LaboratorioApi.Data;
using AutoMapper;
using LaboratorioWeb.DTO;

namespace LaboratorioApi.Services
{
    public class ComandaService : IComandaService
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public ComandaService(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
