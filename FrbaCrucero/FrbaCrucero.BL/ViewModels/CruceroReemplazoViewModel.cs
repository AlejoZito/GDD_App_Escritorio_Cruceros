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
            this.IDCruceroAReemplazar = cruceroId;
            CrucerosReemplazo = new BindingList<CruceroReemplazoViewModel>();
            ActualizarReemplazos();
        }

        public CruceroReemplazoViewModel(Crucero c)
        {
            this.MapFromDomainObject(c);
        }

        public int IDCruceroAReemplazar { get; set; }
        public int IDCrucero { get; set; }
        public string Identificador { get; set; }

        public string Descripcion
        {
            get
            {
                return "ID: " + IDCrucero + " - " + Identificador;
            }
        }

        public BindingList<CruceroReemplazoViewModel> CrucerosReemplazo { get; set; }

        public void ActualizarReemplazos()
        {
            CrucerosReemplazo.Clear();

            List<Crucero> crucerosReemplazo = CruceroDAO.GetAllByCruceroReemplazo(this.IDCruceroAReemplazar);
            foreach (var c in crucerosReemplazo)
            {
                CruceroReemplazoViewModel asd = new CruceroReemplazoViewModel(c);
                CrucerosReemplazo.Add(asd);
            }
        }

        public void MapFromDomainObject(Crucero c)
        {
            this.IDCrucero = c.Cod_Crucero;
            this.Identificador = c.Identificador;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}
