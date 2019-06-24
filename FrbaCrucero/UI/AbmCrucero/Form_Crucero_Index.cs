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

namespace FrbaCrucero.UI.AbmCrucero
{
    public class Form_Crucero_Index : FrbaCrucero.UI.Form_Base_Index<CruceroViewModel, Crucero>
    {
        public int _IdCruceroSeleccionado;

        public Form_Crucero_Index()
            : base(title: "Cruceros")
        {
            

            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_Crucero_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Crucero_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idCrucero: id));

            _OnClickDelete = (id) => BajaCrucero(id);

            _OnTableItemSelected = SeleccionarCrucero;

            Filters = new FiltersViewModel(
                FabricanteDAO.GetAll().Select(x=> new KeyValuePair<int,string>(x.Cod_Fabricante, x.Detalle)).ToList(),
                exactFilter: "Cód. Crucero", 
                likeFilter: "Modelo o Identificador *",
                dropdownFilter: "Fabricante",
                buttonA: new FilterButton("Mantenimiento", AbrirMantenimiento));
        }

        private void BajaCrucero(int id)
        {
            List<RutaDeViaje> viajesFuturosCrucero = RutaDeViajeDAO.GetAllByIDCrucero(id);
            if (viajesFuturosCrucero.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(String.Format("Hay {0} viajes programados con este crucero. ¿Desea reemplazar el crucero de estos viajes? \r\n\r\nSi selecciona \"NO\" los pasajes y reservas asociadas se cancelaran.", viajesFuturosCrucero.Count), "Baja de crucero", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    Program.Navigation.PopUpPage(new Form_ReemplazoCrucero(id, viajesFuturosCrucero));
                }
                else if (dialogResult == DialogResult.No)
                {
                    int rows = CruceroDAO.CancelarViajes(id);
                    //MessageBox.Show(String.Format("{0} pasajes fueron dados de baja satisfactoriamente", rows), "Baja de crucero", MessageBoxButtons.OK);
                    CruceroDAO.DeleteByID(id);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("No hay viajes futuros programados con este crucero, por lo que puede ser dado de baja de manera directa. ¿Confirma que desea continuar?", "Baja de crucero", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    CruceroDAO.DeleteByID (id);
                    MessageBox.Show("El crucero fue dado de baja", "Baja de crucero", MessageBoxButtons.OK);
                }
            }

            this.PopulateDataGridView();

        }

        public void OnAddOrEditSuccess()
        {
            this.PopulateDataGridView();
            //Program.Navigation.GoToPreviousPage();
        }

        protected override List<CruceroViewModel> GetData()
        {
            return CruceroDAO.GetAllWithFilters(Filters.LikeFilter, Filters.ExactFilter, Filters.DropdownFilterSelectedOption).Select(x=> new CruceroViewModel(x)).ToList();
        }

        public void SeleccionarCrucero(int id)
        {
            _IdCruceroSeleccionado = id;
        }

        public void AbrirMantenimiento()
        {
            try
            {
                Program.Navigation.PopUpPage(new Form_Mantenimiento(_IdCruceroSeleccionado));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
