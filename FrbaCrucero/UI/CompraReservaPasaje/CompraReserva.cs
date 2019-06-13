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

namespace FrbaCrucero.PagoReserva
{
    public partial class CompraReserva : Form
    {
        private readonly CompraReservaPasajeViewModel _ViewModel;

        public CompraReserva()
        {
            InitializeComponent();
            _ViewModel = new CompraReservaPasajeViewModel();
            BindControls();
            LoadDropDowns();
        }

        private void BindControls()
        {
            datePickerDeparture.Input.DataBindings.Add("Value", _ViewModel, "FechaPartida", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoDesde.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoHasta.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);

            listViewViajes.SetDataBinding(_ViewModel.Viajes, "Descripcion");
            
            listViewCabinas.SetDataBinding(_ViewModel.Cabinas, "Descripcion");

            inputDni.Input.DataBindings.Add("Text", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputNombre.Input.DataBindings.Add("Text", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputApellido.Input.DataBindings.Add("Text", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputDireccion.Input.DataBindings.Add("Text", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputTelefono.Input.DataBindings.Add("Text", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputEmail.Input.DataBindings.Add("Text", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            inputFechaNacimiento.Input.DataBindings.Add("Value", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadDropDowns()
        {
            dropdownPuertoDesde.Input.DataSource = (new PuertoDAO()).GetAll();
            dropdownPuertoDesde.Input.DisplayMember = "Nombre";
            dropdownPuertoDesde.Input.ValueMember = "Cod_Puerto";

            dropdownPuertoHasta.Input.DataSource = (new CruceroDAO()).GetAll();
            dropdownPuertoHasta.Input.DisplayMember = "Nombre";
            dropdownPuertoHasta.Input.ValueMember = "Cod_Puerto";
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

        }
    }
}
