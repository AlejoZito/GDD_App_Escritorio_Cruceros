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
            if (String.IsNullOrEmpty(UsuarioTextBox.Text.Trim())|| String.IsNullOrEmpty(PasswordTextBox.Text.Trim()))
            {
                MessageBox.Show("Debes ingresar usuario y contraseña");
            }
            else 
            {
                //check a base de datos para ver si existe el usuario
                this.Close();
                Program.UsuarioLoggeado = new DAL.Domain.Usuario 
                {
                    Username = UsuarioTextBox.Text
                };

                MenuPrincipal menu = new MenuPrincipal();
                Program.Navigation.GoToPage(menu, false);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
