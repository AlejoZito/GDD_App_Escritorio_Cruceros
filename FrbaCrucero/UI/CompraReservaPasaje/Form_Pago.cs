using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.BL;
using FrbaCrucero.BL.ViewModels;

namespace FrbaCrucero.UI.CompraReservaPasaje
{
    public partial class Form_Pago : Form
    {
        OnAddSuccessDelegate<PagoViewModel> _OnSuccessDelegate;
        PagoViewModel _ViewModel;

        public Form_Pago(OnAddSuccessDelegate<PagoViewModel> onSuccess)
        {
            InitializeComponent();
            _OnSuccessDelegate = onSuccess;
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
            _OnSuccessDelegate(_ViewModel);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
