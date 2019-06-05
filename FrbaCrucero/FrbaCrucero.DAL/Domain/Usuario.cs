using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Domain
{
    public class Usuario
    {
        public int Cod_Usuario { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Logins_Fallidos { get; set; }

        public DateTime Fecha_Inhabilitacion { get; set; }

        public IList<Rol> Roles { get; set; }
    }
}
