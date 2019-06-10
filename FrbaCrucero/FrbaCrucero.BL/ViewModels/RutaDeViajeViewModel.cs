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
    public class RutaDeViajeViewModel : ViewModel<RutaDeViaje>
    {
        public RutaDeViajeViewModel()
        {
        }

        public RutaDeViajeViewModel(RutaDeViaje r)
        {
            MapFromDomainObject(r);
        }

        [Listable(description: "Id")]
        public int IdRutaDeViaje { get; set; }

        public int IdCrucero { get; set; }

        [Listable(description: "Crucero")]
        public string Crucero { get; set; }

        [Listable(description: "Crucero")]
        public int IdRecorrido { get; set; }

        [Listable(description: "Fecha de inicio")]
        public DateTime Fecha_Inicio { get; set; }

        [Listable(description: "Fecha de fin")]
        public DateTime? Fecha_Fin { get; set; }

        [Listable(description: "Fecha de fin estimada")]
        public DateTime Fecha_Fin_Estimada { get; set; }

        public override void MapFromDomainObject(RutaDeViaje o)
        {
            this.IdRutaDeViaje = o.Cod_Ruta;
            this.IdCrucero = o.Crucero.Cod_Crucero;
            this.Crucero = o.Crucero.Modelo_Crucero.Detalle;
            this.IdRecorrido = o.Recorrido.Cod_Recorrido;
            this.Fecha_Inicio = o.Fecha_Inicio;
            this.Fecha_Fin = o.Fecha_Fin;
            this.Fecha_Fin_Estimada = o.Fecha_Fin_Estimada;
        }

        public override RutaDeViaje MapToDomainObject()
        {
            return new RutaDeViaje()
            {
                Cod_Ruta = this.IdRutaDeViaje,
                Recorrido = new Recorrido() { Cod_Recorrido = this.IdRecorrido },
                Crucero = new Crucero() { Cod_Crucero = this.IdCrucero, Identificador = this.Crucero },
                Fecha_Inicio = this.Fecha_Inicio,
                Fecha_Fin = this.Fecha_Fin,
                Fecha_Fin_Estimada = this.Fecha_Fin_Estimada
            };
        }
    }
}
