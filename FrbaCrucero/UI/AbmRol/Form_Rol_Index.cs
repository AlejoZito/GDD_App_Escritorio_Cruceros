using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using FrbaCrucero.UI.AbmRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.AbmRol
{
    public partial class Form_Rol_Index : FrbaCrucero.UI.Form_Base_Index<RolViewModel, Rol>
    {
        public Form_Rol_Index()
            : base()
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_Rol_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Rol_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idRol: id));

            _OnClickDelete = (id) => BajaRol(id);

            Filters = new FiltersViewModel(new List<KeyValuePair<int, string>>() { });
        }

        private void BajaRol(int id)
        {
            DialogResult dialogResult = MessageBox.Show(String.Format("¿Estás seguro que querés borrar el rol con id: {0}.?", id), "Baja de Rol", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RolDAO.Delete(id);
            }
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
        }

        protected override List<RolViewModel> GetData()
        {
            return RolDAO.GetAll().Select(x => new RolViewModel(x)).ToList();
        }
    }
}
