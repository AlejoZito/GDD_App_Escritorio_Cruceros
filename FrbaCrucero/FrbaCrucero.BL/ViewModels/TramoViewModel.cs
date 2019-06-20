using FrbaCrucero.DAL.DAO;
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
            PuertoDesde = new PuertoViewModel();
            PuertoHasta = new PuertoViewModel();
            MapFromDomainObject(t);
        }

        public int IDRecorrido { get; set; }
        public PuertoViewModel PuertoDesde { get; set; }
        //public int IDPuertoDesde { get; set; }
        public PuertoViewModel PuertoHasta { get; set; }
        //public int IDPuertoHasta { get; set; }
        public decimal Precio { get; set; }
        public int Orden { get; set; }
        public string ErrorMessage { get; set; }
        public string Descripcion
        {
            get { return string.Format("{0} - {1} ${2}", PuertoDesde.Nombre, PuertoHasta.Nombre, Precio); }
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
                //Puerto_Desde = new Puerto() { Cod_Puerto = this.IDPuertoDesde },
                //Puerto_Hasta = new Puerto() { Cod_Puerto = this.IDPuertoHasta },
                Puerto_Desde = PuertoDesde.MapToDomainObject(),
                Puerto_Hasta = PuertoHasta.MapToDomainObject(),
                Orden = this.Orden,
                Precio = this.Precio
            };
        }

        public bool IsValid()
        {
            ErrorMessage = "";
            if (PuertoDesde == null || PuertoDesde.IDPuerto == 0 || PuertoHasta == null || PuertoHasta.IDPuerto == 0)
            {
                ErrorMessage += "Debe elegir un puerto de origen y uno de destino. " + System.Environment.NewLine;
            }
            else
            {

                if (PuertoDesde.IDPuerto == PuertoHasta.IDPuerto)
                    ErrorMessage += "El puerto de origen no puede ser igual al puerto de destino. " + System.Environment.NewLine;
            }

            if (Precio <= 0)
                ErrorMessage += "Debe indicar un precio, mantener una empresa de cruceros no es gratis. " + System.Environment.NewLine;

            return ErrorMessage == "";
        }

        /// <summary>
        /// Como en el dropdown solo pude bindear los IDS, traer el resto de la data de puertos y guardarla
        /// en PuertoDesde y PuertoHasta
        /// </summary>
        public void CargarPuertos()
        {
            int puertoDesdeID = this.PuertoDesde.IDPuerto;
            int puertoHastaID = this.PuertoHasta.IDPuerto;

            PuertoDesde.MapFromDomainObject(PuertoDAO.GetByID(puertoDesdeID));
            PuertoHasta.MapFromDomainObject(PuertoDAO.GetByID(puertoHastaID));
        }
    }
}
