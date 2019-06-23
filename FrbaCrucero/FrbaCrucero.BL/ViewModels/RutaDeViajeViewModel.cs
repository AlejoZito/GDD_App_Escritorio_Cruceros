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
    public class RutaDeViajeViewModel : ViewModel<RutaDeViaje>
    {
        public RutaDeViajeViewModel()
        {
            CrucerosDisponibles = new BindingList<CruceroViewModel>();

            Fecha_Inicio = DateTime.Now;
            Fecha_Fin_Estimada = DateTime.Now.AddDays(10);
        }

        public RutaDeViajeViewModel(RutaDeViaje r)
        {
            CrucerosDisponibles = new BindingList<CruceroViewModel>();
            MapFromDomainObject(r);
            //BuscarCruceros();

            //Fecha_Inicio = DateTime.Now;
            //Fecha_Fin_Estimada = DateTime.Now.AddDays(10);
        }

        [Listable(description: "Id")]
        public int IdRutaDeViaje { get; set; }

        public int IdCrucero { get; set; }

        [Listable(description: "Crucero")]
        public string Crucero { get; set; }

        public int IdRecorrido { get; set; }

        [Listable(description: "Recorrido")]
        public string RecorridoDescripcion { get { return (Recorrido != null) ? Recorrido.Descripcion : ""; } }

        public RecorridoViewModel Recorrido { get; set; }

        DateTime? _FechaInicio;
        [Listable(description: "Fecha de inicio")]
        public DateTime? Fecha_Inicio
        {
            get { return _FechaInicio; }
            set
            {
                _FechaInicio = value;
                CrucerosDisponibles.Clear();
            }
        }

        [Listable(description: "Fecha de fin")]
        public DateTime? Fecha_Fin { get; set; }

        DateTime? _FechaFinEstimada;
        [Listable(description: "Fecha de fin estimada")]
        public DateTime? Fecha_Fin_Estimada
        {
            get { return _FechaFinEstimada; }
            set
            {
                _FechaFinEstimada = value;
                CrucerosDisponibles.Clear();
            }
        }

        /// <summary>
        /// Lista de cruceros disponibles para dropdown
        /// </summary>
        public BindingList<CruceroViewModel> CrucerosDisponibles { get; set; }

        public string Descripcion
        {
            get { return string.Format("{0} - {1} [{2}]", IdRutaDeViaje, Crucero, Fecha_Fin_Estimada); }
        }

        public override void MapFromDomainObject(RutaDeViaje o)
        {
            this.IdRutaDeViaje = o.Cod_Ruta;
            this.IdCrucero = o.Crucero.Cod_Crucero;
            this.Crucero = new CruceroViewModel(o.Crucero).Descripcion;
            this.IdRecorrido = o.Recorrido.Cod_Recorrido;
            this.Recorrido = new RecorridoViewModel(o.Recorrido);
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
                Fecha_Inicio = this.Fecha_Inicio.Value,
                Fecha_Fin = this.Fecha_Fin,
                Fecha_Fin_Estimada = this.Fecha_Fin_Estimada.Value
            };
        }

        public void BuscarCruceros()
        {
            CrucerosDisponibles.Clear();
            if (!Fecha_Inicio.HasValue || !Fecha_Fin_Estimada.HasValue)
                throw new Exception("Ingrese una fecha de inicio y una de fin estimada");
            else
            {
                List<Crucero> cruceros = CruceroDAO.GetAllByFechas(Fecha_Inicio, Fecha_Fin_Estimada);
                foreach (var crucero in cruceros)
                {
                    CrucerosDisponibles.Add(new CruceroViewModel(crucero));
                }
                //Seleccionar la primera opcion
                IdCrucero = (cruceros.Count > 0) ? cruceros[0].Cod_Crucero : 0;
            }
        }

        public bool IsValid()
        {
            ErrorMessage = "";

            if (IdCrucero == 0)
                ErrorMessage += "Debe seleccionar un crucero. " + System.Environment.NewLine;
            if(IdRecorrido == 0)
                ErrorMessage += "Debe seleccionar un recorrido. " + System.Environment.NewLine;
            if(Fecha_Inicio == null)
                ErrorMessage += "Debe ingresar una fecha de inicio. " + System.Environment.NewLine;
            //if (Fecha_Inicio.HasValue && Fecha_Inicio < DateTime.Now )
            //    ErrorMessage += "No puede ingresar una fecha de inicio anterior a la fecha actual. " + System.Environment.NewLine;
            if (_FechaFinEstimada == null)
                ErrorMessage += "Debe ingresar una fecha de finalizacion. " + System.Environment.NewLine;
            if((Fecha_Inicio.HasValue && Fecha_Fin_Estimada.HasValue) && Fecha_Fin_Estimada <= Fecha_Inicio)                
                ErrorMessage += "La fecha de fin estimada debe ser mayor a la fecha de inicio" + System.Environment.NewLine;

            //If error message is empty, object is valid
            return string.IsNullOrEmpty(ErrorMessage);
        }

        public string ErrorMessage { get; set; }

        public void Add()
        {
            (new RutaDeViajeDAO()).Add(this.MapToDomainObject());
        }

        public void Edit()
        {
            (new RutaDeViajeDAO()).Edit(this.MapToDomainObject());
        }

        public decimal CalcularCostoDeRuta()
        {
            if (IdRecorrido != 0)
            {
                RecorridoViewModel recorrido = new RecorridoViewModel(RecorridoDAO.GetByID(IdRecorrido));
                return recorrido.CalcularCostoDeRecorrido();
            }
            else
                return 0;
        }
    }
}
