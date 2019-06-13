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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dropdownFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exactFilter = new System.Windows.Forms.TextBox();
            this.label_filtroLibre = new System.Windows.Forms.Label();
            this.likeFilter = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.cleanFilters = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.likeFilterTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.exactFilterTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.dropdownFilterTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.indexDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexDataGridView
            // 
            this.indexDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indexDataGridView.Location = new System.Drawing.Point(40, 209);
            this.indexDataGridView.Name = "indexDataGridView";
            this.indexDataGridView.RowTemplate.Height = 24;
            this.indexDataGridView.Size = new System.Drawing.Size(1200, 477);
            this.indexDataGridView.TabIndex = 2;
            this.indexDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dropdownFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.exactFilter);
            this.groupBox1.Controls.Add(this.label_filtroLibre);
            this.groupBox1.Controls.Add(this.likeFilter);
            this.groupBox1.Location = new System.Drawing.Point(40, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "filtro extraño";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.textBox3.Location = new System.Drawing.Point(383, 67);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(113, 22);
            this.textBox3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filtro dropdown";
            // 
            // dropdownFilter
            // 
            this.dropdownFilter.FormattingEnabled = true;
            this.dropdownFilter.Location = new System.Drawing.Point(383, 34);
            this.dropdownFilter.Name = "dropdownFilter";
            this.dropdownFilter.Size = new System.Drawing.Size(235, 24);
            this.dropdownFilter.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filtro exacto";
            // 
            // exactFilter
            // 
            this.exactFilter.Location = new System.Drawing.Point(94, 67);
            this.exactFilter.Name = "exactFilter";
            this.exactFilter.Size = new System.Drawing.Size(133, 22);
            this.exactFilter.TabIndex = 2;
            this.exactFilter.Tag = "";
            // 
            // label_filtroLibre
            // 
            this.label_filtroLibre.AutoSize = true;
            this.label_filtroLibre.Location = new System.Drawing.Point(7, 36);
            this.label_filtroLibre.Name = "label_filtroLibre";
            this.label_filtroLibre.Size = new System.Drawing.Size(70, 17);
            this.label_filtroLibre.TabIndex = 1;
            this.label_filtroLibre.Text = "Filtro libre";
            // 
            // likeFilter
            // 
            this.likeFilter.Location = new System.Drawing.Point(94, 36);
            this.likeFilter.Name = "likeFilter";
            this.likeFilter.Size = new System.Drawing.Size(133, 22);
            this.likeFilter.TabIndex = 0;
            this.likeFilter.Tag = "";
            this.likeFilterTooltip.SetToolTip(this.likeFilter, "asd");
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(482, 159);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(152, 36);
            this.search.TabIndex = 4;
            this.search.Text = "Buscar";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // cleanFilters
            // 
            this.cleanFilters.Location = new System.Drawing.Point(134, 160);
            this.cleanFilters.Name = "cleanFilters";
            this.cleanFilters.Size = new System.Drawing.Size(152, 35);
            this.cleanFilters.TabIndex = 5;
            this.cleanFilters.Text = "Limpiar";
            this.cleanFilters.UseVisualStyleBackColor = true;
            this.cleanFilters.Click += new System.EventHandler(this.cleanFilters_Click);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(728, 34);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(137, 97);
            this.Agregar.TabIndex = 6;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Form_Base_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.cleanFilters);
            this.Controls.Add(this.search);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.indexDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exactFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dropdownFilter;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button cleanFilters;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.ToolTip likeFilterTooltip;
        private System.Windows.Forms.ToolTip exactFilterTooltip;
        private System.Windows.Forms.ToolTip dropdownFilterTooltip;
    }
}