using Entidades;
using LaboratorioApi.Data;
using LaboratorioApi.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LaboratorioWeb.DTO;

namespace LaboratorioWeb.Services
{
    public class EstadoPedidoService : IEstadoPedidoService
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public EstadoPedidoService(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Obtener todos los estados de pedido
        public async Task<List<EstadoPedidoDTO>> GetAllEstadosPedidoAsync()
        {
            var estados = await _context.EstadosPedidos.ToListAsync();

            // Mapear de EstadoPedido (entidad) a EstadoPedidoDTO (DTO)
            return _mapper.Map<List<EstadoPedidoDTO>>(estados);
        }

        // Obtener un estado de pedido por ID
        public async Task<EstadoPedidoDTO> GetEstadoPedidoByIdAsync(int id)
        {
            var estadoPedido = await _context.EstadosPedidos.FindAsync(id);
            if (estadoPedido == null) return null;

            // Mapear de EstadoPedido (entidad) a EstadoPedidoDTO (DTO)
            return _mapper.Map<EstadoPedidoDTO>(estadoPedido);
        }

        // Crear un nuevo estado de pedido
        public async Task<EstadoPedidoDTO> CreateEstadoPedidoAsync(EstadoPedidoDTO estadoPedidoDTO)
        {
            // Mapear de EstadoPedidoDTO (DTO) a EstadoPedido (entidad)
            var estadoPedido = _mapper.Map<EstadoPedido>(estadoPedidoDTO);

            _context.EstadosPedidos.Add(estadoPedido);
            await _context.SaveChangesAsync();

            // Retornar el DTO del estado de pedido creado
            return _mapper.Map<EstadoPedidoDTO>(estadoPedido);
        }

        // Actualizar un estado de pedido existente
        public async Task<bool> UpdateEstadoPedidoAsync(int id, EstadoPedidoDTO estadoPedidoActualizadoDTO)
        {
            var estadoPedido = await _context.EstadosPedidos.FindAsync(id);
            if (estadoPedido == null)
            {
                return false;
            }

            // Mapear de EstadoPedidoDTO (DTO) a EstadoPedido (entidad) para la actualización
            _mapper.Map(estadoPedidoActualizadoDTO, estadoPedido);

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un estado de pedido
        public async Task<bool> DeleteEstadoPedidoAsync(int id)
        {
            var estadoPedido = await _context.EstadosPedidos.FindAsync(id);
            if (estadoPedido == null)
            {
                return false;
            }

            _context.EstadosPedidos.Remove(estadoPedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

