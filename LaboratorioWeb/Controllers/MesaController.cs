using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesaController : ControllerBase
    {
        private readonly MesaService _mesaService;

        public MesaController(MesaService mesaService)
        {
            _mesaService = mesaService;
        }

        // Obtener todas las mesas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mesas = await _mesaService.GetAllMesasAsync();
            return Ok(mesas);
        }

        // Obtener una mesa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mesa = await _mesaService.GetMesaByIdAsync(id);
            if (mesa == null) return NotFound();
            return Ok(mesa);
        }

        // Cambiar el estado de una mesa
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] int nuevoEstado)
        {
            var resultado = await _mesaService.CambiarEstadoMesaAsync(id, nuevoEstado);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
