using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoPedido
    {
        [Key]
        public int EstadoId { get; set; }
        public required string Descripcion { get; set; }

        public required List<Pedido> Pedidos { get; set; }
    }
}
