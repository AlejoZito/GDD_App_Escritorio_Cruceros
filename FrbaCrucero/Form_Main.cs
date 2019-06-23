using FrbaCrucero.DAL.Domain;
using FrbaCrucero.DAL.Enums;
using FrbaCrucero.UI.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class Form_Main : Form
    {
        private readonly List<KeyValuePair<string, Form>> _PageCache;
        private readonly List<KeyValuePair<string, Form>> _NavigationStack;

        public Form_Main()
        {
            _PageCache = new List<KeyValuePair<string, Form>>();
            _NavigationStack = new List<KeyValuePair<string, Form>>();
            InitializeComponent();
            LoadPermisos();

            this.labelUsername.DataBindings.Add("Text", Program.UsuarioLoggeado, "Username", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void LoadPermisos()
        {
            if (Program.UsuarioLoggeado != null && Program.UsuarioLoggeado.Roles != null)
            {
                List<Permiso> permisosRoles = new List<Permiso>();
                var roles = Program.UsuarioLoggeado.Roles;

                foreach (var rol in roles)
                {
                    foreach (var permiso in rol.Permisos)
                    {
                        if (!permisosRoles.Any(p => p.Cod_Permiso == permiso.Cod_Permiso))
                        {
                            permisosRoles.Add(permiso);
                            MostrarBoton(permiso.Cod_Permiso);
                        }
                    }
                }
            }
            else
            {
                btnRoles.Visible = false;
                btnPuertos.Visible = false;
                btnRecorridos.Visible = false;
                btnCruceros.Visible = false;
                btnEstadisticas.Visible = false;
                btnRutasViaje.Visible = false;
            }
        }

        private void MostrarBoton(int idPermiso)
        {
            switch (idPermiso)
            {
                case (int)CodigoPermiso.ABM_ROL:
                    btnRoles.Visible = true;
                    break;
                case (int)CodigoPermiso.ABM_PUERTO:
                    btnPuertos.Visible = true;
                    break;
                case (int)CodigoPermiso.ABM_RECORRIDO:
                    btnRecorridos.Visible = true;
                    break;
                case (int)CodigoPermiso.ABM_CRUCERO:
                    btnCruceros.Visible = true;
                    break;
                case (int)CodigoPermiso.LISTADO_ESTADISTICO:
                    btnEstadisticas.Visible = true;
                    break;
                case (int)CodigoPermiso.GENERAR_VIAJE:
                    btnRutasViaje.Visible = true;
                    break;
                case (int)CodigoPermiso.PAGO_RESERVA:
                case (int)CodigoPermiso.GESTIONAR_PASAJE:
                default:
                    break;
            }
        }

        public void GoToPage(Form page, bool cachePage = true)
        {
            KeyValuePair<string, Form> newPage = new KeyValuePair<string, Form>(page.GetType().Name, page);

            //Si cachePage == true, revisar las paginas abiertas y usarla si existe.
            //Si no existe en el cache, almacenarla.
            if (cachePage == true)
            {
                if (_PageCache.Any(x => x.Key == newPage.Key))
                {
                    //La página ya fue abierta, utilizar la que ya está en memoria
                    newPage = _PageCache.FirstOrDefault(x => x.Key == newPage.Key);
                }
                else
                {
                    _PageCache.Add(newPage);
                }
            }

            newPage.Value.TopLevel = false;
            SetPageInContainer(newPage);
            
            //add item to navigation stack (used when going to previous page)
            _NavigationStack.Add(newPage);

            newPage.Value.Show();
        }        

        public void PopUpPage(Form page)
        {
            page.StartPosition = FormStartPosition.CenterParent;
            page.ShowDialog();
        }

        private void SetPageInContainer(KeyValuePair<string, Form> newPage)
        {
            Content.Controls.Clear();
            newPage.Value.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            newPage.Value.Dock = DockStyle.Fill;
            Content.Controls.Add(newPage.Value);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            LoginGeneral loginGeneral = new LoginGeneral();
            loginGeneral.TopLevel = false;
            Content.Controls.Add(loginGeneral);
            loginGeneral.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            loginGeneral.Dock = DockStyle.Fill;
            loginGeneral.Show();
        }

        private void MenuPrincipal_Shown(object sender, EventArgs e)
        {
            //this.UsernameLabel.Text = String.IsNullOrEmpty(Program.UsuarioLoggeado.Username) ? "Cliente" : Program.UsuarioLoggeado.Username;
        }

        private void button_CerrarSesion_Click(object sender, EventArgs e)
        {
            Program.UsuarioLoggeado.Desloguear();
            Program.Navigation.LoadPermisos();
            Program.Navigation.GoToPage(new LoginGeneral());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GoToPage(new UI.MenuPrincipal.Home(), cachePage: false);
        }

        private void btnPuertos_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmPuerto.Form_Puerto_Index());
        }

        private void btnRutasViaje_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmRutaDeViaje.Form_RutaDeViaje_Index());
        }

        private void btnCruceros_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmCrucero.Form_Crucero_Index());
        }

        private void btnRecorridos_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmRecorrido.Form_Recorrido_Index());
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmRol.Form_Rol_Index());
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.ListadoEstadistico.ListadoEstadistico(), cachePage: false);
        }

        public void ShowNavigationBar()
        {
            Nav_Panel.Visible = true;
        }

        public void HideNavigationBar()
        {
            Nav_Panel.Visible = false;
        }
    }
}
