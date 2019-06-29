using FrbaCrucero.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.ListadoEstadistico
{
    public partial class ListadoEstadistico_SemestreAnio : Form
    {
        OnSelectSemestreAnioDelegate _OnSelect;
        public ListadoEstadistico_SemestreAnio(OnSelectSemestreAnioDelegate onSelect)
        {
            InitializeComponent();
            LoadDropDowns();
            _OnSelect = onSelect;
        }

        private void LoadDropDowns()
        {
            semestre.Items.Add(new KeyValuePair<int, string>(1, "1° semestre"));
            semestre.Items.Add(new KeyValuePair<int, string>(2, "2° semestre"));

            //semestre.DisplayMember = "Value";
            //semestre.ValueMember = "Key";

            int anioMinimo = int.Parse(ConfigurationManager.AppSettings.Get("QueryEstadisticaAnioMinimo"));
            int anioMaximo = DateTime.Now.Year + 10;

            for (int i = anioMinimo; i <= anioMaximo; i++)
            {
                anio.Items.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }

            //anio.DisplayMember = "Value";
            //anio.ValueMember = "Key";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (semestre.SelectedItem != null && anio.SelectedItem != null &&
                    ((KeyValuePair<int, string>)semestre.SelectedItem).Key != 0 && ((KeyValuePair<int, string>)anio.SelectedItem).Key != 0)
                {
                    _OnSelect(
                        ((KeyValuePair<int, string>)semestre.SelectedItem).Key, 
                        ((KeyValuePair<int, string>)anio.SelectedItem).Key);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
