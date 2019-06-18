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

namespace FrbaCrucero.UI.CompraReservaPasaje
{
    public partial class Form_PagoReserva : Form
    {
        PagoReservaViewModel _ViewModel;

        public Form_PagoReserva()
        {
            InitializeComponent();
            _ViewModel = new PagoReservaViewModel();
            BindViewModel();
            LoadDropdowns();
        }

        private void BindViewModel()
        {
            dropdownMediosDePago.Input.DataBindings.Add("SelectedValue", _ViewModel, "IDMedioDePago", true, DataSourceUpdateMode.OnPropertyChanged);
            tbNombre.DataBindings.Add("Text", _ViewModel, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            tbApellido.DataBindings.Add("Text", _ViewModel, "Apellido", true, DataSourceUpdateMode.OnPropertyChanged);
            tbPuertoDesde.DataBindings.Add("Text", _ViewModel, "PuertoDesde", true, DataSourceUpdateMode.OnPropertyChanged);
            tbPuertoHasta.DataBindings.Add("Text", _ViewModel, "PuertoHasta", true, DataSourceUpdateMode.OnPropertyChanged);
            tbFechaSalida.DataBindings.Add("Text", _ViewModel, "FechaSalida", true, DataSourceUpdateMode.OnPropertyChanged);
            tbPrecio.DataBindings.Add("Text", _ViewModel, "Precio", true, DataSourceUpdateMode.OnPropertyChanged);
            tbIdReserva.DataBindings.Add("Text", _ViewModel, "IDReserva", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadDropdowns()
        {
            dropdownMediosDePago.Input.DataSource = (new MedioDePagoDAO()).GetAll();
            dropdownMediosDePago.Input.DisplayMember = "Descripcion";
            dropdownMediosDePago.Input.ValueMember = "Cod_Medio_De_Pago";
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                _ViewModel.BuscarReserva();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reserva no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
