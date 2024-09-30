using AutoMapper;
using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly RestauranteContext _context;
        private readonly ILogger<ProductoService> _logger;
        private readonly IMapper _mapper;

        public ProductoService(RestauranteContext context, ILogger<ProductoService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // Obtener todos los productos
        public async Task<List<ProductoDTO>> GetAllProductosAsync()
        {
            var productos = await _context.Productos.Include(p => p.Sector).ToListAsync();
            return _mapper.Map<List<ProductoDTO>>(productos); // Mapeo de entidad a DTO
        }

        // Obtener un producto por ID
        public async Task<ProductoDTO> GetProductoByIdAsync(int id)
        {
            var producto = await _context.Productos.Include(p => p.Sector).FirstOrDefaultAsync(p => p.ProductoId == id);
            return _mapper.Map<ProductoDTO>(producto); // Mapeo de entidad a DTO
        }

        // Crear un nuevo producto
        public async Task<ProductoDTO> CreateProductoAsync(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO); // Mapeo de DTO a entidad
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoDTO>(producto); // Mapeo de entidad a DTO
        }

        // Actualizar un producto existente
        public async Task<bool> UpdateProductoAsync(int id, ProductoDTO productoActualizadoDTO)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _mapper.Map(productoActualizadoDTO, producto); // Mapeo de DTO a entidad

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un producto
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
