using FrbaCrucero.BL.Attributes;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class RolViewModel: ViewModel<Rol>
    {
        public RolViewModel()
        {
            Permisos = new BindingList<PermisoViewModel>();
        }

        public RolViewModel(Rol r)
        {
            MapFromDomainObject(r);
        }

        [Listable(description: "Id")]
        public int IdRol { get; set; }

        [Listable(description: "Nombre")]
        public string Nombre { get; set; }

        [Listable(description: "Activo")]
        public bool Activo { get; set; }

        [Listable(description: "Cantidad de Permisos")]
        public int CantidadPermisos { get { return Permisos.Count; } }

        public BindingList<PermisoViewModel> Permisos { get; set; }

        public override Rol MapToDomainObject()
        {
            throw new NotImplementedException();
        }

        public override void MapFromDomainObject(Rol o)
        {
            this.IdRol = o.Cod_rol;
            this.Activo = o.Activo;
            this.Nombre = o.Nombre;
            this.Permisos = new BindingList<PermisoViewModel>();
            foreach(var p in o.Permisos){
                this.Permisos.Add(new PermisoViewModel(p));
            }
        }
    }
}
