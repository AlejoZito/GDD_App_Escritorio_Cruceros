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

namespace FrbaCrucero.UI.AbmRutaDeViaje
{
    public partial class Form_RutaDeViaje_Edit : Form
    {
        OnEditSuccessDelegate<RutaDeViajeViewModel> _OnEditSuccess;
        RutaDeViajeViewModel _ViewModel;

        public Form_RutaDeViaje_Edit(OnEditSuccessDelegate<RutaDeViajeViewModel> onEditSuccess, int idRecorrido)
        {
            InitializeComponent();

            _OnEditSuccess = onEditSuccess;
            
            //obtengo el recorrido de la base y lo mapeo a un viewmodel
            _ViewModel = new RutaDeViajeViewModel((new RutaDeViajeDAO()).GetByID(idRecorrido));

            //bindeo las propiedades del viewmodel a los controles
            BindViewModel();
        }
        private void BindViewModel()
        {
            checkbox_activo.DataBindings.Add("Checked", _ViewModel, "Activo", true, DataSourceUpdateMode.OnPropertyChanged);
            //listTramos.SetDataBinding(_ViewModel.Tramos, "Descripcion");
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            (new RutaDeViajeDAO()).Edit(_ViewModel.MapToDomainObject());
            _OnEditSuccess(_ViewModel);
            this.Close();
        }
    }
}
