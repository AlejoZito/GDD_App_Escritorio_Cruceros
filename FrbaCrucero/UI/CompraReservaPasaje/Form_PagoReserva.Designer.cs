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
            this.tbIdReserva = new System.Windows.Forms.TextBox();
            this.btnBuscarReserva = new System.Windows.Forms.Button();
            this.groupBoxReserva = new System.Windows.Forms.GroupBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFechaSalida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPuertoHasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPuertoDesde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dropdownMediosDePago = new FrbaCrucero.UI.Components.DropdownControl();
            this.btnPagarReserva = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxReserva.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de Reserva";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbIdReserva
            // 
            this.tbIdReserva.Location = new System.Drawing.Point(378, 146);
            this.tbIdReserva.Name = "tbIdReserva";
            this.tbIdReserva.Size = new System.Drawing.Size(145, 20);
            this.tbIdReserva.TabIndex = 1;
            // 
            // btnBuscarReserva
            // 
            this.btnBuscarReserva.Location = new System.Drawing.Point(566, 143);
            this.btnBuscarReserva.Name = "btnBuscarReserva";
            this.btnBuscarReserva.Size = new System.Drawing.Size(118, 25);
            this.btnBuscarReserva.TabIndex = 2;
            this.btnBuscarReserva.Text = "Buscar";
            this.btnBuscarReserva.UseVisualStyleBackColor = true;
            this.btnBuscarReserva.Click += new System.EventHandler(this.btnBuscarReserva_Click);
            // 
            // groupBoxReserva
            // 
            this.groupBoxReserva.Controls.Add(this.tbNombre);
            this.groupBoxReserva.Controls.Add(this.label7);
            this.groupBoxReserva.Controls.Add(this.tbApellido);
            this.groupBoxReserva.Controls.Add(this.label8);
            this.groupBoxReserva.Controls.Add(this.tbPrecio);
            this.groupBoxReserva.Controls.Add(this.label5);
            this.groupBoxReserva.Controls.Add(this.tbFechaSalida);
            this.groupBoxReserva.Controls.Add(this.label4);
            this.groupBoxReserva.Controls.Add(this.tbPuertoHasta);
            this.groupBoxReserva.Controls.Add(this.label3);
            this.groupBoxReserva.Controls.Add(this.tbPuertoDesde);
            this.groupBoxReserva.Controls.Add(this.label2);
            this.groupBoxReserva.Location = new System.Drawing.Point(247, 201);
            this.groupBoxReserva.Name = "groupBoxReserva";
            this.groupBoxReserva.Size = new System.Drawing.Size(457, 189);
            this.groupBoxReserva.TabIndex = 3;
            this.groupBoxReserva.TabStop = false;
            this.groupBoxReserva.Text = "Datos de la Reserva";
            // 
            // tbNombre
            // 
            this.tbNombre.Enabled = false;
            this.tbNombre.Location = new System.Drawing.Point(115, 43);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(105, 20);
            this.tbNombre.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Nombre:";
            // 
            // tbApellido
            // 
            this.tbApellido.Enabled = false;
            this.tbApellido.Location = new System.Drawing.Point(332, 43);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(105, 20);
            this.tbApellido.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Apellido:";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Enabled = false;
            this.tbPrecio.Location = new System.Drawing.Point(332, 146);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(105, 20);
            this.tbPrecio.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio:";
            // 
            // tbFechaSalida
            // 
            this.tbFechaSalida.Enabled = false;
            this.tbFechaSalida.Location = new System.Drawing.Point(115, 146);
            this.tbFechaSalida.Name = "tbFechaSalida";
            this.tbFechaSalida.Size = new System.Drawing.Size(105, 20);
            this.tbFechaSalida.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de Salida:";
            // 
            // tbPuertoHasta
            // 
            this.tbPuertoHasta.Enabled = false;
            this.tbPuertoHasta.Location = new System.Drawing.Point(115, 96);
            this.tbPuertoHasta.Name = "tbPuertoHasta";
            this.tbPuertoHasta.Size = new System.Drawing.Size(105, 20);
            this.tbPuertoHasta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Puerto Hasta:";
            // 
            // tbPuertoDesde
            // 
            this.tbPuertoDesde.Enabled = false;
            this.tbPuertoDesde.Location = new System.Drawing.Point(332, 96);
            this.tbPuertoDesde.Name = "tbPuertoDesde";
            this.tbPuertoDesde.Size = new System.Drawing.Size(105, 20);
            this.tbPuertoDesde.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Puerto Desde:";
            // 
            // dropdownMediosDePago
            // 
            this.dropdownMediosDePago.BackColor = System.Drawing.Color.Transparent;
            this.dropdownMediosDePago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownMediosDePago.LabelText = "Medio de pago";
            this.dropdownMediosDePago.Location = new System.Drawing.Point(255, 441);
            this.dropdownMediosDePago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownMediosDePago.Name = "dropdownMediosDePago";
            this.dropdownMediosDePago.Size = new System.Drawing.Size(286, 22);
            this.dropdownMediosDePago.TabIndex = 4;
            // 
            // btnPagarReserva
            // 
            this.btnPagarReserva.Location = new System.Drawing.Point(566, 435);
            this.btnPagarReserva.Name = "btnPagarReserva";
            this.btnPagarReserva.Size = new System.Drawing.Size(118, 28);
            this.btnPagarReserva.TabIndex = 5;
            this.btnPagarReserva.Text = "Pagar";
            this.btnPagarReserva.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(411, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pago de Reservas";
            // 
            // Form_PagoReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPagarReserva);
            this.Controls.Add(this.dropdownMediosDePago);
            this.Controls.Add(this.groupBoxReserva);
            this.Controls.Add(this.btnBuscarReserva);
            this.Controls.Add(this.tbIdReserva);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PagoReserva";
            this.ShowIcon = false;
            this.Text = "Pagar Reserva";
            this.groupBoxReserva.ResumeLayout(false);
            this.groupBoxReserva.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIdReserva;
        private System.Windows.Forms.Button btnBuscarReserva;
        private System.Windows.Forms.GroupBox groupBoxReserva;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFechaSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPuertoHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPuertoDesde;
        private System.Windows.Forms.Label label2;
        private Components.DropdownControl dropdownMediosDePago;
        private System.Windows.Forms.Button btnPagarReserva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label label8;
    }
}