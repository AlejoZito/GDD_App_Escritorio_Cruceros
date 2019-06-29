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

namespace FrbaCrucero.UI.AbmRol
{
    public partial class Form_Rol_Edit : Form
    {
        OnEditSuccessDelegate<RolViewModel> _OnEditSuccess;
        RolViewModel _ViewModel;

        public Form_Rol_Edit(OnEditSuccessDelegate<RolViewModel> onEditSuccess, int idRol)
        {
            InitializeComponent();

            _OnEditSuccess = onEditSuccess;
            
            //obtengo el rol de la base y lo mapeo a un viewmodel
            _ViewModel = new RolViewModel(RolDAO.GetByID(idRol));
            //inicializo la lista de seleccionados con sus respectivos ids
            _ViewModel.IdsPermisosSeleccionados = _ViewModel.Permisos.Select(p => p.IDPermiso).ToList();

            //bindeo las propiedades del viewmodel a los controles
            BindViewModel();
        }
        private void BindViewModel()
        {
            tbNombreRol.DataBindings.Add("Text", _ViewModel, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            checkbox_activo.DataBindings.Add("Checked", _ViewModel, "Activo", true, DataSourceUpdateMode.OnPropertyChanged);
            listPermisos.SetDataBinding(_ViewModel.Permisos, "Nombre");
        }

        private void btn_permisoDelete_Click(object sender, EventArgs e)
        {
            if (listPermisos.SelectedItems == null || listPermisos.SelectedItems.Count == 0)
            {
            }
            else
            {
                foreach (ListViewItem listItem in listPermisos.SelectedItems)
                {
                    var permisoToRemove = _ViewModel.Permisos.FirstOrDefault(x => x.Nombre == listItem.Text);
                    _ViewModel.Permisos.Remove(permisoToRemove);
                }
            }
        }

        private void btn_permisoAdd_Click(object sender, EventArgs e)
        {
            Program.Navigation.PopUpPage(new Form_Permiso_Add(
                    onAddSuccess: (rol) =>
                    {
                        var permisos = PermisoDAO.GetAll();

                        foreach (var idPermiso in rol.IdsPermisosSeleccionados)
                        {
                            if (_ViewModel.Permisos.FirstOrDefault(x => x.IDPermiso == idPermiso) == null)
                            {
                                _ViewModel.IdsPermisosSeleccionados.Add(idPermiso);
                                var permiso = permisos.FirstOrDefault(x => x.Cod_Permiso == idPermiso);
                                var permisoNuevo = new PermisoViewModel(permiso);
                                _ViewModel.Permisos.Add(permisoNuevo);
                            }
                        }
                    }));
        }

        private void btnRolEdit_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValidEdit())
            {
                try
                {
                    _ViewModel.Edit();
                    _OnEditSuccess(_ViewModel);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage);
            }
        }
    }
}
