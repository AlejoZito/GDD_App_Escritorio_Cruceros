namespace FrbaCrucero.UI.AbmRutaDeViaje
{
    partial class Form_RutaDeViaje_Add
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
            this.btnRecorridoAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarCruceros = new System.Windows.Forms.Button();
            this.datepickerDesde = new FrbaCrucero.UI.Components.DatePickerControl();
            this.datepickerEstimada = new FrbaCrucero.UI.Components.DatePickerControl();
            this.dropdownRecorrido = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownCrucero = new FrbaCrucero.UI.Components.DropdownControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar ruta de viaje";
            // 
            // btnRecorridoAdd
            // 
            this.btnRecorridoAdd.Location = new System.Drawing.Point(221, 340);
            this.btnRecorridoAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRecorridoAdd.Name = "btnRecorridoAdd";
            this.btnRecorridoAdd.Size = new System.Drawing.Size(70, 26);
            this.btnRecorridoAdd.TabIndex = 5;
            this.btnRecorridoAdd.Text = "Agregar";
            this.btnRecorridoAdd.UseVisualStyleBackColor = true;
            this.btnRecorridoAdd.Click += new System.EventHandler(this.btnRecorridoAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarCruceros);
            this.groupBox1.Controls.Add(this.datepickerDesde);
            this.groupBox1.Controls.Add(this.datepickerEstimada);
            this.groupBox1.Location = new System.Drawing.Point(11, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(280, 135);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscarCruceros
            // 
            this.btnBuscarCruceros.Location = new System.Drawing.Point(152, 93);
            this.btnBuscarCruceros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarCruceros.Name = "btnBuscarCruceros";
            this.btnBuscarCruceros.Size = new System.Drawing.Size(115, 29);
            this.btnBuscarCruceros.TabIndex = 11;
            this.btnBuscarCruceros.Text = "Buscar Cruceros";
            this.btnBuscarCruceros.UseVisualStyleBackColor = true;
            this.btnBuscarCruceros.Click += new System.EventHandler(this.btnBuscarCruceros_Click);
            // 
            // datepickerDesde
            // 
            this.datepickerDesde.BackColor = System.Drawing.Color.Transparent;
            this.datepickerDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerDesde.LabelText = "Fecha desde";
            this.datepickerDesde.Location = new System.Drawing.Point(-8, 9);
            this.datepickerDesde.Margin = new System.Windows.Forms.Padding(2);
            this.datepickerDesde.Name = "datepickerDesde";
            this.datepickerDesde.Size = new System.Drawing.Size(289, 43);
            this.datepickerDesde.TabIndex = 8;
            // 
            // datepickerEstimada
            // 
            this.datepickerEstimada.BackColor = System.Drawing.Color.Transparent;
            this.datepickerEstimada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datepickerEstimada.LabelText = "Fecha Estimada";
            this.datepickerEstimada.Location = new System.Drawing.Point(-8, 55);
            this.datepickerEstimada.Margin = new System.Windows.Forms.Padding(2);
            this.datepickerEstimada.Name = "datepickerEstimada";
            this.datepickerEstimada.Size = new System.Drawing.Size(288, 41);
            this.datepickerEstimada.TabIndex = 10;
            // 
            // dropdownRecorrido
            // 
            this.dropdownRecorrido.BackColor = System.Drawing.Color.Transparent;
            this.dropdownRecorrido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownRecorrido.LabelText = "Recorrido";
            this.dropdownRecorrido.Location = new System.Drawing.Point(2, 267);
            this.dropdownRecorrido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownRecorrido.Name = "dropdownRecorrido";
            this.dropdownRecorrido.Size = new System.Drawing.Size(289, 67);
            this.dropdownRecorrido.TabIndex = 7;
            // 
            // dropdownCrucero
            // 
            this.dropdownCrucero.BackColor = System.Drawing.Color.Transparent;
            this.dropdownCrucero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownCrucero.LabelText = "Crucero";
            this.dropdownCrucero.Location = new System.Drawing.Point(3, 195);
            this.dropdownCrucero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownCrucero.Name = "dropdownCrucero";
            this.dropdownCrucero.Size = new System.Drawing.Size(289, 67);
            this.dropdownCrucero.TabIndex = 6;
            // 
            // Form_RutaDeViaje_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 375);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dropdownRecorrido);
            this.Controls.Add(this.dropdownCrucero);
            this.Controls.Add(this.btnRecorridoAdd);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_RutaDeViaje_Add";
            this.ShowIcon = false;
            this.Text = "Agregar Ruta de Viaje";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecorridoAdd;
        private Components.DropdownControl dropdownCrucero;
        private Components.DropdownControl dropdownRecorrido;
        private Components.DatePickerControl datepickerDesde;
        private Components.DatePickerControl datepickerEstimada;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarCruceros;
    }
}