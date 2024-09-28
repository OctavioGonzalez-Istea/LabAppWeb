using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
public class Pedido
{
    public int PedidoId { get; set; }
    public int ComandaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public int EstadoId { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaFinalizacion { get; set; }

    public required Comanda Comanda { get; set; }
    public required Producto Producto { get; set; }
    public required EstadoPedido EstadoPedido { get; set; }

        //public void ActualizarEsatdoPedido()
        //{
        //    this.EstadoPedido = 
        //}
    }

}
