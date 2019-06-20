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
    public class PagoReservaViewModel : INotifyPropertyChanged
    {
        string _PuertoDesde;
        public string PuertoDesde 
        { 
            get
            {
                return _PuertoDesde;
            }
            set
            {
                _PuertoDesde = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PuertoDesde"));
            }
        }

        string _PuertoHasta;
        public string PuertoHasta
        {
            get
            {
                return _PuertoHasta;
            }
            set
            {
                _PuertoHasta = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PuertoHasta"));
            }
        }

        decimal _Precio;
        public decimal Precio
        {
            get
            {
                return _Precio;
            }
            set
            {
                _Precio = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Precio"));
            }
        }

        string _Nombre;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Nombre"));
            }
        }

        string _Apellido;
        public string Apellido
        {
            get
            {
                return _Apellido;
            }
            set
            {
                _Apellido = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Apellido"));
            }
        }

        string _FechaSalida;
        public string FechaSalida
        {
            get
            {
                return _FechaSalida;
            }
            set
            {
                _FechaSalida = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FechaSalida"));
            }
        }

        public int IDMedioDePago { get; set; }

        public string IDReserva { get; set; }

        public void BuscarReserva()
        {
            MapFromDomainObject(PasajeDAO.GetReservaAPagarByID(this.IDReserva));
        }

        public string PagarReserva()
        {
            string codigoPasaje = PasajeDAO.PagarReserva(this.IDReserva, this.IDMedioDePago);
            return codigoPasaje;
        }

        public void MapFromDomainObject(ReservaAPagar o)
        {
            this.PuertoDesde = o.PuertoDesde;
            this.PuertoHasta = o.PuertoHasta;
            this.Precio = o.Precio;
            this.Nombre = o.Nombre;
            this.Apellido = o.Apellido;
            this.FechaSalida = o.FechaSalida;
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
