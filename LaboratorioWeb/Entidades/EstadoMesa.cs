using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoMesa
    {
        [Key]
        public int EstadoId { get; set; }
        public required string Descripcion { get; set; }

        public ICollection<Mesa> Mesas { get; set; }


    }
}
