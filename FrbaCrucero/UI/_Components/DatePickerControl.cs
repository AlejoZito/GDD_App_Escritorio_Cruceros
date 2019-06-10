using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.Components
{
    public partial class DatePickerControl : UserControl
    {
        public DatePickerControl()
        {
            InitializeComponent();
        }


        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public DateTimePicker Input
        {
            get { return dateTimePicker1; }
        }

        public Label ValidationMessage
        {
            get { return validationError; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
