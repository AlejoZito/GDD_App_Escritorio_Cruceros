using FrbaCrucero.BL.ViewModels;
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

namespace FrbaCrucero.UI.AbmCrucero
{
    public partial class Form_ReemplazoCrucero : Form
    {
        private readonly CruceroReemplazoViewModel _ViewModel;

        public Form_ReemplazoCrucero(int cruceroID, List<RutaDeViaje> viajesFuturosCrucero)
        {
            InitializeComponent();
            _ViewModel = new CruceroReemplazoViewModel(cruceroID);
            listCrucerosReemplazo.SetDataBinding(_ViewModel.CrucerosReemplazo, "Descripcion"); 
        }

        private void Form_ReemplazoCrucero_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptarReemplazo_Click(object sender, EventArgs e)
        {
            RutaDeViajeDAO.ActualizarCrucero(_ViewModel.IDCruceroAReemplazar, _ViewModel.CrucerosReemplazo[listCrucerosReemplazo.SelectedIndices[0]].IDCrucero);
            CruceroDAO.DeleteByID(_ViewModel.IDCruceroAReemplazar);
            MessageBox.Show(String.Format("Crucero {0} ha tomado todos los viajes del crucero dado de baja.", _ViewModel.CrucerosReemplazo[listCrucerosReemplazo.SelectedIndices[0]].Identificador), "Baja de crucero", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
