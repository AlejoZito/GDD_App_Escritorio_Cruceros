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

        public Form_Base_Index()
        {
            InitializeComponent();

            SetupDataGridView<T>();
            PopulateDataGridView();
        }

        /// <summary>
        /// Metodo para obtener los datos en cada vista Index
        /// </summary>
        /// <returns></returns>
        protected virtual List<T> GetData(){return null;}

        /// <summary>
        /// Metodo para obtener datos y llenar la tabla
        /// </summary>
        protected void PopulateDataGridView()
        {
            List<T> data = GetData();

            foreach (var item in data)
            {
                var dataGridRow = new DataGridViewRow();
                var row = item.GetRow();

                //Asigno el listado de KeyValue Pairs a la row
                for (int i = 0; i < row.Count; i++)
                {
                    dataGridRow.Cells.Add(new DataGridViewTextBoxCell() { Value = row[i].Value });
                    dataGridRow.Cells[i].Value = row[i].Value;
                }
                indexDataGridView.Rows.Add(dataGridRow);
            }

            indexDataGridView.AutoResizeColumns();
            //cruceroDataGridView.Columns[0].DisplayIndex = 3;
            //cruceroDataGridView.Columns[1].DisplayIndex = 4;
            //cruceroDataGridView.Columns[2].DisplayIndex = 0;
            //cruceroDataGridView.Columns[3].DisplayIndex = 1;
            //cruceroDataGridView.Columns[4].DisplayIndex = 2;
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SetupDataGridView<T>() where T : ViewModel
        {
            this.Controls.Add(indexDataGridView);

            #region Estilos

            indexDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            indexDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            indexDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(indexDataGridView.Font, FontStyle.Bold);

            indexDataGridView.Name = typeof(T).Name + "_DataGridView";
            //cruceroDataGridView.Location = new Point(8, 8);
            //cruceroDataGridView.Size = new Size(500, 250);
            indexDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            indexDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            indexDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            indexDataGridView.GridColor = Color.Black;
            //cruceroDataGridView.RowHeadersVisible = false; 
            #endregion

            //Obtener columnas a partir del viewmodel pasado a este método
            List<string> columns = GetViewModelColumns<T>();

            //Asigno las columnas
            foreach (string colName in columns)
            {
                var column = new DataGridViewColumn();
                indexDataGridView.Columns.Add(colName, colName);
            }

            //cruceroDataGridView.Columns[4].DefaultCellStyle.Font =
            //    new Font(cruceroDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            indexDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            indexDataGridView.AutoSize = true;
            indexDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            indexDataGridView.MultiSelect = false;
            //indexDataGridView.Dock = DockStyle.Fill;

            indexDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                cruceroDataGridView_CellFormatting);
        }

        private static List<string> GetViewModelColumns<T>() where T : ViewModel
        {
            var properties = typeof(T).GetProperties();
            List<string> columns = new List<string>();

            foreach (var prop in properties)
            {
                var attributes = (ListableAttribute[])prop.GetCustomAttributes(typeof(ListableAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    //Tiene el atributo <Listable>
                    columns.Add(attributes[0].Description);
                }
            }
            return columns;
        }

        private void cruceroDataGridView_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.indexDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Program.MainMenu.GoToPage(new Form_Base_Add<T>());
        }
    }
}
