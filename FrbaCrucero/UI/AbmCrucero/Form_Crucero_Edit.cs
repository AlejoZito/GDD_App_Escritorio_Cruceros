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
            tbIdentificador.DataBindings.Add("Text", _ViewModel, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
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
            if (_ViewModel.IsValid())
            {
                _ViewModel.Edit();
                _OnEditSuccess(_ViewModel);
                this.Close();
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage, "Datos Incorrectos");
            }
        }
    }
}
