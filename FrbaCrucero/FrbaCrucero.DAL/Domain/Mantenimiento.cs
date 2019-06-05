using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Domain
{
    public class Mantenimiento
    {
        public int Cod_Mantenimiento { get; set; }

        public Crucero Crucero { get; set; }

        public DateTime Fecha_Desde { get; set; }

        public DateTime Fecha_Hasta { get; set; }
    }
}
