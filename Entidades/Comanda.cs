using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Comanda
    {
        public int IdComanda { get; set; }
        public string NombreCliente { get; set; }

        public Mesa Mesa { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}
