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

namespace FrbaCrucero.UI.CompraReservaPasaje
{
    public partial class Form_CompraReserva : Form
    {
        private readonly CompraReservaPasajeViewModel _ViewModel;

        public Form_CompraReserva()
        {
            InitializeComponent();
            _ViewModel = new CompraReservaPasajeViewModel();
            BindControls();
            LoadDropDowns();
            PasajeDAO.ActualizarReservasVencidas();
        }

        private void BindControls()
        {
            datePickerDeparture.Input.DataBindings.Add("Value", _ViewModel, "FechaPartida", true, DataSourceUpdateMode.OnPropertyChanged);
            labelMonto.DataBindings.Add("Text", _ViewModel, "Monto", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoDesde.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdPuertoSalida", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoHasta.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdPuertoLlegada", true, DataSourceUpdateMode.OnPropertyChanged);

            listViewViajes.SetDataBinding(_ViewModel.Viajes, "Descripcion");

            listViewCabinas.SetDataBinding(_ViewModel.Cabinas, "Descripcion");

            //labelMonto.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Nombre", true, DataSourceUpdateMode.OnPropertyChanged);

            inputDni.Input.DataBindings.Add("Text", _ViewModel, "Cliente.DNI", true, DataSourceUpdateMode.OnPropertyChanged);
            inputNombre.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            inputApellido.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Apellido", true, DataSourceUpdateMode.OnPropertyChanged);
            inputDireccion.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Direccion", true, DataSourceUpdateMode.OnPropertyChanged);
            inputTelefono.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Telefono", true, DataSourceUpdateMode.OnPropertyChanged);
            inputEmail.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Mail", true, DataSourceUpdateMode.OnPropertyChanged);
            inputFechaNacimiento.Input.DataBindings.Add("Value", _ViewModel, "Cliente.FechaNacimiento", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadDropDowns()
        {
            dropdownPuertoDesde.Input.DataSource = PuertoDAO.GetAll();
            dropdownPuertoDesde.Input.DisplayMember = "Nombre";
            dropdownPuertoDesde.Input.ValueMember = "Cod_Puerto";

            dropdownPuertoHasta.Input.DataSource = PuertoDAO.GetAll();
            dropdownPuertoHasta.Input.DisplayMember = "Nombre";
            dropdownPuertoHasta.Input.ValueMember = "Cod_Puerto";
        }

        private void btnBuscarViajes_Click(object sender, EventArgs e)
        {
            _ViewModel.BuscarViajes();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {

            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                Program.Navigation.PopUpPage(new Form_Pago(
                    onSuccess: (pago) => _ViewModel.MedioDePago = pago));

                _ViewModel.ComprarPasaje();

                Program.Navigation.PopUpPage(new Form_PasajeExitoso());
            }
        }

        private void listViewViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewViajes.SelectedItems == null || listViewViajes.SelectedItems.Count == 0)
            {
                _ViewModel.RutaDeViajeSeleccionada = (int?)null;
            }
            else
            {
                var rutaSeleccionada = _ViewModel.Viajes.FirstOrDefault(x => x.Descripcion == listViewViajes.SelectedItems[0].Text);
                _ViewModel.RutaDeViajeSeleccionada = rutaSeleccionada.IdRutaDeViaje;
            }
        }

        private void listViewCabinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCabinas.SelectedItems == null || listViewCabinas.SelectedItems.Count == 0)
            {
                _ViewModel.IdsCabinasSeleccionadas.Clear();
            }
            else
            {
                List<string> selectedValues = new List<string>();
                foreach (ListViewItem listItem in listViewCabinas.SelectedItems)
                {
                    selectedValues.Add(listItem.Text);
                }
                _ViewModel.SeleccionarCabinas(selectedValues);
            }
        }
    }
}
