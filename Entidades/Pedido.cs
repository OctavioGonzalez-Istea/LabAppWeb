using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Pedido
    {
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        
        public Comanda Comanda { get; set; }
        public Producto Producto { get; set; }
        public EstadoPedido Estado { get; set; }
    }
}
