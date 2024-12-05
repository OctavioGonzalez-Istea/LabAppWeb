using Entidades;
using LaboratorioApi.Data;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;
using AutoMapper; // Asegúrate de importar AutoMapper
using LaboratorioWeb.DTO;
using LaboratorioApi.Controllers;

namespace LaboratorioApi.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly RestauranteContext _context;
        private readonly IEmpleadoService _EmpleadoService;
        private readonly IComandaService _ComandaService;
        private readonly IProductoService _ProductoService;
        private readonly IMesaService _MesaService;
        private readonly IMapper _mapper; // Inyectar el mapeador

        public PedidoService(RestauranteContext context, IMapper mapper, IComandaService comandaService, IProductoService productoService, IEmpleadoService empleadoService, IMesaService mesaService)
        {
            _context = context;
            _mapper = mapper; // Inicializar el mapeador
            _ComandaService = comandaService;
            _ProductoService = productoService;
            _EmpleadoService = empleadoService;
            _MesaService = mesaService;
        }

        // Obtener todos los pedidos
        public async Task<List<PedidoDTO>> GetAllPedidosAsync()
        {
            var pedidos = await _context.Pedidos.Include(p => p.EstadoPedido).Include(p => p.Producto).ToListAsync();
            return _mapper.Map<List<PedidoDTO>>(pedidos); // Mapeo de entidad a DTO
        }

        // Obtener un pedido por ID
        public async Task<PedidoDTO> GetPedidoByIdAsync(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.EstadoPedido).Include(p => p.Producto).FirstOrDefaultAsync(p => p.PedidoId == id);
            return _mapper.Map<PedidoDTO>(pedido); // Mapeo de entidad a DTO
        }

        // Crear un nuevo pedido
        public async Task<PedidoDTO> CreatePedidoAsync(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO); // Mapeo de DTO a entidad
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoDTO>(pedido); // Mapeo de entidad a DTO
        }

        // Actualizar el estado de un pedido
        public async Task<bool> UpdateEstadoPedidoAsync(UpdatePedidoBody _UpdatePedidoBody)
        {
            var Pedido = await GetPedidoByEmpleado(_UpdatePedidoBody.EmpleadoId, _UpdatePedidoBody.PedidoId);
            if (Pedido == null) return false; //Checkeamos que este Empleado corresponda con el Pedido

            var pedido = await _context.Pedidos.FindAsync(_UpdatePedidoBody.PedidoId);
            if (pedido == null) return false;

            pedido.EstadoId = _UpdatePedidoBody.NuevoEstadoId; // Actualizamos el estado del pedido
            pedido.FechaFinalizacion = _UpdatePedidoBody.FechaFinalizacion; // Actualizamos el estado del pedido
            await _context.SaveChangesAsync();
            return true;
        }

        // Obtener los estados de todos los pedidos
        public async Task<List<EstadoPedidoDTO>> GetEstadoPedidosAsync()
        {
            var estados = await _context.EstadosPedidos.ToListAsync();
            return _mapper.Map<List<EstadoPedidoDTO>>(estados); // Mapeo de entidad a DTO
        }

        public async Task<bool> ExisteComanda(int ComandaId)
        {
            return await _ComandaService.ExisteComanda(ComandaId);
        }

        public async Task<bool> ExisteProducto(int ProductoId)
        {
            return await _ProductoService.ExisteProducto(ProductoId);
        }

        public async Task<bool> ProductoConStock(int ProductoId, int Cantidad)
        {
            return await _ProductoService.ProductoConStock(ProductoId, Cantidad);
        }

        public async Task AjustarStock(int ProductoId, int Cantidad)
        {
            await _ProductoService.AjustarStock(ProductoId, Cantidad);
        }

        public async Task<bool> ValidarMozo(int MozoId)
        {
            EmpleadoDTO obj = await _EmpleadoService.GetEmpleadoByIdAsync(MozoId);

            if (obj != null && obj.RolId == 1) return true;

            return false;
        }

        public async Task<List<PedidoDTO>> PedidosPendientesByEmpleado(int EmpleadoId)
        {
            EmpleadoDTO obj = await _EmpleadoService.GetEmpleadoByIdAsync(EmpleadoId);

            if (obj == null) return null;

            var pedidos = await _context.Pedidos
                .Where(p => p.EstadoId == 1 && p.Producto.SectorId == obj.SectorId)
                .Select(p => new PedidoDTO
                {
                    PedidoId = p.PedidoId,
                    ComandaId = p.ComandaId,
                    ProductoId = p.ProductoId,
                    ProductoDescripcion = p.Producto.Descripcion,  // Descripción del producto
                    Cantidad = p.Cantidad,
                    EstadoId = p.EstadoId,
                    EstadoDescripcion = p.EstadoPedido.Descripcion, // Descripción del estado
                    FechaCreacion = p.FechaCreacion,
                    FechaFinalizacion = p.FechaFinalizacion
                })
                .ToListAsync();

            return pedidos;
        }

        public async Task<List<PedidoDTO>> PedidosByComanda(int ComandaId)
        {

            var pedidos = await _context.Pedidos
                .Where(p => p.ComandaId == ComandaId)
                .Select(p => new PedidoDTO
                {
                    PedidoId = p.PedidoId,
                    ComandaId = p.ComandaId,
                    ProductoId = p.ProductoId,
                    ProductoDescripcion = p.Producto.Descripcion,  // Descripción del producto
                    Cantidad = p.Cantidad,
                    EstadoId = p.EstadoId,
                    EstadoDescripcion = p.EstadoPedido.Descripcion, // Descripción del estado
                    FechaCreacion = p.FechaCreacion,
                    FechaFinalizacion = p.FechaFinalizacion
                })
                .ToListAsync();

            return pedidos;
        }

        public async Task<PedidoDTO> GetPedidoByEmpleado(int EmpleadoId, int PedidoId)
        {
            EmpleadoDTO obj = await _EmpleadoService.GetEmpleadoByIdAsync(EmpleadoId);

            if (obj == null) return null;

            var pedidos = await _context.Pedidos
                .Where( p => p.Producto.SectorId == obj.SectorId  && p.PedidoId == PedidoId)
                .Select(p => new PedidoDTO
                {
                    PedidoId = p.PedidoId,
                    ComandaId = p.ComandaId,
                    ProductoId = p.ProductoId,
                    ProductoDescripcion = p.Producto.Descripcion,  // Descripción del producto
                    Cantidad = p.Cantidad,
                    EstadoId = p.EstadoId,
                    EstadoDescripcion = p.EstadoPedido.Descripcion, // Descripción del estado
                    FechaCreacion = p.FechaCreacion,
                    FechaFinalizacion = p.FechaFinalizacion
                }).FirstOrDefaultAsync();
                //.ToListAsync();

            return pedidos;
        }

        public async Task UpdateEstadoMesa(int MesaId, int EstadoMesa)
        {
            await _MesaService.CambiarEstadoMesaAsync(MesaId, EstadoMesa);
        }

        public async Task<bool> FinalizarPedido(UpdatePedidoBody _UpdatePedidoBody)
        {
            var pedido = await _context.Pedidos.FindAsync(_UpdatePedidoBody.PedidoId);
            if (pedido == null) return false;

            pedido.EstadoId = _UpdatePedidoBody.NuevoEstadoId; // Actualizamos el estado del pedido
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ComandaDTO> GetComanda(int ComandaId)
        {
            return await _ComandaService.GetComandaByIdAsync(ComandaId);
        }
    }
}
