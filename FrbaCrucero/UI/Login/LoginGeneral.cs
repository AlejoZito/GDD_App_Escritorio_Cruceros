using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.Login
{
    public partial class LoginGeneral : Form
    {
        public LoginGeneral()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            LoginAdministrador admForm = new LoginAdministrador();
            this.Hide();
            admForm.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (Program.MainMenu == null)
            {
                Program.MainMenu = new Form_Main();
            }

            this.Hide();
            Program.MainMenu.Show();
        }
    }
}
