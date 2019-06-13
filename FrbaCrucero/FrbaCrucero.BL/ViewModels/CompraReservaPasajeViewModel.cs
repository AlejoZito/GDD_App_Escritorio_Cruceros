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
        }

        public DateTime? FechaPartida { get; set; }

        public int IdPuertoSalida { get; set; }

        public int IdPuertoLlegado { get; set; }

        public BindingList<RutaDeViajeViewModel> Viajes { get; set; }

        public BindingList<CabinaViewModel> Cabinas { get; set; }

        public List<int> IdsCabinasSeleccionadas { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }
}
