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
            try
            {
                if (UsuarioDAO.RolUsuarioAdministradorExistente())
                {
                    LoginAdministrador admForm = new LoginAdministrador();
                    admForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                    Program.Navigation.PopUpPage(admForm);
                }
                else
                {
                    MessageBox.Show("No existe usuario administrativo", "Error al Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Rol rolCliente = RolDAO.GetAllWithFilters("Cliente", null, null).FirstOrDefault();
            Program.UsuarioLoggeado.Roles = new List<Rol>();
            Program.UsuarioLoggeado.Roles.Add(rolCliente);
            Program.Navigation.GoToPage(new MenuPrincipal());
        }
    }
}
