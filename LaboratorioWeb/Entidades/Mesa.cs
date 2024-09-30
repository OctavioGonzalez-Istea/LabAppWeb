using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
public class Mesa
{
    public int MesaId { get; set; }
    public required string Nombre { get; set; }
    public int EstadoId { get; set; }

    public required EstadoMesa EstadoMesa { get; set; }
    public required ICollection<Comanda> Comandas { get; set; }
}

}
