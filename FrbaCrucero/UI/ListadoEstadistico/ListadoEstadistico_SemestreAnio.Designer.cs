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
            this.groupBox1.Location = new System.Drawing.Point(62, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Semestre";
            // 
            // semestre
            // 
            this.semestre.DisplayMember = "Value";
            this.semestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semestre.FormattingEnabled = true;
            this.semestre.Location = new System.Drawing.Point(108, 21);
            this.semestre.Name = "semestre";
            this.semestre.Size = new System.Drawing.Size(178, 24);
            this.semestre.TabIndex = 0;
            this.semestre.ValueMember = "Key";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.anio);
            this.groupBox2.Location = new System.Drawing.Point(62, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Año";
            // 
            // anio
            // 
            this.anio.DisplayMember = "Value";
            this.anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(108, 21);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(178, 24);
            this.anio.TabIndex = 0;
            this.anio.ValueMember = "Key";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(224, 222);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(130, 31);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ListadoEstadistico_SemestreAnio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 293);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoEstadistico_SemestreAnio";
            this.Text = "ListadoEstadistico_SemestreAnio";
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