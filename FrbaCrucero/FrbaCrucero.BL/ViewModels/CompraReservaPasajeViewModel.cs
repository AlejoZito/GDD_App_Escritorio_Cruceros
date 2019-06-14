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
    public class CompraReservaPasajeViewModel
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
            }
        }

        public BindingList<RutaDeViajeViewModel> Viajes { get; set; }

        public BindingList<CabinaViewModel> Cabinas { get; set; }

        public List<int> IdsCabinasSeleccionadas { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public PagoViewModel Pago { get; set; }

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
                        (new CabinaDAO()).GetByRutaDeViaje(_RutaDeViajeSeleccionada.Value)
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
            return true;
        }

        public void ComprarPasaje()
        {
            throw new NotImplementedException();
        }
    }
}
