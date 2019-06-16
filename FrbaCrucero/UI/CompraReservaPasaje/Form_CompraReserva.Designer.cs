namespace FrbaCrucero.UI.CompraReservaPasaje
{
    partial class Form_CompraReserva
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarViajes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMonto = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.inputFechaNacimiento = new FrbaCrucero.UI.Components.DatePickerControl();
            this.inputEmail = new FrbaCrucero.UI.Components.InputTextControl();
            this.inputTelefono = new FrbaCrucero.UI.Components.InputTextControl();
            this.inputDireccion = new FrbaCrucero.UI.Components.InputTextControl();
            this.inputApellido = new FrbaCrucero.UI.Components.InputTextControl();
            this.inputNombre = new FrbaCrucero.UI.Components.InputTextControl();
            this.inputDni = new FrbaCrucero.UI.Components.InputTextControl();
            this.listViewCabinas = new FrbaCrucero.UI._Components.DataListViewControl();
            this.listViewViajes = new FrbaCrucero.UI._Components.DataListViewControl();
            this.datePickerDeparture = new FrbaCrucero.UI.Components.DatePickerControl();
            this.dropdownPuertoHasta = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownPuertoDesde = new FrbaCrucero.UI.Components.DropdownControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Compra o reserva de pasajes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarViajes);
            this.groupBox1.Controls.Add(this.datePickerDeparture);
            this.groupBox1.Controls.Add(this.dropdownPuertoHasta);
            this.groupBox1.Controls.Add(this.dropdownPuertoDesde);
            this.groupBox1.Location = new System.Drawing.Point(40, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1165, 108);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnBuscarViajes
            // 
            this.btnBuscarViajes.Location = new System.Drawing.Point(994, 74);
            this.btnBuscarViajes.Name = "btnBuscarViajes";
            this.btnBuscarViajes.Size = new System.Drawing.Size(155, 34);
            this.btnBuscarViajes.TabIndex = 5;
            this.btnBuscarViajes.Text = "Buscar viajes";
            this.btnBuscarViajes.UseVisualStyleBackColor = true;
            this.btnBuscarViajes.Click += new System.EventHandler(this.btnBuscarViajes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.listViewCabinas);
            this.groupBox2.Controls.Add(this.listViewViajes);
            this.groupBox2.Location = new System.Drawing.Point(39, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1174, 224);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(846, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Seleccione más de 1 cabina utilizando ctrl o shift";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cabinas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Viajes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.btnReservar);
            this.groupBox3.Controls.Add(this.btnComprar);
            this.groupBox3.Controls.Add(this.inputFechaNacimiento);
            this.groupBox3.Controls.Add(this.inputEmail);
            this.groupBox3.Controls.Add(this.inputTelefono);
            this.groupBox3.Controls.Add(this.inputDireccion);
            this.groupBox3.Controls.Add(this.inputApellido);
            this.groupBox3.Controls.Add(this.inputNombre);
            this.groupBox3.Controls.Add(this.inputDni);
            this.groupBox3.Location = new System.Drawing.Point(38, 430);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1174, 200);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelMonto);
            this.panel1.Location = new System.Drawing.Point(519, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 66);
            this.panel1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 39);
            this.label6.TabIndex = 11;
            this.label6.Text = "$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Monto calculado";
            // 
            // labelMonto
            // 
            this.labelMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMonto.Location = new System.Drawing.Point(45, 22);
            this.labelMonto.Name = "labelMonto";
            this.labelMonto.Size = new System.Drawing.Size(125, 39);
            this.labelMonto.TabIndex = 9;
            this.labelMonto.Text = "00";
            this.labelMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(811, 133);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(172, 59);
            this.btnReservar.TabIndex = 8;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.Green;
            this.btnComprar.Location = new System.Drawing.Point(989, 133);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(172, 59);
            this.btnComprar.TabIndex = 7;
            this.btnComprar.Text = "COMPRAR";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // inputFechaNacimiento
            // 
            this.inputFechaNacimiento.BackColor = System.Drawing.Color.Transparent;
            this.inputFechaNacimiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputFechaNacimiento.LabelText = "Fecha nacimiento";
            this.inputFechaNacimiento.Location = new System.Drawing.Point(6, 139);
            this.inputFechaNacimiento.Name = "inputFechaNacimiento";
            this.inputFechaNacimiento.Size = new System.Drawing.Size(385, 53);
            this.inputFechaNacimiento.TabIndex = 6;
            // 
            // inputEmail
            // 
            this.inputEmail.BackColor = System.Drawing.Color.Transparent;
            this.inputEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputEmail.LabelText = "Email";
            this.inputEmail.Location = new System.Drawing.Point(783, 80);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(385, 53);
            this.inputEmail.TabIndex = 5;
            // 
            // inputTelefono
            // 
            this.inputTelefono.BackColor = System.Drawing.Color.Transparent;
            this.inputTelefono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputTelefono.LabelText = "Telefono";
            this.inputTelefono.Location = new System.Drawing.Point(391, 80);
            this.inputTelefono.Name = "inputTelefono";
            this.inputTelefono.Size = new System.Drawing.Size(385, 53);
            this.inputTelefono.TabIndex = 4;
            // 
            // inputDireccion
            // 
            this.inputDireccion.BackColor = System.Drawing.Color.Transparent;
            this.inputDireccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputDireccion.LabelText = "Direccion";
            this.inputDireccion.Location = new System.Drawing.Point(6, 80);
            this.inputDireccion.Name = "inputDireccion";
            this.inputDireccion.Size = new System.Drawing.Size(385, 53);
            this.inputDireccion.TabIndex = 3;
            // 
            // inputApellido
            // 
            this.inputApellido.BackColor = System.Drawing.Color.Transparent;
            this.inputApellido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputApellido.LabelText = "Apellido";
            this.inputApellido.Location = new System.Drawing.Point(782, 21);
            this.inputApellido.Name = "inputApellido";
            this.inputApellido.Size = new System.Drawing.Size(385, 53);
            this.inputApellido.TabIndex = 2;
            // 
            // inputNombre
            // 
            this.inputNombre.BackColor = System.Drawing.Color.Transparent;
            this.inputNombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputNombre.LabelText = "Nombre";
            this.inputNombre.Location = new System.Drawing.Point(391, 21);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(385, 53);
            this.inputNombre.TabIndex = 1;
            // 
            // inputDni
            // 
            this.inputDni.BackColor = System.Drawing.Color.Transparent;
            this.inputDni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputDni.LabelText = "DNI";
            this.inputDni.Location = new System.Drawing.Point(6, 21);
            this.inputDni.Name = "inputDni";
            this.inputDni.Size = new System.Drawing.Size(385, 53);
            this.inputDni.TabIndex = 0;
            // 
            // listViewCabinas
            // 
            this.listViewCabinas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewCabinas.HideSelection = false;
            this.listViewCabinas.Location = new System.Drawing.Point(581, 58);
            this.listViewCabinas.Name = "listViewCabinas";
            this.listViewCabinas.Size = new System.Drawing.Size(579, 145);
            this.listViewCabinas.TabIndex = 1;
            this.listViewCabinas.UseCompatibleStateImageBehavior = false;
            this.listViewCabinas.View = System.Windows.Forms.View.Details;
            this.listViewCabinas.SelectedIndexChanged += new System.EventHandler(this.listViewCabinas_SelectedIndexChanged);
            // 
            // listViewViajes
            // 
            this.listViewViajes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewViajes.HideSelection = false;
            this.listViewViajes.Location = new System.Drawing.Point(16, 58);
            this.listViewViajes.MultiSelect = false;
            this.listViewViajes.Name = "listViewViajes";
            this.listViewViajes.Size = new System.Drawing.Size(521, 146);
            this.listViewViajes.TabIndex = 0;
            this.listViewViajes.UseCompatibleStateImageBehavior = false;
            this.listViewViajes.View = System.Windows.Forms.View.Details;
            this.listViewViajes.SelectedIndexChanged += new System.EventHandler(this.listViewViajes_SelectedIndexChanged);
            // 
            // datePickerDeparture
            // 
            this.datePickerDeparture.BackColor = System.Drawing.Color.Transparent;
            this.datePickerDeparture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.datePickerDeparture.LabelText = "Fecha de Partida";
            this.datePickerDeparture.Location = new System.Drawing.Point(0, 25);
            this.datePickerDeparture.Name = "datePickerDeparture";
            this.datePickerDeparture.Size = new System.Drawing.Size(385, 53);
            this.datePickerDeparture.TabIndex = 0;
            // 
            // dropdownPuertoHasta
            // 
            this.dropdownPuertoHasta.BackColor = System.Drawing.Color.Transparent;
            this.dropdownPuertoHasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownPuertoHasta.LabelText = "Puerto Llegada";
            this.dropdownPuertoHasta.Location = new System.Drawing.Point(774, 25);
            this.dropdownPuertoHasta.Name = "dropdownPuertoHasta";
            this.dropdownPuertoHasta.Size = new System.Drawing.Size(385, 83);
            this.dropdownPuertoHasta.TabIndex = 4;
            // 
            // dropdownPuertoDesde
            // 
            this.dropdownPuertoDesde.BackColor = System.Drawing.Color.Transparent;
            this.dropdownPuertoDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownPuertoDesde.LabelText = "Puerto Salida";
            this.dropdownPuertoDesde.Location = new System.Drawing.Point(391, 25);
            this.dropdownPuertoDesde.Name = "dropdownPuertoDesde";
            this.dropdownPuertoDesde.Size = new System.Drawing.Size(385, 83);
            this.dropdownPuertoDesde.TabIndex = 3;
            // 
            // Form_CompraReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_CompraReserva";
            this.Text = "Pasaje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.Components.DatePickerControl datePickerDeparture;
        private System.Windows.Forms.Label label1;
        private UI.Components.DropdownControl dropdownPuertoDesde;
        private UI.Components.DropdownControl dropdownPuertoHasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UI._Components.DataListViewControl listViewCabinas;
        private UI._Components.DataListViewControl listViewViajes;
        private System.Windows.Forms.Button btnBuscarViajes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private UI.Components.InputTextControl inputDireccion;
        private UI.Components.InputTextControl inputApellido;
        private UI.Components.InputTextControl inputNombre;
        private UI.Components.InputTextControl inputDni;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnComprar;
        private UI.Components.DatePickerControl inputFechaNacimiento;
        private UI.Components.InputTextControl inputEmail;
        private UI.Components.InputTextControl inputTelefono;
        private System.Windows.Forms.Label labelMonto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}