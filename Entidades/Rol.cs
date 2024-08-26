using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Rol : Empleado
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }

      
        public List<Empleado> Empleados { get; set; }
    }
}
