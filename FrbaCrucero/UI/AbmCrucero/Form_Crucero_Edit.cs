using FrbaCrucero.BL;
using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.AbmCrucero
{
    public partial class Form_Crucero_Edit : Form
    {
        OnEditSuccessDelegate<CruceroViewModel> _OnEditSuccess;
        CruceroViewModel _ViewModel;

        public Form_Crucero_Edit(OnEditSuccessDelegate<CruceroViewModel> onEditSuccess, int idCrucero)
        {            
            InitializeComponent();
            LoadDropdowns();

            _OnEditSuccess = onEditSuccess;
            _ViewModel = new CruceroViewModel();
            //Obtengo object de la base y lo mapeo al viewmodel
            var crucero = CruceroDAO.GetByID(idCrucero);
            _ViewModel.MapFromDomainObject(crucero);
            //Bindeo el viewmodel a los inputs
            BindViewModel();
        }

        private void BindViewModel()
        {
            dropdownFabricante.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdFabricante", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownModelo.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdModelo", true, DataSourceUpdateMode.OnPropertyChanged);
            listviewCabinas.SetDataBinding(_ViewModel.Cabinas, "Descripcion");
        }

        private void LoadDropdowns()
        {
            dropdownFabricante.Input.DataSource = FabricanteDAO.GetAll();
            dropdownFabricante.Input.DisplayMember = "Detalle";
            dropdownFabricante.Input.ValueMember = "Cod_Fabricante";

            dropdownModelo.Input.DataSource = ModeloCruceroDAO.GetAll();
            dropdownModelo.Input.DisplayMember = "Detalle";
            dropdownModelo.Input.ValueMember = "Cod_Modelo";
        }

        private void btnCrucerEdit_Click(object sender, EventArgs e)
        {
            CruceroDAO.Edit(_ViewModel.MapToDomainObject());
            _OnEditSuccess(_ViewModel);
            this.Close();
        }

        private void btn_add_cabina_Click(object sender, EventArgs e)
        {
            Program.Navigation.PopUpPage(new Form_Cabina_Add(
                onAddSuccess: (cabina) => _ViewModel.Cabinas.Add(cabina)));
        }

        private void btn_delete_cabina_Click(object sender, EventArgs e)
        {
            if (listviewCabinas.SelectedItems == null || listviewCabinas.SelectedItems.Count == 0)
            {
            }
            else
            {
                foreach (ListViewItem listItem in listviewCabinas.SelectedItems)
                {
                    var cabinaToRemove = _ViewModel.Cabinas.FirstOrDefault(x => x.Descripcion == listItem.Text);
                    _ViewModel.Cabinas.Remove(cabinaToRemove);
                }
            }
        }
    }
}
