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

namespace FrbaCrucero.UI.AbmPuerto
{
    public partial class Form_Puerto_Add : Form
    {
        PuertoViewModel _ViewModel;
        OnSuccessDelegate _OnAddSuccess;

        public Form_Puerto_Add(OnSuccessDelegate onSuccess)
        {
            InitializeComponent();
            _ViewModel = new PuertoViewModel();
            _OnAddSuccess = onSuccess;
            BindViewModel();
        }

        private void BindViewModel()
        {
            NombreTextBox.DataBindings.Add("Text", _ViewModel, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                try
                {
                    _ViewModel.Add();
                    _OnAddSuccess();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage, "Nombre Incorrecto");
            }
        }
    }
}
