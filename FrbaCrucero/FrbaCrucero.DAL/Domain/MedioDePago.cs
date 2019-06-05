using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class MedioDePago
    {
        public int Cod_Medio_De_Pago { get; set; }

        public string Medio_De_Pago { get; set; }

        public int Cuotas_Permitidas { get; set; }
    }
}
