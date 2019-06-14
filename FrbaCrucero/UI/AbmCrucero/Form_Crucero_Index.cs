using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using FrbaCrucero.UI.AbmPuerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.UI.AbmCrucero
{
    public class Form_Crucero_Index : FrbaCrucero.UI.Form_Base_Index<CruceroViewModel, Crucero>
    {
        public Form_Crucero_Index()
            : base()
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_Crucero_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Crucero_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idCrucero: id));

            _OnClickDelete = (id) => System.Windows.Forms.MessageBox.Show("Borrando el id: " + id);
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
            //Program.Navigation.GoToPreviousPage();
        }

        protected override List<CruceroViewModel> GetData()
        {
            return CruceroDAO.GetAll().Select(x=> new CruceroViewModel(x)).ToList();
        }
    }
}
