using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Crucero
    {
        public int Cod_Crucero { get; set; }

        public string Identificador { get; set; }

        public Fabricante Fabricante { get; set; }

        public ModeloCrucero Modelo_Crucero { get; set; }

        public bool Activo { get; set; }
    }
}
