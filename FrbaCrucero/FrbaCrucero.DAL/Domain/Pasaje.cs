using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Pasaje
    {
        public int Cod_Pasaje { get; set; }

        public decimal Precio { get; set; }

        public Cabina Cabina { get; set; }

        public Cliente Cliente { get; set; }

        public EstadoPasaje Estado { get; set; }

        public Pago Pago { get; set; }

        public RutaDeViaje Ruta { get; set; }
    }
}
