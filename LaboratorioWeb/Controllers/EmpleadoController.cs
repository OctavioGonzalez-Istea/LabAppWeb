using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;
using LaboratorioWeb.DTO;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleadoDTO = await _empleadoService.GetEmpleadoByIdAsync(id); // Usamos DTO
            if (empleadoDTO == null) return NotFound();
            return Ok(empleadoDTO);
        }

        // Crear un nuevo empleado
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpleadoDTO empleadoDTO)
        {
            var nuevoEmpleadoDTO = await _empleadoService.CreateEmpleadoAsync(empleadoDTO);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEmpleadoDTO.EmpleadoId }, nuevoEmpleadoDTO);
        }

        // Actualizar un empleado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoDTO empleadoDTO)
        {
            var resultado = await _empleadoService.UpdateEmpleadoAsync(id, empleadoDTO);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Eliminar un empleado
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _empleadoService.DeleteEmpleadoAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
