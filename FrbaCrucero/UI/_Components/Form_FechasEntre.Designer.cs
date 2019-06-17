namespace FrbaCrucero.UI._Components
{
    partial class Form_FechasEntre
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
            this.datePickerDesde = new FrbaCrucero.UI.Components.DatePickerControl();
            this.datePickerHasta = new FrbaCrucero.UI.Components.DatePickerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datePickerDesde
            // 
            this.datePickerDesde.BackColor = System.Drawing.Color.Transparent;
            this.datePickerDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datePickerDesde.LabelText = "Desde";
            this.datePickerDesde.Location = new System.Drawing.Point(39, 42);
            this.datePickerDesde.Name = "datePickerDesde";
            this.datePickerDesde.Size = new System.Drawing.Size(385, 53);
            this.datePickerDesde.TabIndex = 0;
            // 
            // datePickerHasta
            // 
            this.datePickerHasta.BackColor = System.Drawing.Color.Transparent;
            this.datePickerHasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datePickerHasta.LabelText = "Hasta";
            this.datePickerHasta.Location = new System.Drawing.Point(39, 101);
            this.datePickerHasta.Name = "datePickerHasta";
            this.datePickerHasta.Size = new System.Drawing.Size(385, 53);
            this.datePickerHasta.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datePickerDesde);
            this.groupBox1.Controls.Add(this.datePickerHasta);
            this.groupBox1.Location = new System.Drawing.Point(22, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 175);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione fechas";
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Location = new System.Drawing.Point(340, 212);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(180, 41);
            this.buttonSeleccionar.TabIndex = 3;
            this.buttonSeleccionar.Text = "Seleccionar";
            this.buttonSeleccionar.UseVisualStyleBackColor = true;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // Form_FechasEntre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 269);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_FechasEntre";
            this.Text = "Form_FechasEntre";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.DatePickerControl datePickerDesde;
        private Components.DatePickerControl datePickerHasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSeleccionar;
    }
}