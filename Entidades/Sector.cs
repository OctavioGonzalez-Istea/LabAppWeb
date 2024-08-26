using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Sector : Empleado
    {
        public int IdSector { get; set; }
        public string Descripcion { get; set; }

        
        public List<Empleado> Empleados { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
