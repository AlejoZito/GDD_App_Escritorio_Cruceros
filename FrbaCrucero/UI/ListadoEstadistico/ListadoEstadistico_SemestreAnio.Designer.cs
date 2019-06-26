namespace FrbaCrucero.UI.ListadoEstadistico
{
    partial class ListadoEstadistico_SemestreAnio
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
            this.semestre = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.anio = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.semestre);
            this.groupBox1.Location = new System.Drawing.Point(46, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(219, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Semestre";
            // 
            // semestre
            // 
            this.semestre.DisplayMember = "Value";
            this.semestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semestre.FormattingEnabled = true;
            this.semestre.Location = new System.Drawing.Point(81, 17);
            this.semestre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.semestre.Name = "semestre";
            this.semestre.Size = new System.Drawing.Size(134, 21);
            this.semestre.TabIndex = 0;
            this.semestre.ValueMember = "Key";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.anio);
            this.groupBox2.Location = new System.Drawing.Point(46, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(219, 42);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Año";
            // 
            // anio
            // 
            this.anio.DisplayMember = "Value";
            this.anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(81, 17);
            this.anio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(134, 21);
            this.anio.TabIndex = 0;
            this.anio.ValueMember = "Key";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(168, 180);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 25);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ListadoEstadistico_SemestreAnio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 238);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ListadoEstadistico_SemestreAnio";
            this.ShowIcon = false;
            this.Text = "Selección de semestre y año";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox semestre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox anio;
        private System.Windows.Forms.Button btnAceptar;
    }
}