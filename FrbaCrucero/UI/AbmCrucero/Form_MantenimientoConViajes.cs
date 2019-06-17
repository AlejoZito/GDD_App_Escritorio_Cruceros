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

namespace FrbaCrucero.UI.AbmCrucero
{
    public partial class Form_MantenimientoConViajes : Form
    {
        MantenimientoViewModel _ViewModel;
        OnSuccessDelegate _OnDemorarViajesSuccess;
        OnSuccessDelegate _OnCancelarViajesSuccess;

        public Form_MantenimientoConViajes(
            MantenimientoViewModel vm,
            OnSuccessDelegate onDemorarViajesSuccess,
            OnSuccessDelegate onCancelarViajesSuccess)
        {
            InitializeComponent();
            _ViewModel = vm;
            _OnDemorarViajesSuccess = onDemorarViajesSuccess;
            _OnCancelarViajesSuccess = onCancelarViajesSuccess;
        }

        private void buttonDemorar_Click(object sender, EventArgs e)
        {

            Program.Navigation.PopUpPage(new Form_DemorarViaje(
                vm: this._ViewModel,
                onDemorarViajesSuccess: () => {
                    _OnDemorarViajesSuccess();
                    this.Close();
                }
            ));


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            _ViewModel.CancelarViajes();
            _OnCancelarViajesSuccess();
            this.Close();
        }
    }
}
