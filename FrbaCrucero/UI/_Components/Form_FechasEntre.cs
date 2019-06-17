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

namespace FrbaCrucero.UI._Components
{
    public partial class Form_FechasEntre : Form
    {
        FiltroComodinSeleccionarDelegate _OnButtonClick;
        public Form_FechasEntre(
            FiltroComodinSeleccionarDelegate onButtonClick)
        {
            InitializeComponent();
            _OnButtonClick = onButtonClick;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {            
            _OnButtonClick(
                new List<DateTime>(){datePickerDesde.Input.Value,datePickerHasta.Input.Value},
                datePickerDesde.Input.Value.ToString() + " - " + datePickerHasta.Input.Value.ToString());
            this.Close();
        }
    }
}
