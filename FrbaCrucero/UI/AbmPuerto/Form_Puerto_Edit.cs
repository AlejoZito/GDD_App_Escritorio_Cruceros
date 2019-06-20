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

namespace FrbaCrucero.UI.AbmPuerto
{
    public partial class Form_Puerto_Edit : Form
    {
        PuertoViewModel _ViewModel;
        OnSuccessDelegate _OnEditSuccess;

        public Form_Puerto_Edit(
            OnSuccessDelegate onEditSuccess,
            int id)
        {
            InitializeComponent();
            _ViewModel = new PuertoViewModel(PuertoDAO.GetByID(id));
            BindViewModel();
            _OnEditSuccess = onEditSuccess;
        }

        private void BindViewModel()
        {
            NombreTextBox.DataBindings.Add("Text", _ViewModel, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            checkbox_activo.DataBindings.Add("Checked", _ViewModel, "Activo", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                try
                {
                    _ViewModel.Edit();
                    _OnEditSuccess();
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
