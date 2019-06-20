using FrbaCrucero.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void top5Recorridos_Click(object sender, EventArgs e)
        {
            int semestreSeleccionado = 0;
            int anioSeleccionado = 0;

            Program.Navigation.PopUpPage(
                new ListadoEstadistico_SemestreAnio(
                (semestre, anio) => {
                    semestreSeleccionado = semestre;
                    anioSeleccionado = anio;
                }));

            dataGridView1.DataSource = ReportesDAO.GetRecorridosConPasajesMasComprados(semestreSeleccionado, anioSeleccionado);
        }

        private void top5CruceroFueraDeServicio_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReportesDAO.GetCrucerosConMasDiasFueraDeServicio();
        }

        private void top5CrucerosSinVentas_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReportesDAO.GetCrucerosConMasCabinasLibresEnCadaViaje();
        }
    }
}
