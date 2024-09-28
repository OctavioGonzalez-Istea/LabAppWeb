using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services; 

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos);
        }

        // Obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        // Crear un nuevo producto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            var nuevoProducto = await _productoService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoProducto.ProductoId }, nuevoProducto);
        }

        // Actualizar un producto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            var resultado = await _productoService.UpdateProductoAsync(id, producto);
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
