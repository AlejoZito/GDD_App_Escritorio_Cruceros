using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class PermisoViewModel : ViewModel<Permiso>
    {
        public PermisoViewModel()
        {
        }

        public PermisoViewModel(Permiso p)
        {
            MapFromDomainObject(p);
        }

        public int IDPermiso { get; set; }

        public string Nombre { get; set; }

        public override Permiso MapToDomainObject()
        {
            throw new NotImplementedException();
        }

        public override void MapFromDomainObject(Permiso o)
        {
            this.IDPermiso = o.Cod_Permiso;
            this.Nombre = o.Nombre;
        }
    }
}
