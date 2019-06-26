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
    public class PuertoViewModel : ViewModel<Puerto>
    {
        public PuertoViewModel() { }

        public PuertoViewModel(Puerto p)
        {
            MapFromDomainObject(p);
        }

        int _IDPuerto;
        [Listable("ID")]
        public int IDPuerto
        {
            get { return _IDPuerto; }
            set
            {
                _IDPuerto = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("IDPuerto"));
            }
        }

        string _Nombre;
        [Listable("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                _Nombre = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Nombre"));
            }
        }

        [Listable("Activo")]
        public bool Activo { get; set; }

        public string ErrorMessage { get; set; }

        public override void MapFromDomainObject(Puerto o)
        {
            this.IDPuerto = o.Cod_Puerto;
            this.Nombre = o.Nombre;
            this.Activo = o.Activo;
        }

        public override Puerto MapToDomainObject()
        {
            return new Puerto()
            {
                Cod_Puerto = this.IDPuerto,
                Nombre = this.Nombre,
                Activo = this.Activo
            };
        }

        public void Add()
        {
            PuertoDAO.Add(this.MapToDomainObject());
        }

        public void Edit()
        {
            PuertoDAO.Edit(this.MapToDomainObject());
        }

        public bool IsValid()
        {
            ErrorMessage = "";

            if (string.IsNullOrWhiteSpace(Nombre))
                ErrorMessage += "Debe ingresar un nombre" + System.Environment.NewLine;

            return string.IsNullOrEmpty(ErrorMessage);
        }
    }
}
