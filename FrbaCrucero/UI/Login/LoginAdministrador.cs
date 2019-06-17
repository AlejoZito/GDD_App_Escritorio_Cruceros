using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
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
                MessageBox.Show("Debes ingresar usuario y contraseña", "Error al Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                try
                {
                    var usuario = new Usuario
                    {
                        Username = UsuarioTextBox.Text,
                        Password = PasswordTextBox.Text
                    };

                    Program.UsuarioLoggeado = UsuarioDAO.AuthenticateUser(usuario);

                    this.Close();
                    MenuPrincipal menu = new MenuPrincipal();
                    PasajeDAO.ActualizarReservasVencidas();
                    Program.Navigation.GoToPage(menu, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
