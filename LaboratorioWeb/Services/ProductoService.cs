using AutoMapper;
using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

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

        public async Task<bool> ExisteProducto(int ProductoId)
        {
            // Consulta para verificar si el producto existe en la base de datos
            return await _context.Productos.AnyAsync(m => m.ProductoId == ProductoId);
        }

        public async Task<bool> ProductoConStock(int ProductoId, int Cantidad)
        {
            // Recuperar el producto con el ID proporcionado
            Producto producto = await _context.Productos
                                         .Where(p => p.ProductoId == ProductoId)
                                         .FirstOrDefaultAsync();

            // Comparamos el stock disponible con la cantidad solicitada
            return  producto.Stock >= Cantidad;
        }

        public async Task AjustarStock(int ProductoId, int Cantidad)
        {
            // Recuperar el producto de la base de datos
            Producto? producto = await _context.Productos
                                         .FirstOrDefaultAsync(p => p.ProductoId == ProductoId);

            // Ajustar el stock
            producto.Stock -= Cantidad;

            // Guardar los cambios en la base de datos
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
