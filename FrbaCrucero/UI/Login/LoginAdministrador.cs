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
    public partial class LoginAdministrador : Form
    {
        public LoginAdministrador()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //aca van las validaciones y salio todo ok viene esto
            this.Close();
            Form_Main menu = new Form_Main();
            Program.MainMenu = menu;
            menu.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Program.Navigation.Show();
            this.Close();
        }
    }
}
