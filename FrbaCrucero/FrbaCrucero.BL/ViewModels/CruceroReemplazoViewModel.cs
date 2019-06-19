using FrbaCrucero.DAL.Domain;
using FrbaCrucero.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FrbaCrucero.BL.ViewModels
{
    public class CruceroReemplazoViewModel : INotifyPropertyChanged
    {
        public CruceroReemplazoViewModel(int cruceroId)
        {
            
        }
        public BindingList<RutaDeViajeViewModel> Viajes { get; set; }
    }
}
