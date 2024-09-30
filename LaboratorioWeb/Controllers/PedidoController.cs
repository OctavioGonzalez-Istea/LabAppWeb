using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;
using AutoMapper;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService; // Usar la interfaz en lugar del servicio directamente
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        // Obtener todos los pedidos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();
            var pedidosDTO = _mapper.Map<List<PedidoDTO>>(pedidos);  // Mapear a DTO
            return Ok(pedidosDTO);
        }

        // Obtener un pedido por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null) return NotFound();
            var pedidoDTO = _mapper.Map<PedidoDTO>(pedido);  // Mapear a DTO
            return Ok(pedidoDTO);
        }

        // Crear un nuevo pedido
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoDTO pedido)
        {
            var nuevoPedidoDTO = await _pedidoService.CreatePedidoAsync(pedido); // Mapeo y creación del pedido
            return CreatedAtAction(nameof(GetById), new { id = nuevoPedidoDTO.PedidoId }, nuevoPedidoDTO);
        }

        // Actualizar el estado de un pedido
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] int nuevoEstado)
        {
            var resultado = await _pedidoService.UpdateEstadoPedidoAsync(id, nuevoEstado);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Obtener el estado de todos los pedidos
        [HttpGet("estado")]
        public async Task<IActionResult> GetEstadoPedidos()
        {
            var estados = await _pedidoService.GetEstadoPedidosAsync();
            var estadosDTO = _mapper.Map<List<EstadoPedidoDTO>>(estados);  // Mapear a DTO
            return Ok(estadosDTO);
        }
    }
}
