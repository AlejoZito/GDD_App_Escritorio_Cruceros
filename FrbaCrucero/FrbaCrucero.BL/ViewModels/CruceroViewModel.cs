using FrbaCrucero.BL.Attributes;
using System;
using System.Collections.Generic;
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
            Abc = abc;
            Def = def;
            Habilitado = habilitado;
        }

        [Listable(description: "ID")]
        public int IdCrucero { get; set; }

        [Listable(description: "Nombre crucero")]
        public string NombreCrucero { get; set; }

        [Listable(description: "Test 1")]
        public string Abc { get; set; }

        //Prueba de propiedad que no deberia mostrarse en la tabla, sin atributo listable
        public string Def { get; set; }

        [Listable(description: "Habilitado")]
        public bool Habilitado { get; set; }
    }
}
