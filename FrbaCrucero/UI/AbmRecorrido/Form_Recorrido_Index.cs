using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using FrbaCrucero.UI.AbmPuerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.UI.AbmRecorrido
{
    public class Form_Recorrido_Index : FrbaCrucero.UI.Form_Base_Index<RecorridoViewModel, Recorrido>
    {
        public Form_Recorrido_Index()
            : base()
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_Recorrido_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Recorrido_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idRecorrido: id));

            _OnClickDelete = (id) => System.Windows.Forms.MessageBox.Show("Borrando el id: " + id);

            Filters = new FiltersViewModel(
                new List<KeyValuePair<int, string>>() { },
                exactFilter: "Cód. de Recorrido",
                likeFilter: "Puerto Desde/Hasta");
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
