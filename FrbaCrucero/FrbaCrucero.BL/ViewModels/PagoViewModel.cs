using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class PagoViewModel : ViewModel<MedioDePago>
    {
        public PagoViewModel() { }

        public PagoViewModel(MedioDePago o)
        {
            MapFromDomainObject(o);
        }

        public int IDMedioDePago { get; set; }

        public string MedioDePago { get; set; }

        public int Cuotas { get; set; }

        public override void MapFromDomainObject(MedioDePago o)
        {
            this.IDMedioDePago = o.Cod_Medio_De_Pago;
            this.MedioDePago = o.Medio_De_Pago;
            this.Cuotas = o.Cuotas;
        }

        public override MedioDePago MapToDomainObject()
        {
            return new MedioDePago()
            {
                Cod_Medio_De_Pago = this.IDMedioDePago,
                Medio_De_Pago = this.MedioDePago,
                Cuotas = this.Cuotas
            };
        }
    }
}
