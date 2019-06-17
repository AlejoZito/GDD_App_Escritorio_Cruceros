namespace FrbaCrucero.UI.CompraReservaPasaje
{
    partial class Form_PagoReserva
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
            this.textBoxReserva = new System.Windows.Forms.TextBox();
            this.btnBuscarReserva = new System.Windows.Forms.Button();
            this.groupBoxReserva = new System.Windows.Forms.GroupBox();
            this.dropdownMediosDePago = new FrbaCrucero.UI.Components.DropdownControl();
            this.btnPagarReserva = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPuertoDesde = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPuertoHasta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFechaSalida = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxReserva.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de Reserva";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxReserva
            // 
            this.textBoxReserva.Location = new System.Drawing.Point(146, 24);
            this.textBoxReserva.Name = "textBoxReserva";
            this.textBoxReserva.Size = new System.Drawing.Size(145, 20);
            this.textBoxReserva.TabIndex = 1;
            // 
            // btnBuscarReserva
            // 
            this.btnBuscarReserva.Location = new System.Drawing.Point(173, 66);
            this.btnBuscarReserva.Name = "btnBuscarReserva";
            this.btnBuscarReserva.Size = new System.Drawing.Size(118, 25);
            this.btnBuscarReserva.TabIndex = 2;
            this.btnBuscarReserva.Text = "Buscar";
            this.btnBuscarReserva.UseVisualStyleBackColor = true;
            // 
            // groupBoxReserva
            // 
            this.groupBoxReserva.Controls.Add(this.textBox1);
            this.groupBoxReserva.Controls.Add(this.label5);
            this.groupBoxReserva.Controls.Add(this.tbFechaSalida);
            this.groupBoxReserva.Controls.Add(this.label4);
            this.groupBoxReserva.Controls.Add(this.tbPuertoHasta);
            this.groupBoxReserva.Controls.Add(this.label3);
            this.groupBoxReserva.Controls.Add(this.tbPuertoDesde);
            this.groupBoxReserva.Controls.Add(this.label2);
            this.groupBoxReserva.Location = new System.Drawing.Point(19, 108);
            this.groupBoxReserva.Name = "groupBoxReserva";
            this.groupBoxReserva.Size = new System.Drawing.Size(272, 189);
            this.groupBoxReserva.TabIndex = 3;
            this.groupBoxReserva.TabStop = false;
            this.groupBoxReserva.Text = "Datos de la Reserva";
            // 
            // dropdownMediosDePago
            // 
            this.dropdownMediosDePago.BackColor = System.Drawing.Color.Transparent;
            this.dropdownMediosDePago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownMediosDePago.LabelText = "Medio de pago";
            this.dropdownMediosDePago.Location = new System.Drawing.Point(11, 316);
            this.dropdownMediosDePago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownMediosDePago.Name = "dropdownMediosDePago";
            this.dropdownMediosDePago.Size = new System.Drawing.Size(286, 22);
            this.dropdownMediosDePago.TabIndex = 4;
            // 
            // btnPagarReserva
            // 
            this.btnPagarReserva.Location = new System.Drawing.Point(173, 343);
            this.btnPagarReserva.Name = "btnPagarReserva";
            this.btnPagarReserva.Size = new System.Drawing.Size(118, 28);
            this.btnPagarReserva.TabIndex = 5;
            this.btnPagarReserva.Text = "Pagar";
            this.btnPagarReserva.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Puerto Desde:";
            // 
            // tbPuertoDesde
            // 
            this.tbPuertoDesde.Enabled = false;
            this.tbPuertoDesde.Location = new System.Drawing.Point(127, 23);
            this.tbPuertoDesde.Name = "tbPuertoDesde";
            this.tbPuertoDesde.Size = new System.Drawing.Size(139, 20);
            this.tbPuertoDesde.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Puerto Hasta:";
            // 
            // tbPuertoHasta
            // 
            this.tbPuertoHasta.Enabled = false;
            this.tbPuertoHasta.Location = new System.Drawing.Point(127, 61);
            this.tbPuertoHasta.Name = "tbPuertoHasta";
            this.tbPuertoHasta.Size = new System.Drawing.Size(139, 20);
            this.tbPuertoHasta.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de Salida:";
            // 
            // tbFechaSalida
            // 
            this.tbFechaSalida.Enabled = false;
            this.tbFechaSalida.Location = new System.Drawing.Point(127, 103);
            this.tbFechaSalida.Name = "tbFechaSalida";
            this.tbFechaSalida.Size = new System.Drawing.Size(139, 20);
            this.tbFechaSalida.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(127, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 7;
            // 
            // Form_PagoReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 383);
            this.Controls.Add(this.btnPagarReserva);
            this.Controls.Add(this.dropdownMediosDePago);
            this.Controls.Add(this.groupBoxReserva);
            this.Controls.Add(this.btnBuscarReserva);
            this.Controls.Add(this.textBoxReserva);
            this.Controls.Add(this.label1);
            this.Name = "Form_PagoReserva";
            this.Text = "Pagar Reserva";
            this.groupBoxReserva.ResumeLayout(false);
            this.groupBoxReserva.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxReserva;
        private System.Windows.Forms.Button btnBuscarReserva;
        private System.Windows.Forms.GroupBox groupBoxReserva;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFechaSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPuertoHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPuertoDesde;
        private System.Windows.Forms.Label label2;
        private Components.DropdownControl dropdownMediosDePago;
        private System.Windows.Forms.Button btnPagarReserva;
    }
}