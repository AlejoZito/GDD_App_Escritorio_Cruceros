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
            BindViewModel();
        }
        private void BindViewModel()
        {
        }
    }
}
