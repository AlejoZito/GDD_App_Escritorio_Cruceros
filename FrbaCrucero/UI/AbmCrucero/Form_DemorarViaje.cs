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
    public partial class Form_DemorarViaje : Form
    {
        OnSuccessDelegate _OnDemorarViajesSuccess;
        MantenimientoViewModel _ViewModel;

        public Form_DemorarViaje(MantenimientoViewModel vm, OnSuccessDelegate onDemorarViajesSuccess)
        {
            InitializeComponent();
            _ViewModel = vm;
            _OnDemorarViajesSuccess = onDemorarViajesSuccess;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _ViewModel.DemorarViajes((int)numericUpDown1.Value);
                this.Close();
                _OnDemorarViajesSuccess();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
