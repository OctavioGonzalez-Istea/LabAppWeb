using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int SectorId { get; set; }
        public required string Descripcion { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }

        public required Sector Sector { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
