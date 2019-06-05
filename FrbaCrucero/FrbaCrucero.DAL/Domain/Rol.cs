using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Domain
{
    public class Rol
    {
        public int Cod_rol { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public IList<Permiso> Permisos { get; set; }
    }
}
