using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using FrbaCrucero.UI._Components;
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
            : base(showEditButton: false, showDeleteButton: false)
        {
            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_RutaDeViaje_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            //_OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_RutaDeViaje_Edit(
            //        onEditSuccess: (c) => this.OnAddOrEditSuccess(),
            //        idRecorrido: id));

            //_OnClickDelete = (id) => System.Windows.Forms.MessageBox.Show("Borrando el id: " + id);

            Filters = new FiltersViewModel(
                dropdownOptions: CruceroDAO.GetAll().Select(x => new KeyValuePair<int, string>(x.Cod_Crucero, x.Identificador)).ToList(),
                exactFilter: "Cód. de Ruta",
                likeFilter: "*",
                dropdownFilter: "Cruceros",
                filtro: new FilterButton("Entre Fechas", AbrirFiltroDeFechas));
        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
        }

        public void AbrirFiltroDeFechas()
        {
            Program.Navigation.PopUpPage(new Form_FechasEntre(
                (fechas, desc) => Filters.Button_Filtro_Seleccionar(fechas, desc)));
        }

        protected override List<RutaDeViajeViewModel> GetData()
        {
            return (new RutaDeViajeDAO()).GetAllWithFilters(
                this.Filters.LikeFilter,
                this.Filters.ExactFilter,
                this.Filters.DropdownFilterSelectedOption,
                (List<DateTime>)this.Filters.Button_Filtro_Seleccion
                ).Select(x => new RutaDeViajeViewModel(x)).ToList();
        }
    }
}
