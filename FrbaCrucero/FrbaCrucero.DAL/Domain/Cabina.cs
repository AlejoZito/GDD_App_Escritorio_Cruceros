using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Cabina
    {
        public int Cod_Cabina { get; set; }

        public int Numero { get; set; }

        public int Piso { get; set; }

        public TipoCabina Tipo_Cabina { get; set; }

        public Crucero Crucero { get; set; }
    }
}
