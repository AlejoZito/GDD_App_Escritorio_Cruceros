using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Pago
    {
        public int Cod_Pago { get; set; }

        public DateTime Fecha_Compra { get; set; }

        public MedioDePago Medio_De_Pago { get; set; }

        public int Cuotas { get; set; }
    }
}
