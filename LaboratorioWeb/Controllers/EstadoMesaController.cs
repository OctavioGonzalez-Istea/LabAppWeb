using AutoMapper;
using LaboratorioWeb.DTO;
using Microsoft.AspNetCore.Mvc;
using LaboratorioWeb.Services.Interfase;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoMesaController : ControllerBase
    {
        private readonly IEstadoMesaService _estadoMesaService;
        private readonly IMapper _mapper;

        public EstadoMesaController(IEstadoMesaService estadoMesaService, IMapper mapper)
        {
            _estadoMesaService = estadoMesaService;
            _mapper = mapper;
        }

        // Obtener todos los estados de mesa
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estados = await _estadoMesaService.GetAllEstadosMesaAsync();
            var estadosDTO = _mapper.Map<List<EstadoMesaDTO>>(estados);
            return Ok(estadosDTO);
        }

        // Obtener un estado de mesa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estado = await _estadoMesaService.GetEstadoMesaByIdAsync(id);
            if (estado == null) return NotFound();
            var estadoDTO = _mapper.Map<EstadoMesaDTO>(estado);
            return Ok(estadoDTO);
        }

        // Crear un nuevo estado de mesa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoMesaDTO estadoMesaDTO)
        {
            var nuevoEstadoDTO = await _estadoMesaService.CreateEstadoMesaAsync(estadoMesaDTO);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEstadoDTO.EstadoId }, nuevoEstadoDTO);

        }

        // Actualizar un estado de mesa existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoMesaDTO estadoMesaDTO)
        {
            var estadoExistente = await _estadoMesaService.GetEstadoMesaByIdAsync(id);
            if (estadoExistente == null) return NotFound();

            _mapper.Map(estadoMesaDTO, estadoExistente);  // Actualiza las propiedades del estado existente
            var resultado = await _estadoMesaService.UpdateEstadoMesaAsync(id, estadoMesaDTO);
            if (!resultado) return BadRequest();
            return NoContent();
        }

        // Eliminar un estado de mesa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _estadoMesaService.DeleteEstadoMesaAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
