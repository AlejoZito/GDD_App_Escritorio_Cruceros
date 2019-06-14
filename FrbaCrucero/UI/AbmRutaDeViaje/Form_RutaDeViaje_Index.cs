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

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_RutaDeViaje_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idRecorrido: id));

            _OnClickDelete = (id) => System.Windows.Forms.MessageBox.Show("Borrando el id: " + id);

            Filters = new FiltersViewModel(
                CruceroDAO.GetAll().Select(x=> new KeyValuePair<int,string>(x.Cod_Crucero, x.Identificador)).ToList(),
                "Ingrese un ID de ruta de viaje",
                "Ingrese un identificador de crucero",
                "Seleccione un crucero");
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
        }

        protected override List<RutaDeViajeViewModel> GetData()
        {
            return (new RutaDeViajeDAO()).GetAllWithFilters(
                this.Filters.LikeFilter,
                this.Filters.ExactFilter,
                this.Filters.DropdownFilterSelectedOption
                ).Select(x => new RutaDeViajeViewModel(x)).ToList();
        }
    }
}
