using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Mesa : Comanda
    {
        public int IdMesa { get; set; }
        public string Nombre { get; set; }

       
        public EstadoMesa Estado { get; set; }
        public List<Comanda> Comandas { get; set; }
    }
}
