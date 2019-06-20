using FrbaCrucero.BL.Attributes;
using FrbaCrucero.DAL.DAO;
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
            this.IdsPermisosSeleccionados = new List<int>();
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

        public List<int> IdsPermisosSeleccionados { get; set; }

        public override Rol MapToDomainObject()
        {
            var permisos = new List<Permiso>();

            foreach (var idPermiso in IdsPermisosSeleccionados)
            {
                var permiso = new Permiso
                {
                    Cod_Permiso = idPermiso
                };

                permisos.Add(permiso);
            }

            return new Rol
            {
                Activo = true,
                Nombre = this.Nombre,
                Permisos = permisos
            };
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

        public void LoadPermisos()
        {
            List<PermisoViewModel> permisos = PermisoDAO.GetAll().Select(x => new PermisoViewModel(x)).ToList();

            foreach (var permiso in permisos)
            {
                Permisos.Add(permiso);
            }
        }

        public bool IsValid()
        {
            ErrorMessage = "";

            if (string.IsNullOrWhiteSpace(Nombre))
                ErrorMessage += "Debes agregar un nombre al rol. " + System.Environment.NewLine;
            if (IdsPermisosSeleccionados == null || IdsPermisosSeleccionados.Count == 0)
                ErrorMessage += "Debes seleccionar algún permiso. " + System.Environment.NewLine;
            //If error message is empty, object is valid
            return string.IsNullOrEmpty(ErrorMessage);
        }

        public string ErrorMessage { get; set; }

        public void Add()
        {
            RolDAO.Add(MapToDomainObject());
        }

        public void SeleccionarPermisos(List<string> selectedValues)
        {
            this.IdsPermisosSeleccionados = new List<int>();

            foreach (string selectedValue in selectedValues)
            {
                var permisoToAdd = this.Permisos.FirstOrDefault(x => x.Nombre == selectedValue);
                this.IdsPermisosSeleccionados.Add(permisoToAdd.IDPermiso);
            }
        }
    }
}
