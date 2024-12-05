using Entidades;
using Microsoft.AspNetCore.Mvc;
using LaboratorioApi.Services;
using AutoMapper;
using LaboratorioWeb.DTO;
using LaboratorioWeb.Services.Interfase;
using LaboratorioWeb.Interfaces;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LaboratorioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService; // Usar la interfaz en lugar del servicio directamente
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        // Obtener todos los pedidos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();
            var pedidosDTO = _mapper.Map<List<PedidoDTO>>(pedidos);  // Mapear a DTO
            return Ok(pedidosDTO);
        }

        // Obtener un pedido por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null) return NotFound();
            var pedidoDTO = _mapper.Map<PedidoDTO>(pedido);  // Mapear a DTO
            return Ok(pedidoDTO);
        }
        // Obtener un pedido por ID del empleado
        [HttpGet("Empleado/{EmpleadoId}")]
        public async Task<IActionResult> GetPedidoPendienteByEmpleado(int EmpleadoId)
        {
            var pedidos = await _pedidoService.PedidosPendientesByEmpleado(EmpleadoId);

            if (pedidos == null) return BadRequest("Error en la obtención de datos.");

            if (pedidos.Count == 0) return Ok("No posee pedidos pendientes.");

            return Ok(pedidos);
        }

        // Obtener un pedidos por id de comanda
        [HttpGet("Comanda/{ComandaId}/Empleado/{EmpleadoId}")]
        public async Task<IActionResult> PedidoByComanda(int ComandaId, int EmpleadoId)
        {
            if (EmpleadoId == 0 || !(await _pedidoService.ValidarMozo(EmpleadoId)))
            {
                return BadRequest("El empleado no tiene permiso para iniciar una comanda ");
            }

            var pedidos = await _pedidoService.PedidosByComanda(ComandaId);

            if (pedidos == null) return BadRequest("Error en la obtención de datos.");

            if (pedidos.Count == 0) return Ok("No posee pedidos pendientes.");

            return Ok(pedidos);
        }
        // Obtener Pedidos por Comanda y Measa
        [HttpGet("Comanda/{ComandaId}")]
        public async Task<IActionResult> PedidoByComanda(int ComandaId)
        {
            var pedidos = await _pedidoService.PedidosByComanda(ComandaId);

            if (pedidos == null) return BadRequest("Error en la obtención de datos.");

            if (pedidos.Count == 0) return Ok("No posee pedidos pendientes.");

            return Ok(pedidos);
        }


        // Crear un nuevo pedido
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoDTO pedido, int EmpleadoId)
        {
            if (EmpleadoId == 0 || !(await _pedidoService.ValidarMozo(EmpleadoId)))
            {
                return BadRequest("El empleado no tiene permiso para iniciar una comanda ");
            }

            if (!await _pedidoService.ExisteComanda(pedido.ComandaId)) return BadRequest("Id de comanda inexistente");
            if (!await _pedidoService.ExisteProducto(pedido.ProductoId)) return BadRequest("Id de producto inexistente");
            if (!(pedido.Cantidad > 0)) return BadRequest("Error en el cantidad de producto a preparar");
            if (!await _pedidoService.ProductoConStock(pedido.ProductoId, pedido.Cantidad)) return BadRequest("Producto sin stock");


            pedido.FechaCreacion = DateTime.Now;
            pedido.FechaFinalizacion = DateTime.Now.AddMinutes(10);
            pedido.EstadoId = 1;

            var nuevoPedidoDTO = await _pedidoService.CreatePedidoAsync(pedido); // Mapeo y creación del pedido
            await _pedidoService.AjustarStock(pedido.ProductoId, pedido.Cantidad);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPedidoDTO.PedidoId }, nuevoPedidoDTO);
        }

        // Actualizar el estado de un pedido
        //[HttpPut("{id}/estado")]
        [HttpPut]
        public async Task<IActionResult> UpdateEstado([FromBody] UpdatePedidoBody updatePedido)
        {
            if (updatePedido.NuevoEstadoId == 4)
            {
                if (await _pedidoService.ValidarMozo(updatePedido.EmpleadoId))
                {
                    var resultado = await _pedidoService.FinalizarPedido(updatePedido);
                    if (!resultado) return BadRequest("Error al actualizar el pedido, Verifique el ID de Pedido");

                    PedidoDTO obj = await _pedidoService.GetPedidoByIdAsync(updatePedido.PedidoId);
                    List<PedidoDTO> list = await _pedidoService.PedidosByComanda(obj.ComandaId);

                    bool PedidoSinEntregar = false;

                    foreach (PedidoDTO item in list)
                    {
                        if (item.EstadoId != 4)
                        {
                            PedidoSinEntregar = true;
                            break;
                        }
                    }
                    if (!PedidoSinEntregar)
                    {
                        ComandaDTO comanda =  await _pedidoService.GetComanda(obj.ComandaId);
                        if (comanda == null) return BadRequest("Error al recuperar la comanda para actualizar el estado de la mesa. ");

                        await _pedidoService.UpdateEstadoMesa(comanda.MesaId, 2);
                        return Ok("Pedido actualizado correctamente, ultimo pedido de comanda entregado. " + Environment.NewLine + "Se procedera a Modificar el estado de la Mesa. ");
                    }
                    else
                    {
                        return Ok("Pedido actualizado correctamente");
                    }

                }
                else
                {
                    return BadRequest("Error al actualizar el pedido, Usted no tiene permiso para entregar el Pedido. ");
                }
            }
            else
            {
                var resultado = await _pedidoService.UpdateEstadoPedidoAsync(updatePedido);
                if (!resultado) return BadRequest("Error al actualizar el pedido, Verifique el ID de Pedido");
                return Ok("Pedido actualizado correctamente");
            }
        }

        // Obtener el estado de todos los pedidos
        [HttpGet("estado")]
        public async Task<IActionResult> GetEstadoPedidos()
        {
            var estados = await _pedidoService.GetEstadoPedidosAsync();
            var estadosDTO = _mapper.Map<List<EstadoPedidoDTO>>(estados);  // Mapear a DTO
            return Ok(estadosDTO);
        }
    }

    public class UpdatePedidoBody
    {
        public int PedidoId { get; set; }
        public int EmpleadoId { get; set; }
        public int NuevoEstadoId { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}
