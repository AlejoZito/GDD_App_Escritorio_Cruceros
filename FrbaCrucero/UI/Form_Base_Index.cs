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
using System.Linq.Expressions;
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
        public OnButtonClickWithIDDelegate _OnTableItemSelected;

        bool _ShowEditButton;
        bool _ShowDeleteButton;

        string _Title;

        private FiltersViewModel _Filters;
        protected FiltersViewModel Filters
        {
            get { return _Filters; }
            set
            {
                //Set object and bind properties
                _Filters = value;

                dropdownFilter.DataSource = _Filters.DropdownOptions;
                dropdownFilter.DisplayMember = "Value";
                dropdownFilter.ValueMember = "Key";
                dropdownFilter.DataBindings.Add("SelectedValue", _Filters, "DropdownFilterSelectedOption", true, DataSourceUpdateMode.OnPropertyChanged);
                labelFiltroDropdown.DataBindings.Add("Text", _Filters, "DropdownFilterLabel", true, DataSourceUpdateMode.OnPropertyChanged);
                labelFiltroDropdown.DataBindings.Add("Visible", _Filters, "DropdownFilterVisible", true, DataSourceUpdateMode.OnPropertyChanged);
                dropdownFilter.DataBindings.Add("Visible", _Filters, "DropdownFilterVisible", true, DataSourceUpdateMode.OnPropertyChanged);

                likeFilter.DataBindings.Add("Text", _Filters, "LikeFilter", true, DataSourceUpdateMode.OnPropertyChanged);
                label_filtroLibre.DataBindings.Add("Text", _Filters, "LikeFilterLabel", true, DataSourceUpdateMode.OnPropertyChanged);

                exactFilter.DataBindings.Add("Text", _Filters, "ExactFilter", true, DataSourceUpdateMode.OnPropertyChanged);
                label_FiltroExacto.DataBindings.Add("Text", _Filters, "ExactFilterLabel", true, DataSourceUpdateMode.OnPropertyChanged);

                btnFiltroComodin.DataBindings.Add("Text", _Filters, "Button_Filtro.Text", true, DataSourceUpdateMode.OnPropertyChanged);
                btnFiltroComodin.DataBindings.Add("Visible", _Filters, "Button_Filtro.Visible", true, DataSourceUpdateMode.OnPropertyChanged);
                labelFiltroComodin.DataBindings.Add("Text", _Filters, "Button_Filtro.Text", true, DataSourceUpdateMode.OnPropertyChanged);
                labelFiltroComodin.DataBindings.Add("Visible", _Filters, "Button_Filtro.Visible", true, DataSourceUpdateMode.OnPropertyChanged);
                filtroComodinValue.DataBindings.Add("Text", _Filters, "Button_Filtro_Seleccion_Descripcion", true, DataSourceUpdateMode.OnPropertyChanged);
                filtroComodinValue.DataBindings.Add("Visible", _Filters, "Button_Filtro.Visible", true, DataSourceUpdateMode.OnPropertyChanged);

                buttonA.DataBindings.Add("Text", _Filters, "Button_A.Text", true, DataSourceUpdateMode.OnPropertyChanged);
                buttonA.DataBindings.Add("Visible", _Filters, "Button_A.Visible", true, DataSourceUpdateMode.OnPropertyChanged);

                buttonB.DataBindings.Add("Text", _Filters, "Button_B.Text", true, DataSourceUpdateMode.OnPropertyChanged);
                buttonB.DataBindings.Add("Visible", _Filters, "Button_B.Visible", true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public Form_Base_Index(bool showEditButton = true, bool showDeleteButton = true, string title = "")
        {
            InitializeComponent();

            _ShowEditButton = showEditButton;
            _ShowDeleteButton = showDeleteButton;

            labelTitle.Text = title;
            SetupDataGridView();
            //PopulateDataGridView(); //NO POPULARLA INICIALMENTE, SOLO AL PRESIONAR "BUSCAR"
        }

        /// <summary>
        /// Metodo para obtener los datos en cada vista Index
        /// </summary>
        /// <returns></returns>
        protected virtual List<T> GetData() { return null; }

        /// <summary>
        /// Metodo para popular los filtros de busqueda
        /// </summary>
        protected virtual void PopulateFilters() { Expression.Empty(); }

        /// <summary>
        /// Metodo para obtener datos y llenar la tabla
        /// </summary>
        protected void PopulateDataGridView()
        {
            try
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

                foreach (DataGridViewColumn column in indexDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Handle row button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (_OnTableItemSelected != null)
            //{
            //    if(indexDataGridView.SelectedRows.Count > 0)
            //        _OnTableItemSelected(int.Parse(indexDataGridView["ID", e.RowIndex].Value.ToString()));
            //}

            if (e.ColumnIndex == indexDataGridView.Columns["colEdit"].Index)
            {
                _OnClickEdit(int.Parse(indexDataGridView["ID", e.RowIndex].Value.ToString()));
            }
            else if (e.ColumnIndex == indexDataGridView.Columns["colDelete"].Index)
            {
                _OnClickDelete(int.Parse(indexDataGridView["ID", e.RowIndex].Value.ToString()));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                if (_OnTableItemSelected != null)
                {
                    if (indexDataGridView.SelectedRows.Count > 0)
                        _OnTableItemSelected(int.Parse(indexDataGridView["ID", e.RowIndex].Value.ToString()));
                }
            }
        }
        private void Agregar_Click(object sender, EventArgs e)
        {
            _OnClickAdd();
        }

        private void search_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void cleanFilters_Click(object sender, EventArgs e)
        {
            _Filters.ResetFilter();
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(indexDataGridView);

            indexDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            indexDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            indexDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(indexDataGridView.Font, FontStyle.Bold);

            indexDataGridView.Name = typeof(T).Name + "_DataGridView";
            indexDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            indexDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            indexDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            indexDataGridView.GridColor = Color.Black;

            //Obtener columnas a partir del viewmodel pasado a este método
            List<string> columns = GetViewModelColumns<T>();

            //Asigno las columnas
            foreach (string colName in columns)
            {
                var column = new DataGridViewColumn();
                indexDataGridView.Columns.Add(colName, colName);
            }

            #region Action buttons
            if (_ShowEditButton)
            {

                DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn();
                btnColumn1.Name = "colEdit";
                btnColumn1.HeaderText = "Editar";
                btnColumn1.Text = "Editar";
                btnColumn1.UseColumnTextForButtonValue = true;
                btnColumn1.CellTemplate.Style.BackColor = Color.GreenYellow;

                indexDataGridView.Columns.Add(btnColumn1);
            }

            if (_ShowDeleteButton)
            {
                DataGridViewButtonColumn btnColumn2 = new DataGridViewButtonColumn();
                btnColumn2.Name = "colDelete";
                btnColumn2.HeaderText = "Borrar";
                btnColumn2.Text = "Borrar";
                btnColumn2.UseColumnTextForButtonValue = true;
                btnColumn2.CellTemplate.Style.BackColor = Color.Orange;

                indexDataGridView.Columns.Add(btnColumn2);
            }
            #endregion

            indexDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            indexDataGridView.AutoSize = true;
            indexDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            indexDataGridView.MultiSelect = false;
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

        private void btnFiltroSeleccionar_Click(object sender, EventArgs e)
        {
            _Filters.Button_Filtro.Action();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            _Filters.Button_A.Action();
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            _Filters.Button_B.Action();
        }
    }
}
