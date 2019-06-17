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

namespace FrbaCrucero.UI.AbmCrucero
{
    public partial class Form_Mantenimiento : Form
    {
        MantenimientoViewModel _ViewModel;
        public Form_Mantenimiento(int? idCrucero)
        {
            if (!idCrucero.HasValue || idCrucero == 0)
                throw new Exception("Primero debe seleccionar un crucero de la tabla");

            InitializeComponent();
            _ViewModel = new MantenimientoViewModel(idCrucero.Value);
            BindViewModel();
            _ViewModel.ActualizarMantenimientos(); //Traer mantenimientos del crucero de la base
        }

        private void BindViewModel()
        {
            //bindear inputs
            datePickerDesde.Input.DataBindings.Add("Value", _ViewModel, "FechaDesde", true, DataSourceUpdateMode.OnPropertyChanged);
            datePickerHasta.Input.DataBindings.Add("Value", _ViewModel, "FechaHasta", true, DataSourceUpdateMode.OnPropertyChanged);
            //bindear listview
            listMantenimientos.SetDataBinding(_ViewModel.Mantenimientos, "Descripcion");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_ViewModel.IsValid())
                {
                    _ViewModel.AgregarMantenimiento();
                }
                else
                {
                    MessageBox.Show(_ViewModel.ErrorMessage);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
