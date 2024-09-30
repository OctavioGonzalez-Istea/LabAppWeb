using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;
using AutoMapper;
using LaboratorioWeb.DTO;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesaController : ControllerBase
    {
        private readonly MesaService _mesaService;
        private readonly IMapper _mapper;

        public MesaController(MesaService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }

        // Obtener todas las mesas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mesas = await _mesaService.GetAllMesasAsync();
            var mesasDTO = _mapper.Map<List<MesaDTO>>(mesas);
            return Ok(mesasDTO);
        }

        // Obtener una mesa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mesa = await _mesaService.GetMesaByIdAsync(id);
            if (mesa == null) return NotFound();

            var mesaDTO = _mapper.Map<MesaDTO>(mesa);
            return Ok(mesaDTO);
        }

        // Crear una nueva mesa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MesaDTO mesaDTO)
        {
            // Mapeo de DTO a entidad
            var mesa = _mapper.Map<Mesa>(mesaDTO);

            // Crear la nueva mesa usando el servicio
            var nuevaMesa = await _mesaService.CreateMesaAsync(mesaDTO);

            // Mapear de entidad a DTO
            var nuevaMesaDTO = _mapper.Map<MesaDTO>(nuevaMesa);

            // Retornar el DTO creado con el código 201 Created
            return CreatedAtAction(nameof(GetById), new { id = nuevaMesaDTO.MesaId }, nuevaMesaDTO);
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
