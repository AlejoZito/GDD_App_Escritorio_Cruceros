using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class RutaDeViaje
    {
        public int Cod_Ruta { get; set; }

        public Crucero Crucero { get; set; }

        public Recorrido Recorrido { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime? Fecha_Fin { get; set; }

        public DateTime Fecha_Fin_Estimada { get; set; }
    }
}
