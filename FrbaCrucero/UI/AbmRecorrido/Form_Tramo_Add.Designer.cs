﻿namespace FrbaCrucero.UI.AbmRecorrido
{
    partial class Form_Tramo_Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.inputPrecio = new FrbaCrucero.UI.Components.InputTextControl();
            this.dropdownPuertoHasta = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownPuertoDesde = new FrbaCrucero.UI.Components.DropdownControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Tramo";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(200, 227);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 26);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // inputPrecio
            // 
            this.inputPrecio.BackColor = System.Drawing.Color.Transparent;
            this.inputPrecio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputPrecio.LabelText = "Precio";
            this.inputPrecio.Location = new System.Drawing.Point(12, 179);
            this.inputPrecio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputPrecio.Name = "inputPrecio";
            this.inputPrecio.Size = new System.Drawing.Size(289, 43);
            this.inputPrecio.TabIndex = 4;
            // 
            // dropdownPuertoHasta
            // 
            this.dropdownPuertoHasta.BackColor = System.Drawing.Color.Transparent;
            this.dropdownPuertoHasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownPuertoHasta.LabelText = "Puerto Hasta";
            this.dropdownPuertoHasta.Location = new System.Drawing.Point(12, 106);
            this.dropdownPuertoHasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownPuertoHasta.Name = "dropdownPuertoHasta";
            this.dropdownPuertoHasta.Size = new System.Drawing.Size(289, 67);
            this.dropdownPuertoHasta.TabIndex = 2;
            // 
            // dropdownPuertoDesde
            // 
            this.dropdownPuertoDesde.BackColor = System.Drawing.Color.Transparent;
            this.dropdownPuertoDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownPuertoDesde.LabelText = "Puerto Desde";
            this.dropdownPuertoDesde.Location = new System.Drawing.Point(9, 34);
            this.dropdownPuertoDesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownPuertoDesde.Name = "dropdownPuertoDesde";
            this.dropdownPuertoDesde.Size = new System.Drawing.Size(289, 67);
            this.dropdownPuertoDesde.TabIndex = 1;
            // 
            // Form_Tramo_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 270);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.inputPrecio);
            this.Controls.Add(this.dropdownPuertoHasta);
            this.Controls.Add(this.dropdownPuertoDesde);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Tramo_Add";
            this.ShowIcon = false;
            this.Text = "Agregar Tramo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Components.DropdownControl dropdownPuertoDesde;
        private Components.DropdownControl dropdownPuertoHasta;
        private Components.InputTextControl inputPrecio;
        private System.Windows.Forms.Button btnAdd;
    }
}