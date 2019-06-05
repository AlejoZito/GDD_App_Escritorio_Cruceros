using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Tramo
    {
        public Recorrido Recorrido { get; set; }

        public Puerto Puerto_Desde { get; set; }

        public Puerto Puerto_Hasta { get; set; }

        public decimal Precio { get; set; }

        public int Orden { get; set; }
    }
}
