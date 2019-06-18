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
        PagoViewModel _ViewModel;

        public Form_PagoReserva()
        {
            InitializeComponent();
            _ViewModel = new PagoViewModel();
            BindViewModel();
            LoadDropdowns();
        }

        private void BindViewModel()
        {
            dropdownMediosDePago.Input.DataBindings.Add("SelectedValue", _ViewModel, "IDMedioDePago", true, DataSourceUpdateMode.OnPropertyChanged);
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
    }
}
