using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services; 

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }


        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        // Crear un nuevo empleado
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empleado empleado)
        {
            var nuevoEmpleado = await _empleadoService.CreateEmpleadoAsync(empleado);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEmpleado.EmpleadoId }, nuevoEmpleado);
        }

        // Actualizar un empleado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Empleado empleado)
        {
            var resultado = await _empleadoService.UpdateEmpleadoAsync(id, empleado);
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
