using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos); // El servicio ya devuelve DTOs
        }

        // Obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto); // El servicio ya devuelve DTOs
        }

        // Crear un nuevo producto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDTO productoDTO)
        {
            var nuevoProductoDTO = await _productoService.CreateProductoAsync(productoDTO);
            return CreatedAtAction(nameof(GetById), new { id = nuevoProductoDTO.ProductoId }, nuevoProductoDTO);
        }

        // Actualizar un producto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoDTO productoDTO)
        {
            var resultado = await _productoService.UpdateProductoAsync(id, productoDTO);
            if (!resultado) return NotFound();
            return NoContent();
        }

        // Eliminar un producto
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _productoService.DeleteProductoAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
