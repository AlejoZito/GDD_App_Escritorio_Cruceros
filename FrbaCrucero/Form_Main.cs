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

        public Form_Main()
        {
            _PageCache = new List<KeyValuePair<string, Form>>();
            InitializeComponent();
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
            Content.Controls.Clear();
            Content.Controls.Add(newPage.Value);
            newPage.Value.Show();
        }

        public void PopUpPage(Form page)
        {
            page.ShowDialog();
        }

        private void button_AbmPuerto_Click(object sender, EventArgs e)
        {
            GoToPage(new UI.AbmPuerto.Form_Puerto_Index());
        }

        private void button_AbmCruceros_Click(object sender, EventArgs e)
        {
            GoToPage(new UI.AbmCrucero.Form_Crucero_Index());
        }

        private void button_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Navigation.Show();
        }
    }
}
