using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Domain
{
    public class ReservaAPagar
    {
        public string FechaSalida { get; set; }

        public string PuertoDesde { get; set; }

        public string PuertoHasta { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }
    }
}
