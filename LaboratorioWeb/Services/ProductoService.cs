using AutoMapper;
using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.DTO;
//using LaboratorioWeb.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioApi.Services
{
    public class ProductoService
    {
        private readonly RestauranteContext _context;
        private readonly ILogger<ProductoService> _logger;
        private readonly IMapper _mapper;

        public ProductoService(RestauranteContext context, ILogger<ProductoService>logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public void CargarProducto(ProductoDTO productoDTO) 
        {
            Producto producto = this._mapper.Map<Producto>(productoDTO);
            this._context.Productos.Add(producto);
            this._context.SaveChanges();
        }
        
        // Obtener todos los productos
        public async Task<List<Producto>> GetAllProductosAsync()
        {
            return await _context.Productos.Include(p => p.Sector).ToListAsync();
        }

        // Obtener un producto por ID
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.Include(p => p.Sector).FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        // Crear un nuevo producto
        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        // Actualizar un producto existente
        public async Task<bool> UpdateProductoAsync(int id, Producto productoActualizado)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            // Actualizamos las propiedades del producto
            producto.Descripcion = productoActualizado.Descripcion;
            producto.Precio = productoActualizado.Precio;
            producto.Stock = productoActualizado.Stock;
            producto.SectorId = productoActualizado.SectorId;

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
