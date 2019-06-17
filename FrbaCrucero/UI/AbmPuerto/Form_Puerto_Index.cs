using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.UI.AbmPuerto
{
    class Form_Puerto_Index : Form_Base_Index<PuertoViewModel, Puerto>
    {
        public Form_Puerto_Index()
            : base()
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new AltaPuerto());
                    //onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            //_OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Recorrido_Edit(
            //        onEditSuccess: (c) => this.OnAddOrEditSuccess(),
            //        idRecorrido: id));

            _OnClickDelete = (id) => System.Windows.Forms.MessageBox.Show("Borrando el id: " + id);
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
        }

        protected override List<PuertoViewModel> GetData()
        {
            return PuertoDAO.GetAllWithFilters("Abu", null, null).Select(x => new PuertoViewModel(x)).ToList();
        }
    }
}
