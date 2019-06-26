namespace FrbaCrucero.UI.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.top5Recorridos = new System.Windows.Forms.Button();
            this.top5CruceroFueraDeServicio = new System.Windows.Forms.Button();
            this.top5CrucerosSinVentas = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // top5Recorridos
            // 
            this.top5Recorridos.Location = new System.Drawing.Point(160, 65);
            this.top5Recorridos.Name = "top5Recorridos";
            this.top5Recorridos.Size = new System.Drawing.Size(300, 48);
            this.top5Recorridos.TabIndex = 0;
            this.top5Recorridos.Text = "TOP 5\r\nRECORRIDOS MAS COMPRADOS";
            this.top5Recorridos.UseVisualStyleBackColor = true;
            this.top5Recorridos.Click += new System.EventHandler(this.top5Recorridos_Click);
            // 
            // top5CruceroFueraDeServicio
            // 
            this.top5CruceroFueraDeServicio.Location = new System.Drawing.Point(492, 65);
            this.top5CruceroFueraDeServicio.Name = "top5CruceroFueraDeServicio";
            this.top5CruceroFueraDeServicio.Size = new System.Drawing.Size(300, 48);
            this.top5CruceroFueraDeServicio.TabIndex = 1;
            this.top5CruceroFueraDeServicio.Text = "TOP 5\r\nCRUCEROS EN FUERA DE SERVICIO";
//TOP 5\r\nRECORRIDOS CON - CAB VENDIDA
            this.top5CruceroFueraDeServicio.UseVisualStyleBackColor = true;
            this.top5CruceroFueraDeServicio.Click += new System.EventHandler(this.top5CruceroFueraDeServicio_Click);
            // 
            // top5CrucerosSinVentas
            // 
            this.top5CrucerosSinVentas.Location = new System.Drawing.Point(824, 65);
            this.top5CrucerosSinVentas.Name = "top5CrucerosSinVentas";
            this.top5CrucerosSinVentas.Size = new System.Drawing.Size(300, 48);
            this.top5CrucerosSinVentas.TabIndex = 2;
            this.top5CrucerosSinVentas.Text = "TOP 5\r\nRECORRIDOS CON MENOS VENTAS";
            this.top5CrucerosSinVentas.UseVisualStyleBackColor = true;
            this.top5CrucerosSinVentas.Click += new System.EventHandler(this.top5CrucerosSinVentas_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 139);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1238, 522);
            this.dataGridView1.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(225, 24);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Reportes estadísticos";
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.top5CrucerosSinVentas);
            this.Controls.Add(this.top5CruceroFueraDeServicio);
            this.Controls.Add(this.top5Recorridos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button top5Recorridos;
        private System.Windows.Forms.Button top5CruceroFueraDeServicio;
        private System.Windows.Forms.Button top5CrucerosSinVentas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTitle;
    }
}