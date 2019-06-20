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
            
            //obtengo el recorrido de la base y lo mapeo a un viewmodel
            _ViewModel = new RolViewModel(RolDAO.GetByID(idRol));

            //bindeo las propiedades del viewmodel a los controles
            BindViewModel();
        }
        private void BindViewModel()
        {
        }
    }
}
