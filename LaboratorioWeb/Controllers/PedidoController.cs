using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // Obtener todos los pedidos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        // Obtener un pedido por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        // Crear un nuevo pedido
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pedido pedido)
        {
            var nuevoPedido = await _pedidoService.CreatePedidoAsync(pedido);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPedido.PedidoId }, nuevoPedido);
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
            return Ok(estados);
        }
    }
}
