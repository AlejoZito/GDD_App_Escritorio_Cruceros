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
    public partial class Form_RutaDeViaje_Add : Form
    {
        OnAddSuccessDelegate<RutaDeViajeViewModel> _OnAddSuccess;
        RutaDeViajeViewModel _ViewModel;

        public Form_RutaDeViaje_Add(OnAddSuccessDelegate<RutaDeViajeViewModel> onAddSuccess)
        {
            InitializeComponent();
            LoadDropdowns();

            _OnAddSuccess = onAddSuccess;
            _ViewModel = new RutaDeViajeViewModel();
            BindViewModel();
        }

        private void BindViewModel()
        {            
            dropdownRecorrido.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdRecorrido", true, DataSourceUpdateMode.OnPropertyChanged);
            datepickerDesde.Input.DataBindings.Add("Value", _ViewModel, "Fecha_Inicio", true, DataSourceUpdateMode.OnPropertyChanged);
            datepickerEstimada.Input.DataBindings.Add("Value", _ViewModel, "Fecha_Fin_Estimada", true, DataSourceUpdateMode.OnPropertyChanged);

            dropdownCrucero.Input.DataSource = _ViewModel.CrucerosDisponibles;
            dropdownCrucero.Input.DisplayMember = "Descripcion";
            dropdownCrucero.Input.ValueMember = "IdCrucero";
            dropdownCrucero.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadDropdowns()
        {
            dropdownRecorrido.Input.DataSource = RecorridoDAO.GetAll().Select(x => new RecorridoViewModel(x)).ToList();
            dropdownRecorrido.Input.DisplayMember = "Descripcion";
            dropdownRecorrido.Input.ValueMember = "IdRecorrido";
        }

        private void btnRecorridoAdd_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                try
                {
                    _ViewModel.Add();
                    _OnAddSuccess(_ViewModel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                this.Close();
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage, "Datos Incompletos");
            }
        }

        private void btnBuscarCruceros_Click(object sender, EventArgs e)
        {
            try
            {
                _ViewModel.BuscarCruceros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
