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
        [Listable(description: "ID")]
        public int IdCrucero { get; set; }

        [Listable(description: "Nombre crucero")]
        public string NombreCrucero { get; set; }

        [Listable(description: "Test 1")]
        public string Abc { get; set; }

        [Listable(description: "Test 2")]
        public string Def { get; set; }

        [Listable(description: "Habilitado")]
        public bool Habilitado { get; set; }
    }
}
