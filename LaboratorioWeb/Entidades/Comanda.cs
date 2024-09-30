using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
public class Comanda
{
    public int ComandaId { get; set; }
    public int MesaId { get; set; }
    public required string NombreCliente { get; set; }

    public required Mesa Mesa { get; set; }
    public required ICollection<Pedido> Pedidos { get; set; }
}

}
