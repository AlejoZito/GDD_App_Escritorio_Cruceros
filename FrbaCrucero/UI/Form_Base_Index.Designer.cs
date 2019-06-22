namespace FrbaCrucero.UI
{
    partial class Form_Base_Index<T, C>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.indexDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltroComodin = new System.Windows.Forms.Button();
            this.cleanFilters = new System.Windows.Forms.Button();
            this.labelFiltroComodin = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.filtroComodinValue = new System.Windows.Forms.TextBox();
            this.labelFiltroDropdown = new System.Windows.Forms.Label();
            this.dropdownFilter = new System.Windows.Forms.ComboBox();
            this.label_FiltroExacto = new System.Windows.Forms.Label();
            this.exactFilter = new System.Windows.Forms.TextBox();
            this.label_filtroLibre = new System.Windows.Forms.Label();
            this.likeFilter = new System.Windows.Forms.TextBox();
            this.Agregar = new System.Windows.Forms.Button();
            this.likeFilterTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.exactFilterTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.dropdownFilterTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.indexDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexDataGridView
            // 
            this.indexDataGridView.AllowUserToAddRows = false;
            this.indexDataGridView.AllowUserToDeleteRows = false;
            this.indexDataGridView.AllowUserToResizeColumns = false;
            this.indexDataGridView.AllowUserToResizeRows = false;
            this.indexDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indexDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.indexDataGridView.Location = new System.Drawing.Point(30, 170);
            this.indexDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.indexDataGridView.MultiSelect = false;
            this.indexDataGridView.Name = "indexDataGridView";
            this.indexDataGridView.RowTemplate.Height = 24;
            this.indexDataGridView.Size = new System.Drawing.Size(900, 388);
            this.indexDataGridView.TabIndex = 2;
            this.indexDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.indexDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltroComodin);
            this.groupBox1.Controls.Add(this.cleanFilters);
            this.groupBox1.Controls.Add(this.labelFiltroComodin);
            this.groupBox1.Controls.Add(this.search);
            this.groupBox1.Controls.Add(this.filtroComodinValue);
            this.groupBox1.Controls.Add(this.labelFiltroDropdown);
            this.groupBox1.Controls.Add(this.dropdownFilter);
            this.groupBox1.Controls.Add(this.label_FiltroExacto);
            this.groupBox1.Controls.Add(this.exactFilter);
            this.groupBox1.Controls.Add(this.label_filtroLibre);
            this.groupBox1.Controls.Add(this.likeFilter);
            this.groupBox1.Location = new System.Drawing.Point(30, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(776, 127);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnFiltroComodin
            // 
            this.btnFiltroComodin.Location = new System.Drawing.Point(621, 54);
            this.btnFiltroComodin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltroComodin.Name = "btnFiltroComodin";
            this.btnFiltroComodin.Size = new System.Drawing.Size(82, 19);
            this.btnFiltroComodin.TabIndex = 8;
            this.btnFiltroComodin.Text = "Seleccionar";
            this.btnFiltroComodin.UseVisualStyleBackColor = true;
            this.btnFiltroComodin.Click += new System.EventHandler(this.btnFiltroSeleccionar_Click);
            // 
            // cleanFilters
            // 
            this.cleanFilters.Location = new System.Drawing.Point(530, 84);
            this.cleanFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cleanFilters.Name = "cleanFilters";
            this.cleanFilters.Size = new System.Drawing.Size(114, 28);
            this.cleanFilters.TabIndex = 5;
            this.cleanFilters.Text = "Limpiar";
            this.cleanFilters.UseVisualStyleBackColor = true;
            this.cleanFilters.Click += new System.EventHandler(this.cleanFilters_Click);
            // 
            // labelFiltroComodin
            // 
            this.labelFiltroComodin.Location = new System.Drawing.Point(362, 58);
            this.labelFiltroComodin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFiltroComodin.Name = "labelFiltroComodin";
            this.labelFiltroComodin.Size = new System.Drawing.Size(64, 14);
            this.labelFiltroComodin.TabIndex = 7;
            this.labelFiltroComodin.Text = "Filtro Comodin";
            this.labelFiltroComodin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(648, 84);
            this.search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(114, 29);
            this.search.TabIndex = 4;
            this.search.Text = "Buscar";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // filtroComodinValue
            // 
            this.filtroComodinValue.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.filtroComodinValue.Location = new System.Drawing.Point(440, 54);
            this.filtroComodinValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filtroComodinValue.Name = "filtroComodinValue";
            this.filtroComodinValue.ReadOnly = true;
            this.filtroComodinValue.Size = new System.Drawing.Size(177, 20);
            this.filtroComodinValue.TabIndex = 6;
            // 
            // labelFiltroDropdown
            // 
            this.labelFiltroDropdown.Location = new System.Drawing.Point(357, 29);
            this.labelFiltroDropdown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFiltroDropdown.Name = "labelFiltroDropdown";
            this.labelFiltroDropdown.Size = new System.Drawing.Size(79, 14);
            this.labelFiltroDropdown.TabIndex = 5;
            this.labelFiltroDropdown.Text = "Filtro dropdown";
            this.labelFiltroDropdown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dropdownFilter
            // 
            this.dropdownFilter.FormattingEnabled = true;
            this.dropdownFilter.Location = new System.Drawing.Point(440, 29);
            this.dropdownFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownFilter.Name = "dropdownFilter";
            this.dropdownFilter.Size = new System.Drawing.Size(264, 21);
            this.dropdownFilter.TabIndex = 4;
            // 
            // label_FiltroExacto
            // 
            this.label_FiltroExacto.Location = new System.Drawing.Point(7, 56);
            this.label_FiltroExacto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FiltroExacto.Name = "label_FiltroExacto";
            this.label_FiltroExacto.Size = new System.Drawing.Size(137, 16);
            this.label_FiltroExacto.TabIndex = 3;
            this.label_FiltroExacto.Text = "Filtro exacto";
            this.label_FiltroExacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exactFilter
            // 
            this.exactFilter.Location = new System.Drawing.Point(148, 54);
            this.exactFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exactFilter.Name = "exactFilter";
            this.exactFilter.Size = new System.Drawing.Size(195, 20);
            this.exactFilter.TabIndex = 2;
            this.exactFilter.Tag = "";
            // 
            // label_filtroLibre
            // 
            this.label_filtroLibre.Location = new System.Drawing.Point(4, 31);
            this.label_filtroLibre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_filtroLibre.Name = "label_filtroLibre";
            this.label_filtroLibre.Size = new System.Drawing.Size(140, 18);
            this.label_filtroLibre.TabIndex = 1;
            this.label_filtroLibre.Text = "Filtro libre";
            this.label_filtroLibre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // likeFilter
            // 
            this.likeFilter.Location = new System.Drawing.Point(148, 29);
            this.likeFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.likeFilter.Name = "likeFilter";
            this.likeFilter.Size = new System.Drawing.Size(195, 20);
            this.likeFilter.TabIndex = 0;
            this.likeFilter.Tag = "";
            this.likeFilterTooltip.SetToolTip(this.likeFilter, "asd");
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar.Location = new System.Drawing.Point(826, 124);
            this.Agregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(104, 35);
            this.Agregar.TabIndex = 6;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // buttonB
            // 
            this.buttonB.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB.Location = new System.Drawing.Point(826, 84);
            this.buttonB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(104, 35);
            this.buttonB.TabIndex = 7;
            this.buttonB.Text = "Button B";
            this.buttonB.UseVisualStyleBackColor = false;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // buttonA
            // 
            this.buttonA.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonA.Location = new System.Drawing.Point(826, 44);
            this.buttonA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(104, 35);
            this.buttonA.TabIndex = 8;
            this.buttonA.Text = "Button A";
            this.buttonA.UseVisualStyleBackColor = false;
            this.buttonA.Click += new System.EventHandler(this.buttonA_Click);
            // 
            // Form_Base_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.indexDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Base_Index";
            this.Text = "    ";
            ((System.ComponentModel.ISupportInitialize)(this.indexDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView indexDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_filtroLibre;
        private System.Windows.Forms.TextBox likeFilter;
        private System.Windows.Forms.Label label_FiltroExacto;
        private System.Windows.Forms.TextBox exactFilter;
        private System.Windows.Forms.Button btnFiltroComodin;
        private System.Windows.Forms.Label labelFiltroComodin;
        private System.Windows.Forms.TextBox filtroComodinValue;
        private System.Windows.Forms.Label labelFiltroDropdown;
        private System.Windows.Forms.ComboBox dropdownFilter;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button cleanFilters;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.ToolTip likeFilterTooltip;
        private System.Windows.Forms.ToolTip exactFilterTooltip;
        private System.Windows.Forms.ToolTip dropdownFilterTooltip;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonA;
    }
}