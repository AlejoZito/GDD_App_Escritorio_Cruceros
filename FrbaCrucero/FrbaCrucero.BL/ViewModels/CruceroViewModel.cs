using FrbaCrucero.BL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class CruceroViewModel : ViewModel
    {
        public CruceroViewModel(int idCrucero, string nombreCrucero, string abc, string def, bool habilitado)
        {
            IdCrucero = IdCrucero;
            NombreCrucero = nombreCrucero;
            _Abc = abc;
            Def = def;
            Habilitado = habilitado;
        }

        private int _IdCrucero;

        [Listable(description: "ID")]
        public int IdCrucero
        {
            get { return _IdCrucero; }
            set
            {
                _IdCrucero = value; 
                InvokePropertyChanged(new PropertyChangedEventArgs("IdCrucero"));
            }
        }

        private string _NombreCrucero;

        [Listable(description: "Nombre crucero")]
        public string NombreCrucero { 
            get { return _NombreCrucero; } 
            set
            {
                _NombreCrucero = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("NombreCrucero"));
            }
        }

        private string _Abc;

        [Listable(description: "Test 1")]
        public string Abc
        {
            get { return _Abc; }
            set
            {
                _Abc = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Abc"));
            }
        }

        //Prueba de propiedad que no deberia mostrarse en la tabla, sin atributo listable
        public string Def { get; set; }

        [Listable(description: "Habilitado")]
        public bool Habilitado { get; set; }
    }
}
