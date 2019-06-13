using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class TramoViewModel : ViewModel<Tramo>
    {
        public TramoViewModel()
        {
            PuertoDesde = new PuertoViewModel();
            PuertoHasta = new PuertoViewModel();
        }

        public TramoViewModel(Tramo t)
        {
            MapFromDomainObject(t);
            PuertoDesde = new PuertoViewModel();
            PuertoHasta = new PuertoViewModel();
        }

        public int IDRecorrido { get; set; }
        PuertoViewModel _V;
        public PuertoViewModel PuertoDesde { 
            get { return _V; } 
            set { _V = value; } }
        public int IDPuertoDesde { get; set; }
        public PuertoViewModel PuertoHasta { get; set; }
        public int IDPuertoHasta { get; set; }
        public decimal Precio { get; set; }
        public int Orden { get; set; }

        public string Descripcion
        {
            get { return PuertoDesde.Nombre + PuertoHasta.Nombre + Orden + Precio; }
        }

        public override void MapFromDomainObject(Tramo o)
        {
            //this.IDRecorrido = o.Recorrido.Cod_Recorrido;
            //this.IDPuertoDesde = o.Puerto_Desde.Cod_Puerto;
            //this.IDPuertoHasta = o.Puerto_Hasta.Cod_Puerto;
            this.PuertoDesde = new PuertoViewModel(o.Puerto_Desde);
            this.PuertoHasta = new PuertoViewModel(o.Puerto_Hasta);
            this.Precio = o.Precio;
            this.Orden = o.Orden;
        }

        public override Tramo MapToDomainObject()
        {
            return new Tramo()
            {
                IdRecorrido = this.IDRecorrido,
                Puerto_Desde = new Puerto() { Cod_Puerto = this.IDPuertoDesde },
                Puerto_Hasta = new Puerto() { Cod_Puerto = this.IDPuertoHasta },
                Orden = this.Orden,
                Precio = this.Precio
            };
        }
    }
}
