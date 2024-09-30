using AutoMapper;
using LaboratorioWeb.DTO;
using LaboratorioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoriApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoPedidoController : ControllerBase
    {
        private readonly IEstadoPedidoService _estadoPedidoService;
        private readonly IMapper _mapper;

        public EstadoPedidoController(IEstadoPedidoService estadoPedidoService, IMapper mapper)
        {
            _estadoPedidoService = estadoPedidoService;
            _mapper = mapper;
        }

        // Obtener todos los estados de pedido
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estados = await _estadoPedidoService.GetAllEstadosPedidoAsync();
            var estadosDTO = _mapper.Map<List<EstadoPedidoDTO>>(estados);
            return Ok(estadosDTO);
        }

        // Obtener un estado de pedido por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estado = await _estadoPedidoService.GetEstadoPedidoByIdAsync(id);
            if (estado == null) return NotFound();
            var estadoDTO = _mapper.Map<EstadoPedidoDTO>(estado);
            return Ok(estadoDTO);
        }


        // Crear un nuevo estado de pedido
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoPedidoDTO estadoPedidoDTO)
        {
            var nuevoEstadoDTO = await _estadoPedidoService.CreateEstadoPedidoAsync(estadoPedidoDTO);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEstadoDTO.EstadoId }, nuevoEstadoDTO);
        }

        // Actualizar un estado de pedido existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoPedidoDTO estadoDTO)
        {
            var estadoExistente = await _estadoPedidoService.GetEstadoPedidoByIdAsync(id);
            if (estadoExistente == null) return NotFound();

            _mapper.Map(estadoDTO, estadoExistente);  // Actualiza las propiedades del estado existente
            var resultado = await _estadoPedidoService.UpdateEstadoPedidoAsync(id, estadoExistente);
            if (!resultado) return BadRequest();
            return NoContent();
        }

        // Eliminar un estado de pedido
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _estadoPedidoService.DeleteEstadoPedidoAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
