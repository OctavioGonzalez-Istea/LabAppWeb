using Entidades;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;
        private readonly IMapper _mapper;

        public SectorController(ISectorService sectorService, IMapper mapper)
        {
            _sectorService = sectorService;
            _mapper = mapper;
        }

        // Crear un sector
        [HttpPost]
        public async Task<IActionResult> CrearSector([FromBody] SectorDTO sectorDTO)
        {
            var sector = _mapper.Map<Sector>(sectorDTO);  // Mapear de DTO a entidad
            var nuevoSector = await _sectorService.CrearSectorAsync(sector);
            var nuevoSectorDTO = _mapper.Map<SectorDTO>(nuevoSector);  // Mapear de entidad a DTO
            return CreatedAtAction(nameof(VerEmpleadosPorSector), new { SectorId = nuevoSectorDTO.SectorId }, nuevoSectorDTO);
        }

        // Editar un sector
        [HttpPut("{SectorId}")]
        public async Task<IActionResult> EditarSector(int SectorId, [FromBody] SectorDTO sectorDTO)
        {
            var sectorActualizado = _mapper.Map<Sector>(sectorDTO);  // Mapear de DTO a entidad
            var resultado = await _sectorService.EditarSectorAsync(SectorId, sectorActualizado);
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
            var empleadosDTO = _mapper.Map<List<EmpleadoDTO>>(empleados);  // Mapear de entidad a DTO
            return Ok(empleadosDTO);
        }
    }
}
