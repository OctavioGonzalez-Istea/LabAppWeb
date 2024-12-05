using LaboratorioApi.Controllers;
using LaboratorioWeb.DTO;

namespace LaboratorioWeb.Services.Interfase
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> GetAllPedidosAsync(); // Cambiamos a DTO

        Task<PedidoDTO> GetPedidoByIdAsync(int id); // Cambiamos a DTO

        Task<PedidoDTO> CreatePedidoAsync(PedidoDTO pedidoDTO); // Cambiamos a DTO

        Task<bool> UpdateEstadoPedidoAsync(UpdatePedidoBody _UpdatePedidoBody);
        Task<bool> FinalizarPedido(UpdatePedidoBody _UpdatePedidoBody);

        Task<List<EstadoPedidoDTO>> GetEstadoPedidosAsync(); // Cambiamos a DTO

        Task<bool> ExisteComanda(int ComandaId); // Verifica si Existe Comanda
        Task<bool> ExisteProducto(int ProductoId); // Verifica si Existe Producto
        Task<bool> ProductoConStock(int ProductoId, int Cantidad); // Verifica si Existe Producto con Stock
        Task AjustarStock(int ProductoId, int Cantidad); // Se resta la cantidad que se aceoto en el Pedido
        Task<bool> ValidarMozo(int MozoId); // Validamos que la Mesa se encuentre Libre

        Task<List<PedidoDTO>> PedidosPendientesByEmpleado(int EmpleadoId); // Recuperamos los Pedidos dependiendo el empleado
        Task<PedidoDTO> GetPedidoByEmpleado(int EmpleadoId, int PedidoId);
        Task<List<PedidoDTO>> PedidosByComanda(int ComandaId); // Recuperamos los Pedidos dependiendo el empleado
        Task UpdateEstadoMesa(int MesaId, int EstadoMesa); //Se Actualiza el Estado de una mesa
        Task<ComandaDTO> GetComanda(int ComandaId); //Recuperamos la comanda
    }
}
