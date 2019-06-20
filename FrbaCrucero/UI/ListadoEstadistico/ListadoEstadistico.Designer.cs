﻿namespace FrbaCrucero.UI.ListadoEstadistico
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // top5Recorridos
            // 
            this.top5Recorridos.Location = new System.Drawing.Point(160, 65);
            this.top5Recorridos.Name = "top5Recorridos";
            this.top5Recorridos.Size = new System.Drawing.Size(188, 48);
            this.top5Recorridos.TabIndex = 0;
            this.top5Recorridos.Text = "Top 5 Recorridos";
            this.top5Recorridos.UseVisualStyleBackColor = true;
            this.top5Recorridos.Click += new System.EventHandler(this.top5Recorridos_Click);
            // 
            // top5CruceroFueraDeServicio
            // 
            this.top5CruceroFueraDeServicio.Location = new System.Drawing.Point(492, 65);
            this.top5CruceroFueraDeServicio.Name = "top5CruceroFueraDeServicio";
            this.top5CruceroFueraDeServicio.Size = new System.Drawing.Size(188, 48);
            this.top5CruceroFueraDeServicio.TabIndex = 1;
            this.top5CruceroFueraDeServicio.Text = "Top 5 Cruceros Fuera de servicio";
            this.top5CruceroFueraDeServicio.UseVisualStyleBackColor = true;
            this.top5CruceroFueraDeServicio.Click += new System.EventHandler(this.top5CruceroFueraDeServicio_Click);
            // 
            // top5CrucerosSinVentas
            // 
            this.top5CrucerosSinVentas.Location = new System.Drawing.Point(824, 65);
            this.top5CrucerosSinVentas.Name = "top5CrucerosSinVentas";
            this.top5CrucerosSinVentas.Size = new System.Drawing.Size(188, 48);
            this.top5CrucerosSinVentas.TabIndex = 2;
            this.top5CrucerosSinVentas.Text = "Top 5 Cruceros sin ventas";
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
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.top5CrucerosSinVentas);
            this.Controls.Add(this.top5CruceroFueraDeServicio);
            this.Controls.Add(this.top5Recorridos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button top5Recorridos;
        private System.Windows.Forms.Button top5CruceroFueraDeServicio;
        private System.Windows.Forms.Button top5CrucerosSinVentas;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}