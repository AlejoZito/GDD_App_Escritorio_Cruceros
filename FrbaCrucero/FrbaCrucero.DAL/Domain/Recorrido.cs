using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Recorrido
    {
        public int Cod_Recorrido { get; set; }

        public bool Activo { get; set; }

        public IList<Tramo> Tramos { get; set; }
    }
}
