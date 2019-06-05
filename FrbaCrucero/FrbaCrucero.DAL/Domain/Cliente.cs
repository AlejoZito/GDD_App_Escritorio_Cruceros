using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Domain
{
    public class Cliente
    {
        public int Cod_Cliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Mail { get; set; }

        public DateTime Fecha_Nac { get; set; }

        public IList<Pasaje> Pasajes { get; set; }

        public IList<Reserva> Reservas { get; set; }
    }
}
