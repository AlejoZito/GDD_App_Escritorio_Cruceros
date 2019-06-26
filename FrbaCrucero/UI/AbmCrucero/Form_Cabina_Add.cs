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
    public partial class Form_Cabina_Add : Form
    {
        CabinaViewModel _ViewModel;
        OnAddSuccessDelegate<CabinaViewModel> _OnAddSuccess;
        public Form_Cabina_Add(OnAddSuccessDelegate<CabinaViewModel> onAddSuccess)
        {
            InitializeComponent();
            _OnAddSuccess = onAddSuccess;
            LoadDropdowns();

            _ViewModel = new CabinaViewModel();
            BindViewModel();
        }

        private void BindViewModel()
        {
            inputNumero.Input.DataBindings.Add("Text", _ViewModel, "Numero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputPiso.Input.DataBindings.Add("Text", _ViewModel, "Piso", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownTipo.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdTipo", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void LoadDropdowns()
        {
            dropdownTipo.Input.DataSource = TipoCabinaDAO.GetAll();
            dropdownTipo.Input.DisplayMember = "Detalle";
            dropdownTipo.Input.ValueMember = "Cod_Tipo";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                _OnAddSuccess(_ViewModel);
                this.Close();
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage, "Datos Incorrectos");
            }
        }
    }
}
