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
    public class RecorridoViewModel : ViewModel<Recorrido>
    {
        public RecorridoViewModel()
        {
            Tramos = new BindingList<TramoViewModel>();
        }

        public RecorridoViewModel(Recorrido r)
        {
            MapFromDomainObject(r);
        }

        [Listable(description: "Id")]
        public int IdRecorrido { get; set; }

        [Listable(description: "Activo")]
        public bool Activo { get; set; }

        [Listable(description: "Cantidad de tramos")]
        public int CantidadTramos { get { return Tramos.Count; } }

        public BindingList<TramoViewModel> Tramos { get; set; }

        [Listable(description: "Descripcion")]
        public string Descripcion
        {
            get
            {
                return "ID: " + IdRecorrido + " / Tramos: " + CantidadTramos;
            }
        }

        public override void MapFromDomainObject(Recorrido o)
        {
            this.IdRecorrido = o.Cod_Recorrido;
            this.Activo = o.Activo;
            this.Tramos = new BindingList<TramoViewModel>();
            foreach(var t in o.Tramos){
                this.Tramos.Add(new TramoViewModel(t));
            }
        }

        public override Recorrido MapToDomainObject()
        {
            return new Recorrido()
            {
                Cod_Recorrido = this.IdRecorrido,
                Activo = this.Activo,
                Tramos = this.Tramos.Select(t => t.MapToDomainObject()).ToList().OrderBy(x => x.Orden).ToList()
            };
        }

        public decimal CalcularCostoDeRecorrido()
        {
            if (Tramos != null && Tramos.Count > 0)
            {
                decimal costo = 0;
                foreach (var tramo in Tramos)
                    costo += tramo.Precio;
                return costo;
            }
            else
                return 0;
        }
    }
}
