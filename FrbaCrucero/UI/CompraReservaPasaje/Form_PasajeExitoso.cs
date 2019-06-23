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
    public partial class Form_PasajeExitoso : Form
    {
        public Form_PasajeExitoso(string codigoPasaje)
        {
            InitializeComponent();
            LoadCodigoPasaje(codigoPasaje);
        }

        private void LoadCodigoPasaje(string codigoPasaje)
        {
            labelCodigo.Text = codigoPasaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.Navigation.GoToPage(new UI.MenuPrincipal.Home(), cachePage: false);
        }
    }
}
