using AutoMapper;
using Entidades;
using LaboratorioWeb.DTO;
using LaboratorioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;

        public RolController(IRolService rolService, IMapper mapper)
        {
            _rolService = rolService;
            _mapper = mapper;
        }

        // Obtener todos los roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolService.GetAllRolesAsync();
            var rolesDTO = _mapper.Map<List<RolDTO>>(roles); // Mapeo de entidad a DTO
            return Ok(rolesDTO);
        }

        // Obtener un rol por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolService.GetRolByIdAsync(id);
            if (rol == null) return NotFound();
            var rolDTO = _mapper.Map<RolDTO>(rol); // Mapeo de entidad a DTO
            return Ok(rolDTO);
        }

        // Crear un nuevo rol
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDTO rolDTO)
        {
            var rol = _mapper.Map<Rol>(rolDTO); // Mapeo de DTO a entidad
            var nuevoRol = await _rolService.CreateRolAsync(rol);
            var nuevoRolDTO = _mapper.Map<RolDTO>(nuevoRol); // Mapeo de entidad a DTO
            return CreatedAtAction(nameof(GetById), new { id = nuevoRolDTO.RolId }, nuevoRolDTO);
        }

        // Actualizar un rol existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolDTO rolDTO)
        {
            var rolExistente = await _rolService.GetRolByIdAsync(id);
            if (rolExistente == null) return NotFound();

            _mapper.Map(rolDTO, rolExistente);  // Actualiza las propiedades del rol existente
            var resultado = await _rolService.UpdateRolAsync(id, rolExistente);
            if (!resultado) return BadRequest();
            return NoContent();
        }

        // Eliminar un rol
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _rolService.DeleteRolAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
