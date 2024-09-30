using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;
using LaboratorioWeb.DTO;
using AutoMapper;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;
        private readonly IMapper _mapper;

        public ComandaController(IComandaService comandaService, IMapper mapper)
        {
            _comandaService = comandaService;
            _mapper = mapper;
        }

        // Obtener una comanda por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comandaDTO = await _comandaService.GetComandaByIdAsync(id); // Trabajamos con DTO
            if (comandaDTO == null) return NotFound();
            return Ok(comandaDTO);
        }

        // Crear una nueva comanda
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComandaDTO comandaDTO)
        {
            var nuevaComandaDTO = await _comandaService.CreateComandaAsync(comandaDTO);
            return CreatedAtAction(nameof(GetById), new { id = nuevaComandaDTO.ComandaId }, nuevaComandaDTO);
        }

        // Actualizar una comanda existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComandaDTO comandaDTO)
        {
            var resultado = await _comandaService.UpdateComandaAsync(id, comandaDTO);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
