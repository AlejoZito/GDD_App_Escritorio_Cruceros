using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.UI.AbmRutaDeViaje
{
    class Form_RutaDeViaje_Index : Form_Base_Index<RutaDeViajeViewModel, RutaDeViaje>
    {
        public Form_RutaDeViaje_Index()
            : base()
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_RutaDeViaje_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => System.Windows.Forms.MessageBox.Show("WIP - casi esta terminado");
            //_OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_RutaDeViaje_Edit(
            //        onEditSuccess: (c) => this.OnAddOrEditSuccess(),
            //        idRecorrido: id));

            _OnClickDelete = (id) => System.Windows.Forms.MessageBox.Show("Borrando el id: " + id);
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
        }

        protected override List<RutaDeViajeViewModel> GetData()
        {
            return (new RutaDeViajeDAO()).GetAll().Select(x => new RutaDeViajeViewModel(x)).ToList();
        }
    }
}
