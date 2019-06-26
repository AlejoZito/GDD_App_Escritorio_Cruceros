namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_Mantenimiento
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listMantenimientos = new FrbaCrucero.UI._Components.DataListViewControl();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.datePickerHasta = new FrbaCrucero.UI.Components.DatePickerControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listMantenimientos);
            this.groupBox1.Location = new System.Drawing.Point(24, 131);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(331, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de mantenimientos";
            // 
            // listMantenimientos
            // 
            this.listMantenimientos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listMantenimientos.Location = new System.Drawing.Point(10, 24);
            this.listMantenimientos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listMantenimientos.Name = "listMantenimientos";
            this.listMantenimientos.Size = new System.Drawing.Size(310, 207);
            this.listMantenimientos.TabIndex = 0;
            this.listMantenimientos.UseCompatibleStateImageBehavior = false;
            this.listMantenimientos.View = System.Windows.Forms.View.Details;
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(290, 379);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(65, 25);
            this.buttonVolver.TabIndex = 1;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Controls.Add(this.datePickerHasta);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(327, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programar mantenimiento";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(232, 72);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 29);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // datePickerHasta
            // 
            this.datePickerHasta.BackColor = System.Drawing.Color.Transparent;
            this.datePickerHasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datePickerHasta.LabelText = "Hasta";
            this.datePickerHasta.Location = new System.Drawing.Point(28, 32);
            this.datePickerHasta.Margin = new System.Windows.Forms.Padding(2);
            this.datePickerHasta.Name = "datePickerHasta";
            this.datePickerHasta.Size = new System.Drawing.Size(289, 35);
            this.datePickerHasta.TabIndex = 1;
            // 
            // Form_Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 413);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Mantenimiento";
            this.ShowIcon = false;
            this.Text = "Mantenimiento de Crucero";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private _Components.DataListViewControl listMantenimientos;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAceptar;
        private Components.DatePickerControl datePickerHasta;
    }
}