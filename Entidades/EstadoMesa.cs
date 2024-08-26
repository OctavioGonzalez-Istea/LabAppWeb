using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class EstadoMesa : Mesa
    {
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        
        public List<Mesa> Mesas { get; set; }
    }
}
