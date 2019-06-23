using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using FrbaCrucero.UI.AbmPuerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.AbmRecorrido
{
    public class Form_Recorrido_Index : FrbaCrucero.UI.Form_Base_Index<RecorridoViewModel, Recorrido>
    {
        public Form_Recorrido_Index()
            : base(title: "Recorridos")
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_Recorrido_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Recorrido_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idRecorrido: id));

            _OnClickDelete = (id) => HandleDelete(id);

            Filters = new FiltersViewModel(
                PuertoDAO.GetAll().Select(x=> new KeyValuePair<int, string>(x.Cod_Puerto, x.Nombre)).ToList(),
                exactFilter: "Cód. de Recorrido",
                likeFilter: "Puerto Desde/Hasta *",
                dropdownFilter: "Puerto Desde/Hasta");
        }

        private void HandleDelete(int id)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el puerto?", "Eliminar", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    RecorridoDAO.Delete(id);
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

        protected override List<RecorridoViewModel> GetData()
        {
            return RecorridoDAO.GetAllWithFilters(
                this.Filters.LikeFilter,
                this.Filters.ExactFilter).Select(x => new RecorridoViewModel(x)).ToList();
        }
    }
}
