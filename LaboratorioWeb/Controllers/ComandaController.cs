using Entidades;
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
        private readonly ComandaService _comandaService;

        public ComandaController(ComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        // Obtener una comanda por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comanda = await _comandaService.GetComandaByIdAsync(id);
            if (comanda == null) return NotFound();
            return Ok(comanda);
        }

        // Crear una nueva comanda
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comanda comanda)
        {
            var nuevaComanda = await _comandaService.CreateComandaAsync(comanda);
            return CreatedAtAction(nameof(GetById), new { id = nuevaComanda.ComandaId }, nuevaComanda);
        }


        // Actualizar una comanda existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Comanda comanda)
        {
            var resultado = await _comandaService.UpdateComandaAsync(id, comanda);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
