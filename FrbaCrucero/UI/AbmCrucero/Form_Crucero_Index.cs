using FrbaCrucero;
using FrbaCrucero.Core;
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
    public partial class Form_Crucero_Index : Form
    {
        private readonly Repository repository = new Repository();

        int Contador;
        public Form_Crucero_Index()
        {
            InitializeComponent();
            //Test data
            listView1.Items.Add("1", "Santa Catalina", 0);
            listView1.Items.Add("2", "La niña", 0);
            listView1.Items.Add("3", "Potemkin", 0);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            //var selectedItem = listView1.SelectedItems;
            //if (selectedItem != null)
            //{
            //    Program.Navigation.GoToPage(new Form_Crucero_Edit(selectedItem[0].Index.ToString()), false);
            //}

            string query = @"SELECT * FROM [TIRANDO_QUERIES].[Demo]";

            var output = repository.Select(query);
            MessageBox.Show(output);
        }
    }
}
