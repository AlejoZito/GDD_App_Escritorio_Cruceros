using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.DAL.Domain
{
    public class Reserva
    {
        public int Cod_Reserva { get; set; }

        public decimal Precio { get; set; }

        public DateTime Fecha_Reserva { get; set; }

        public Cabina Cabina { get; set; }

        public Cliente Cliente { get; set; }

        public EstadoReserva Estado { get; set; }

        public RutaDeViaje Ruta { get; set; }
    }
}
