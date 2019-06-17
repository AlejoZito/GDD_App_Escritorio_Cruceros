using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace FrbaCrucero.BL.ViewModels
{
    public class CompraReservaPasajeViewModel : INotifyPropertyChanged
    {
        public CompraReservaPasajeViewModel()
        {
            Viajes = new BindingList<RutaDeViajeViewModel>();
            Cabinas = new BindingList<CabinaViewModel>();
            IdsCabinasSeleccionadas = new List<int>();
            Cliente = new ClienteViewModel();

            //TestData
            //FechaPartida = new DateTime(2018, 7, 6);
            //IdPuertoSalida = 23;
            //IdPuertoLlegada = 18;
            FechaPartida = new DateTime(2019, 07, 25);
            IdPuertoSalida = 23;
            IdPuertoLlegada = 10;
        }

        public DateTime? FechaPartida { get; set; }

        public int IdPuertoSalida { get; set; }

        public int IdPuertoLlegada { get; set; }

        int? _RutaDeViajeSeleccionada;
        public int? RutaDeViajeSeleccionada
        {
            get { return _RutaDeViajeSeleccionada; }
            set
            {
                _RutaDeViajeSeleccionada = value;
                //Al actualizar ruta de viaje, actualizar listado de cabinas
                BuscarCabinas();
                ActualizarMontoCalculado();
            }
        }

        public BindingList<RutaDeViajeViewModel> Viajes { get; set; }

        public BindingList<CabinaViewModel> Cabinas { get; set; }

        public List<int> IdsCabinasSeleccionadas { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public PagoViewModel MedioDePago { get; set; }

        decimal _Monto;
        public decimal Monto { 
            get { return _Monto; } 
            set { _Monto = value;
            InvokePropertyChanged(new PropertyChangedEventArgs("Monto"));
            }
        }

        private void ActualizarMontoCalculado()
        {
            decimal montoTotal = 0;
            decimal costoRuta = 0;
            if (RutaDeViajeSeleccionada.HasValue && Viajes.Count > 0)
                costoRuta = Viajes.FirstOrDefault(x => x.IdRutaDeViaje == _RutaDeViajeSeleccionada).CalcularCostoDeRuta();
            if (IdsCabinasSeleccionadas != null && IdsCabinasSeleccionadas.Count > 0)
            {
                foreach (var cabina in Cabinas.Where(x => IdsCabinasSeleccionadas.Contains(x.IdCabina)))
                {
                    montoTotal += cabina.PorcentajeRecargo * costoRuta;
                }
            }
            Monto = montoTotal;
        }

        /// <summary>
        /// Busca los viajes segun la fecha de partida, puerto de salida y de llegada,
        /// y rellena la lista Viajes asociada al listado de viajes.
        /// </summary>
        public void BuscarViajes()
        {
            try
            {
                Viajes.Clear();
                Cabinas.Clear();

                List<RutaDeViajeViewModel> viajes =
                    (new RutaDeViajeDAO()).GetByFiltersPasaje(FechaPartida, IdPuertoSalida, IdPuertoLlegada)
                    .Select(x => new RutaDeViajeViewModel(x)).ToList();

                foreach (var v in viajes)
                {
                    Viajes.Add(v);
                }
            }
            catch (Exception)
            {
                //ToDo Revisar manejo de errores
            }
        }

        private void BuscarCabinas()
        {
            try
            {
                Cabinas.Clear();

                if (_RutaDeViajeSeleccionada.HasValue)
                {
                    List<CabinaViewModel> cabinas =
                        CabinaDAO.GetByRutaDeViaje(_RutaDeViajeSeleccionada.Value)
                        .Select(x => new CabinaViewModel(x)).ToList();

                    foreach (var c in cabinas)
                    {
                        Cabinas.Add(c);
                    }
                }
            }
            catch (Exception)
            {
                //ToDo Revisar manejo de errores
            }
        }

        public bool IsValid()
        {
            return _RutaDeViajeSeleccionada.HasValue &&
                IdsCabinasSeleccionadas != null && IdsCabinasSeleccionadas.Count > 0 &&
                //MedioDePago != null && MedioDePago.IDMedioDePago != 0 &&
                Cliente != null && Cliente.IsValid();
        }

        public void ComprarPasaje()
        {
            if (IsValid())
            {
                foreach (var cabina in IdsCabinasSeleccionadas)
                {
                    PasajeDAO.ComprarPasaje(
                        cabina,
                        MedioDePago.IDMedioDePago,
                        RutaDeViajeSeleccionada.Value,
                        Cliente.Nombre,
                        Cliente.Apellido,
                        Cliente.DNI,
                        Cliente.Telefono,
                        Cliente.Direccion,
                        Cliente.Mail,
                        Cliente.FechaNacimiento);
                }
            }
        }

        public void SeleccionarCabinas(List<string> selectedValues)
        {
            foreach (string selectedValue in selectedValues)
            {
                var cabinaToAdd = this.Cabinas.FirstOrDefault(x => x.Descripcion == selectedValue);
                this.IdsCabinasSeleccionadas.Add(cabinaToAdd.IdCabina);                
            }
            ActualizarMontoCalculado();
        }


        #region Implementation of INotifyPropertyChanged

        /// <summary>
        /// Evento que se dispara cuando el valor de la propiedad cambia
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Llamar desde el setter de una propiedad para disparar el evento <see cref="PropertyChanged"/>
        /// </summary>
        /// <param name="e"></param>
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
