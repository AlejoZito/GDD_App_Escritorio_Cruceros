using FrbaCrucero.DAL.Domain;
using FrbaCrucero.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.MenuPrincipal
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            LoadPermisos();
        }

        private void LoadPermisos()
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

        private void MostrarBoton(int idPermiso)
        {
            switch (idPermiso)
            {
                case (int)CodigoPermiso.ABM_ROL:
                    btnAbmRol.Visible = true;
                    break;
                case (int)CodigoPermiso.ABM_PUERTO:
                    button_AbmPuerto.Visible = true;
                    break;
                case (int)CodigoPermiso.ABM_RECORRIDO:
                    button_AbmRecorridos.Visible = true;
                    break;
                case (int)CodigoPermiso.ABM_CRUCERO:
                    button_AbmCruceros.Visible = true;
                    break;
                case (int)CodigoPermiso.GENERAR_VIAJE:
                    button_RutasDeViaje.Visible = true;
                    break;
                case (int)CodigoPermiso.GESTIONAR_PASAJE:
                    btnPasaje.Visible = true;
                    break;
                case (int)CodigoPermiso.PAGO_RESERVA:
                    btnPagarReserva.Visible = true;
                    break;
                case (int)CodigoPermiso.LISTADO_ESTADISTICO:
                    btnEstadisticas.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void button_AbmPuerto_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmPuerto.Form_Puerto_Index());
        }

        private void button_AbmCruceros_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmCrucero.Form_Crucero_Index());
        }

        private void button_AbmRecorridos_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmRecorrido.Form_Recorrido_Index());
        }

        private void button_RutasDeViaje_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmRutaDeViaje.Form_RutaDeViaje_Index());
        }

        private void btnPasaje_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.CompraReservaPasaje.Form_CompraReserva(), cachePage: false);
        }

        private void btnPagarReserva_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.CompraReservaPasaje.Form_PagoReserva(), cachePage: false);
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.AbmRol.Form_Rol_Index());
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Program.Navigation.GoToPage(new UI.ListadoEstadistico.ListadoEstadistico(), cachePage: false);
        }
    }
}
