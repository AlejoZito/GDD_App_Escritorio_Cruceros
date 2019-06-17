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
            : base()
        {
            

            _OnClickAdd = () => Program.Navigation.PopUpPage(new Form_Crucero_Add(
                    onAddSuccess: (c) => this.OnAddOrEditSuccess()));

            _OnClickEdit = (id) => Program.Navigation.PopUpPage(new Form_Crucero_Edit(
                    onEditSuccess: (c) => this.OnAddOrEditSuccess(),
                    idCrucero: id));

            _OnClickDelete = (id) => BajaCrucero(id);

            _OnTableItemSelected = SeleccionarCrucero;

            Filters = new FiltersViewModel(new List<KeyValuePair<int, string>>() { },
                buttonA: new FilterButton("Mantenimiento", AbrirMantenimiento));
        }

        private void BajaCrucero(int id)
        {
            List<RutaDeViaje> viajesFuturosCrucero = RutaDeViajeDAO.GetAllByIDCrucero(id);
            if (viajesFuturosCrucero.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(String.Format("Hay {0} viajes programados con este crucero. ¿Desea reemplazar el crucero de estos viajes? Si selecciona \"No\" se anularán.", viajesFuturosCrucero.Count), "Baja de crucero", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    Program.Navigation.PopUpPage(new Form_Mantenimiento(_IdCruceroSeleccionado));
                }
                else if (dialogResult == DialogResult.No)
                {
                    //CruceroDAO.CancelarViajes(id);
                    //CruceroDAO.Delete(id);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("No hay viajes futuros programados con este crucero, por lo que puede ser dado de baja de manera directa. ¿Confirma que desea continuar?", "Baja de crucero", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    //CruceroDAO.Delete(id);
                    MessageBox.Show("El crucero fue dado de baja", "Baja de crucero", MessageBoxButtons.OK);
                }
            }

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
