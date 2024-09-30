using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sector
    {
        public int SectorId { get; set; }
        public required string Descripcion { get; set; }

        // Relación con Empleados
        public required List<Empleado> Empleados { get; set; }

        // Relación con Productos
        public required List<Producto> Productos { get; set; }
    }
}
