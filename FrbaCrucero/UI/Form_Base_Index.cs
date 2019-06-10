using FrbaCrucero;
using FrbaCrucero.BL;
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
    public partial class Form_Base_Index<T, C> : Form
        where T : ViewModel<C>
    {
        public OnButtonClickDelegate _OnClickAdd;
        public OnButtonClickWithIDDelegate _OnClickEdit;
        public OnButtonClickWithIDDelegate _OnClickDelete;        

        public Form_Base_Index()
        {
            InitializeComponent();

            SetupDataGridView();
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
            int rowNumber = 0;

            indexDataGridView.Rows.Clear();

            foreach (var item in data)
            {
                var dataGridRow = new DataGridViewRow();
                var rowData = item.GetRowData();

                //Asigno el listado de KeyValue Pairs a la row
                for (int i = 0; i < rowData.Count; i++)
                {
                    dataGridRow.Cells.Add(new DataGridViewTextBoxCell() { Value = rowData[i].Value });
                    dataGridRow.Cells[i].Value = rowData[i].Value;
                }

                indexDataGridView.Rows.Add(dataGridRow);                

                rowNumber++;
            }

            indexDataGridView.AutoResizeColumns();
            indexDataGridView.Refresh();
        }

        /// <summary>
        /// Handle row button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == indexDataGridView.Columns["colEdit"].Index)
            {
                _OnClickEdit(int.Parse(indexDataGridView["ID", e.RowIndex].Value.ToString()));
            }
            else if (e.ColumnIndex == indexDataGridView.Columns["colDelete"].Index)
            {
                _OnClickDelete(int.Parse(indexDataGridView["ID", e.RowIndex].Value.ToString()));
            }
        }

        private void SetupDataGridView()
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
            
            #region Action buttons
            DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn();
            btnColumn1.Name = "colEdit";
            btnColumn1.HeaderText = "Edit";
            btnColumn1.Text = "editing";
            btnColumn1.UseColumnTextForButtonValue = true;
            btnColumn1.CellTemplate.Style.BackColor = Color.GreenYellow;

            DataGridViewButtonColumn btnColumn2 = new DataGridViewButtonColumn();
            btnColumn2.Name = "colDelete";
            btnColumn2.HeaderText = "Delete";
            btnColumn2.Text = "deleting";
            btnColumn2.UseColumnTextForButtonValue = true;
            btnColumn2.CellTemplate.Style.BackColor = Color.Orange;

            indexDataGridView.Columns.Add(btnColumn1);
            indexDataGridView.Columns.Add(btnColumn2); 
            #endregion

            //cruceroDataGridView.Columns[4].DefaultCellStyle.Font =
            //    new Font(cruceroDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            indexDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            indexDataGridView.AutoSize = true;
            indexDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            indexDataGridView.MultiSelect = false;
            //indexDataGridView.Dock = DockStyle.Fill;

            //indexDataGridView.CellFormatting += new
            //    DataGridViewCellFormattingEventHandler(
            //    cruceroDataGridView_CellFormatting);
        }

        public static List<string> GetViewModelColumns<T>()
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

        private void Agregar_Click(object sender, EventArgs e)
        {
            _OnClickAdd();
        }
    }
}
