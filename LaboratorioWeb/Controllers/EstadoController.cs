using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services; 

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _estadoService;

        public EstadoController(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        // Crear un estado de pedido
        [HttpPost("pedido")]
        public async Task<IActionResult> CrearEstadoPedido([FromBody] EstadoPedido estado)
        {
            var nuevoEstado = await _estadoService.CrearEstadoPedidoAsync(estado);
            return CreatedAtAction(nameof(GetEstadoPedidoById), new { EstadoId = nuevoEstado.EstadoId }, nuevoEstado);
        }

        // Editar un estado de pedido
        [HttpPut("pedido/{EstadoId}")]
        public async Task<IActionResult> EditarEstadoPedido(int EstadoId, [FromBody] EstadoPedido estado)
        {
            var resultado = await _estadoService.EditarEstadoPedidoAsync(EstadoId, estado);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Eliminar un estado de pedido
        [HttpDelete("pedido/{EstadoId}")]
        public async Task<IActionResult> EliminarEstadoPedido(int EstadoId)
        {
            var resultado = await _estadoService.EliminarEstadoPedidoAsync(EstadoId);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Crear un estado de mesa
        [HttpPost("mesa")]
        public async Task<IActionResult> CrearEstadoMesa([FromBody] EstadoMesa estado)
        {
            var nuevoEstado = await _estadoService.CrearEstadoMesaAsync(estado);
            return CreatedAtAction(nameof(GetEstadoMesaById), new { EstadoId = nuevoEstado.EstadoId }, nuevoEstado);
        }

        // Editar un estado de mesa
        [HttpPut("mesa/{EstadoId}")]
        public async Task<IActionResult> EditarEstadoMesa(int EstadoId, [FromBody] EstadoMesa estado)
        {
            var resultado = await _estadoService.EditarEstadoMesaAsync(EstadoId, estado);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Eliminar un estado de mesa
        [HttpDelete("mesa/{EstadoId}")]
        public async Task<IActionResult> EliminarEstadoMesa(int EstadoId)
        {
            var resultado = await _estadoService.EliminarEstadoMesaAsync(EstadoId);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Métodos GET opcionales para verificar la creación de estados de pedidos y mesas
        [HttpGet("pedido/{EstadoId}")]
        public async Task<IActionResult> GetEstadoPedidoById(int EstadoId)
        {
            var estado = await _estadoService.GetEstadoPedidoByIdAsync(EstadoId);
            if (estado == null) return NotFound();
            return Ok(estado);
        }

        [HttpGet("mesa/{EstadoId}")]
        public async Task<IActionResult> GetEstadoMesaById(int EstadoId)
        {
            var estado = await _estadoService.GetEstadoMesaByIdAsync(EstadoId);
            if (estado == null) return NotFound();
            return Ok(estado);
        }
    }
}
