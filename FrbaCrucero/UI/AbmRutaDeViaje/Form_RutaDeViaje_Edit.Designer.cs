﻿namespace FrbaCrucero.UI.AbmRutaDeViaje
{
    partial class Form_RutaDeViaje_Edit
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
            this.datepickerDesde = new FrbaCrucero.UI.Components.DatePickerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarCruceros = new System.Windows.Forms.Button();
            this.datepickerEstimada = new FrbaCrucero.UI.Components.DatePickerControl();
            this.btnRecorridoAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dropdownRecorrido = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownCrucero = new FrbaCrucero.UI.Components.DropdownControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datepickerDesde
            // 
            this.datepickerDesde.BackColor = System.Drawing.Color.Transparent;
            this.datepickerDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerDesde.LabelText = "Fecha desde";
            this.datepickerDesde.Location = new System.Drawing.Point(-11, 11);
            this.datepickerDesde.Name = "datepickerDesde";
            this.datepickerDesde.Size = new System.Drawing.Size(385, 53);
            this.datepickerDesde.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarCruceros);
            this.groupBox1.Controls.Add(this.datepickerDesde);
            this.groupBox1.Controls.Add(this.datepickerEstimada);
            this.groupBox1.Location = new System.Drawing.Point(19, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 166);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscarCruceros
            // 
            this.btnBuscarCruceros.Location = new System.Drawing.Point(203, 114);
            this.btnBuscarCruceros.Name = "btnBuscarCruceros";
            this.btnBuscarCruceros.Size = new System.Drawing.Size(153, 36);
            this.btnBuscarCruceros.TabIndex = 11;
            this.btnBuscarCruceros.Text = "Buscar Cruceros";
            this.btnBuscarCruceros.UseVisualStyleBackColor = true;
            this.btnBuscarCruceros.Click += new System.EventHandler(this.btnBuscarCruceros_Click);
            // 
            // datepickerEstimada
            // 
            this.datepickerEstimada.BackColor = System.Drawing.Color.Transparent;
            this.datepickerEstimada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerEstimada.LabelText = "Fecha Estimada";
            this.datepickerEstimada.Location = new System.Drawing.Point(-11, 68);
            this.datepickerEstimada.Name = "datepickerEstimada";
            this.datepickerEstimada.Size = new System.Drawing.Size(384, 50);
            this.datepickerEstimada.TabIndex = 10;
            // 
            // btnRecorridoAdd
            // 
            this.btnRecorridoAdd.Location = new System.Drawing.Point(299, 413);
            this.btnRecorridoAdd.Name = "btnRecorridoAdd";
            this.btnRecorridoAdd.Size = new System.Drawing.Size(94, 32);
            this.btnRecorridoAdd.TabIndex = 14;
            this.btnRecorridoAdd.Text = "Agregar";
            this.btnRecorridoAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Agregar ruta de viaje";
            // 
            // dropdownRecorrido
            // 
            this.dropdownRecorrido.BackColor = System.Drawing.Color.Transparent;
            this.dropdownRecorrido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownRecorrido.LabelText = "Recorrido";
            this.dropdownRecorrido.Location = new System.Drawing.Point(7, 324);
            this.dropdownRecorrido.Name = "dropdownRecorrido";
            this.dropdownRecorrido.Size = new System.Drawing.Size(385, 83);
            this.dropdownRecorrido.TabIndex = 16;
            // 
            // dropdownCrucero
            // 
            this.dropdownCrucero.BackColor = System.Drawing.Color.Transparent;
            this.dropdownCrucero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownCrucero.LabelText = "Crucero";
            this.dropdownCrucero.Location = new System.Drawing.Point(8, 235);
            this.dropdownCrucero.Name = "dropdownCrucero";
            this.dropdownCrucero.Size = new System.Drawing.Size(385, 83);
            this.dropdownCrucero.TabIndex = 15;
            // 
            // Form_RutaDeViaje_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRecorridoAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownRecorrido);
            this.Controls.Add(this.dropdownCrucero);
            this.Name = "Form_RutaDeViaje_Edit";
            this.Text = "Form_Recorrido_Add";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.DatePickerControl datepickerDesde;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarCruceros;
        private Components.DatePickerControl datepickerEstimada;
        private System.Windows.Forms.Button btnRecorridoAdd;
        private System.Windows.Forms.Label label1;
        private Components.DropdownControl dropdownRecorrido;
        private Components.DropdownControl dropdownCrucero;

    }
}