using LaboratorioWeb.DTO;

namespace LaboratorioWeb.Services.Interfase
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> GetAllProductosAsync();
        Task<ProductoDTO> GetProductoByIdAsync(int id);
        Task<ProductoDTO> CreateProductoAsync(ProductoDTO productoDTO);
        Task<bool> UpdateProductoAsync(int id, ProductoDTO productoActualizado);
        Task<bool> DeleteProductoAsync(int id);
    }
}
