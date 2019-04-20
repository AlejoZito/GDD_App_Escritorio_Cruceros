using FrbaCrucero;
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
    public partial class Form_Crucero_Edit : Form
    {
        string _IDCrucero;

        public Form_Crucero_Edit(string idCrucero)
        {
            InitializeComponent();

            _IDCrucero = idCrucero;
        }

        private void OnPageLoad(object sender, EventArgs e)
        {
            //Traer datos de la entidad desde la db usando el id pasado como parametro
            textBox_nombreCrucero.Text = _IDCrucero;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new Form_Crucero_Index());
        }
    }
}
