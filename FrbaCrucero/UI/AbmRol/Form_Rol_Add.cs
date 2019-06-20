using FrbaCrucero.BL;
using FrbaCrucero.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.AbmRol
{
    public partial class Form_Rol_Add : Form
    {
        OnAddSuccessDelegate<RolViewModel> _OnAddSuccess;
        RolViewModel _ViewModel;

        public Form_Rol_Add(OnAddSuccessDelegate<RolViewModel> onAddSuccess)
        {
            InitializeComponent();

            _OnAddSuccess = onAddSuccess;
            _ViewModel = new RolViewModel();
            LoadPermisos();
            BindViewModel();
        }

        private void LoadPermisos()
        {
            _ViewModel.LoadPermisos();
        }
        private void BindViewModel()
        {
            tbNombre.DataBindings.Add("Text", _ViewModel, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            listViewPermisos.SetDataBinding(_ViewModel.Permisos, "Nombre");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                _ViewModel.Add();
                _OnAddSuccess(_ViewModel);
                this.Close();
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage);
            }
        }

        private void listViewPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPermisos.SelectedItems == null || listViewPermisos.SelectedItems.Count == 0)
            {
                _ViewModel.IdsPermisosSeleccionados.Clear();
            }
            else
            {
                List<string> selectedValues = new List<string>();
                foreach (ListViewItem listItem in listViewPermisos.SelectedItems)
                {
                    selectedValues.Add(listItem.Text);
                }
                _ViewModel.SeleccionarPermisos(selectedValues);
            }
        }
    }
}
