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
    public partial class Form_Permiso_Add : Form
    {
        OnAddSuccessDelegate<RolViewModel> _OnAddSuccess;
        RolViewModel _ViewModel;

        public Form_Permiso_Add(OnAddSuccessDelegate<RolViewModel> onAddSuccess)
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

        private void btnAgregarPermisos_Click(object sender, EventArgs e)
        {
            _OnAddSuccess(_ViewModel);
            this.Close();
        }

        private void BindViewModel()
        {
            listPermisos.SetDataBinding(_ViewModel.Permisos, "Nombre");
        }

        private void listPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPermisos.SelectedItems == null || listPermisos.SelectedItems.Count == 0)
            {
                _ViewModel.IdsPermisosSeleccionados.Clear();
            }
            else
            {
                List<string> selectedValues = new List<string>();
                foreach (ListViewItem listItem in listPermisos.SelectedItems)
                {
                    selectedValues.Add(listItem.Text);
                }

                _ViewModel.SeleccionarPermisos(selectedValues);
            }
        }
    }
}
