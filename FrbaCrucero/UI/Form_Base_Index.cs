using FrbaCrucero;
using FrbaCrucero.BL.Attributes;
using FrbaCrucero.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI
{
    public partial class Form_Base_Index<T> : Form
        where T : ViewModel
    {
        int Contador;
        public Form_Base_Index()
        {
            InitializeComponent();
            SetupDataGridView<T>();
            PopulateDataGridView();
        }


        private void button_edit_Click(object sender, EventArgs e)
        {
            //var selectedItem = listView1.SelectedItems;
            //if (selectedItem != null)
            //{
            //    //Program.Navigation.GoToPage(new Form_Crucero_Edit(selectedItem[0].Index.ToString()), false);
            //    Program.Navigation.PopUpPage(new Form_Crucero_Edit(selectedItem[0].Index.ToString()));
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SetupDataGridView<T>() where T : ViewModel
        {
            this.Controls.Add(cruceroDataGridView);

            #region Estilos

            cruceroDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            cruceroDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cruceroDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(cruceroDataGridView.Font, FontStyle.Bold);

            cruceroDataGridView.Name = typeof(T).Name + "_DataGridView";
            //cruceroDataGridView.Location = new Point(8, 8);
            //cruceroDataGridView.Size = new Size(500, 250);
            cruceroDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            cruceroDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            cruceroDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            cruceroDataGridView.GridColor = Color.Black;
            //cruceroDataGridView.RowHeadersVisible = false; 
	#endregion

            //Obtener columnas a partir del viewmodel pasado a este método
            var properties = typeof(T).GetProperties();
            List<string> columns = new List<string>();
           
            foreach(var prop in properties)
            {
                var attributes = (ListableAttribute[])prop.GetCustomAttributes(typeof(ListableAttribute), true);
                if(attributes != null)
                {
                    columns.Add(attributes[0].Description);
                }
            }

            //Asigno las columnas
            foreach (string colName in columns)
            {
                var column = new DataGridViewColumn();
                cruceroDataGridView.Columns.Add(colName, colName);
            }

            //cruceroDataGridView.Columns[4].DefaultCellStyle.Font =
            //    new Font(cruceroDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            cruceroDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            cruceroDataGridView.MultiSelect = false;
            cruceroDataGridView.Dock = DockStyle.Fill;

            cruceroDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                cruceroDataGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9", 
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In", 
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days", 
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?", 
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind", 
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13", 
            "Scatterbrain. (As Dead As Leaves.)", 
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            cruceroDataGridView.Rows.Add(row0);
            cruceroDataGridView.Rows.Add(row1);
            cruceroDataGridView.Rows.Add(row2);
            cruceroDataGridView.Rows.Add(row3);
            cruceroDataGridView.Rows.Add(row4);
            cruceroDataGridView.Rows.Add(row5);
            cruceroDataGridView.Rows.Add(row6);

            //cruceroDataGridView.Columns[0].DisplayIndex = 3;
            //cruceroDataGridView.Columns[1].DisplayIndex = 4;
            //cruceroDataGridView.Columns[2].DisplayIndex = 0;
            //cruceroDataGridView.Columns[3].DisplayIndex = 1;
            //cruceroDataGridView.Columns[4].DisplayIndex = 2;
        }

        private void cruceroDataGridView_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.cruceroDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }
    }
}
