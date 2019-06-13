namespace FrbaCrucero.UI.AbmRutaDeViaje
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecorridoEdit = new System.Windows.Forms.Button();
            this.dropdownRecorrido = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownCrucero = new FrbaCrucero.UI.Components.DropdownControl();
            this.datepickerDesde = new FrbaCrucero.UI.Components.DatePickerControl();
            this.datepickerHasta = new FrbaCrucero.UI.Components.DatePickerControl();
            this.datepickerEstimada = new FrbaCrucero.UI.Components.DatePickerControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar ruta de viaje";
            // 
            // btnRecorridoEdit
            // 
            this.btnRecorridoEdit.Location = new System.Drawing.Point(295, 405);
            this.btnRecorridoEdit.Name = "btnRecorridoEdit";
            this.btnRecorridoEdit.Size = new System.Drawing.Size(94, 32);
            this.btnRecorridoEdit.TabIndex = 5;
            this.btnRecorridoEdit.Text = "Agregar";
            this.btnRecorridoEdit.UseVisualStyleBackColor = true;
            this.btnRecorridoEdit.Click += new System.EventHandler(this.btnRecorridoEdit_Click);
            // 
            // dropdownRecorrido
            // 
            this.dropdownRecorrido.BackColor = System.Drawing.Color.Transparent;
            this.dropdownRecorrido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownRecorrido.LabelText = "Recorrido";
            this.dropdownRecorrido.Location = new System.Drawing.Point(4, 137);
            this.dropdownRecorrido.Name = "dropdownRecorrido";
            this.dropdownRecorrido.Size = new System.Drawing.Size(385, 83);
            this.dropdownRecorrido.TabIndex = 7;
            // 
            // dropdownCrucero
            // 
            this.dropdownCrucero.BackColor = System.Drawing.Color.Transparent;
            this.dropdownCrucero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownCrucero.LabelText = "Crucero";
            this.dropdownCrucero.Location = new System.Drawing.Point(4, 48);
            this.dropdownCrucero.Name = "dropdownCrucero";
            this.dropdownCrucero.Size = new System.Drawing.Size(385, 83);
            this.dropdownCrucero.TabIndex = 6;
            // 
            // datepickerDesde
            // 
            this.datepickerDesde.BackColor = System.Drawing.Color.Transparent;
            this.datepickerDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerDesde.LabelText = "Fecha desde";
            this.datepickerDesde.Location = new System.Drawing.Point(4, 226);
            this.datepickerDesde.Name = "datepickerDesde";
            this.datepickerDesde.Size = new System.Drawing.Size(385, 53);
            this.datepickerDesde.TabIndex = 8;
            // 
            // datepickerHasta
            // 
            this.datepickerHasta.BackColor = System.Drawing.Color.Transparent;
            this.datepickerHasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerHasta.LabelText = "Fecha hasta";
            this.datepickerHasta.Location = new System.Drawing.Point(4, 285);
            this.datepickerHasta.Name = "datepickerHasta";
            this.datepickerHasta.Size = new System.Drawing.Size(385, 53);
            this.datepickerHasta.TabIndex = 9;
            // 
            // datepickerEstimada
            // 
            this.datepickerEstimada.BackColor = System.Drawing.Color.Transparent;
            this.datepickerEstimada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerEstimada.LabelText = "Estimada";
            this.datepickerEstimada.Location = new System.Drawing.Point(4, 344);
            this.datepickerEstimada.Name = "datepickerEstimada";
            this.datepickerEstimada.Size = new System.Drawing.Size(385, 53);
            this.datepickerEstimada.TabIndex = 10;
            // 
            // Form_RutaDeViaje_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 449);
            this.Controls.Add(this.datepickerEstimada);
            this.Controls.Add(this.datepickerHasta);
            this.Controls.Add(this.datepickerDesde);
            this.Controls.Add(this.dropdownRecorrido);
            this.Controls.Add(this.dropdownCrucero);
            this.Controls.Add(this.btnRecorridoEdit);
            this.Controls.Add(this.label1);
            this.Name = "Form_RutaDeViaje_Edit";
            this.Text = "Form_Recorrido_Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecorridoEdit;
        private Components.DropdownControl dropdownCrucero;
        private Components.DropdownControl dropdownRecorrido;
        private Components.DatePickerControl datepickerDesde;
        private Components.DatePickerControl datepickerHasta;
        private Components.DatePickerControl datepickerEstimada;
    }
}