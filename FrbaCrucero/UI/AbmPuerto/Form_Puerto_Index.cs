using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FrbaCrucero.UI.AbmPuerto
{
    class Form_Puerto_Index : Form_Base_Index<PuertoViewModel, Puerto>
    {
        public Form_Puerto_Index()
            : base(title: "Puertos")
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new AltaPuerto(
                onSuccess: OnAddOrEditSuccess));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Puerto_Edit(
                    onEditSuccess: () => this.OnAddOrEditSuccess(),
                    id: id));

            _OnClickDelete = (id) => HandleDelete(id);

            Filters = new FiltersViewModel(
                dropdownOptions: new List<KeyValuePair<int, string>>(){
                    new KeyValuePair<int, string>(2, " Activo "),
                    new KeyValuePair<int, string>(1, " Inactivo ")
                },
                exactFilter: "Cód. de Puerto",
                likeFilter: "Cód o Nombre *",
                dropdownFilter: "Estado");
        }

        private void HandleDelete(int id)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el puerto?", "Eliminar", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    PuertoDAO.Delete(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.PopulateDataGridView();
            }
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
        }

        protected override List<PuertoViewModel> GetData()
        {
            return PuertoDAO.GetAllWithFilters(Filters.LikeFilter, Filters.ExactFilter, Filters.DropdownFilterSelectedOption).Select(x => new PuertoViewModel(x)).ToList();
        }
    }
}
