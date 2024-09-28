using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly SectorService _sectorService;

        public SectorController(SectorService sectorService)
        {
            _sectorService = sectorService;
        }

        // Crear un sector
        [HttpPost]
        public async Task<IActionResult> CrearSector([FromBody] Sector sector)
        {
            var nuevoSector = await _sectorService.CrearSectorAsync(sector);
            return CreatedAtAction(nameof(VerEmpleadosPorSector), new { SectorId = nuevoSector.SectorId }, nuevoSector);
        }

        // Editar un sector
        [HttpPut("{SectorId}")]
        public async Task<IActionResult> EditarSector(int SectorId, [FromBody] Sector sector)
        {
            var resultado = await _sectorService.EditarSectorAsync(SectorId, sector);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Eliminar un sector
        [HttpDelete("{SectorId}")]
        public async Task<IActionResult> EliminarSector(int SectorId)
        {
            var resultado = await _sectorService.EliminarSectorAsync(SectorId);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Asignar un empleado a un sector
        [HttpPut("{EmpleadoId}/asignar-sector/{SectorId}")]
        public async Task<IActionResult> AsignarEmpleadoASector(int EmpleadoId, int SectorId)
        {
            var resultado = await _sectorService.AsignarEmpleadoASectorAsync(EmpleadoId, SectorId);
            if (!resultado) return NotFound();
            return Ok("Empleado asignado al sector");
        }

        // Ver empleados por sector
        [HttpGet("{SectorId}/empleados")]
        public async Task<IActionResult> VerEmpleadosPorSector(int SectorId)
        {
            var empleados = await _sectorService.VerEmpleadosPorSectorAsync(SectorId);
            if (empleados == null || empleados.Count == 0) return NotFound();
            return Ok(empleados);
        }
    }
}
