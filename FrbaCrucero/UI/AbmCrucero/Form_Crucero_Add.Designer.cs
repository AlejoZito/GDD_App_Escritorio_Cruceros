namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_Crucero_Add
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
            this.listviewCabinas = new FrbaCrucero.UI._Components.DataListViewControl();
            this.btn_delete_cabina = new System.Windows.Forms.Button();
            this.btn_add_cabina = new System.Windows.Forms.Button();
            this.btnCruceroAdd = new System.Windows.Forms.Button();
            this.dropdownModelo = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownFabricante = new FrbaCrucero.UI.Components.DropdownControl();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIdentificador = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AGREGAR CRUCERO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listviewCabinas);
            this.groupBox1.Location = new System.Drawing.Point(11, 204);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(288, 124);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabinas";
            // 
            // listviewCabinas
            // 
            this.listviewCabinas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listviewCabinas.Location = new System.Drawing.Point(9, 19);
            this.listviewCabinas.Margin = new System.Windows.Forms.Padding(2);
            this.listviewCabinas.Name = "listviewCabinas";
            this.listviewCabinas.Size = new System.Drawing.Size(269, 97);
            this.listviewCabinas.TabIndex = 0;
            this.listviewCabinas.UseCompatibleStateImageBehavior = false;
            this.listviewCabinas.View = System.Windows.Forms.View.Details;
            // 
            // btn_delete_cabina
            // 
            this.btn_delete_cabina.Location = new System.Drawing.Point(311, 271);
            this.btn_delete_cabina.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete_cabina.Name = "btn_delete_cabina";
            this.btn_delete_cabina.Size = new System.Drawing.Size(60, 24);
            this.btn_delete_cabina.TabIndex = 6;
            this.btn_delete_cabina.Text = "Eliminar";
            this.btn_delete_cabina.UseVisualStyleBackColor = true;
            this.btn_delete_cabina.Click += new System.EventHandler(this.btn_delete_cabina_Click);
            // 
            // btn_add_cabina
            // 
            this.btn_add_cabina.Location = new System.Drawing.Point(311, 243);
            this.btn_add_cabina.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_cabina.Name = "btn_add_cabina";
            this.btn_add_cabina.Size = new System.Drawing.Size(60, 24);
            this.btn_add_cabina.TabIndex = 4;
            this.btn_add_cabina.Text = "Agregar";
            this.btn_add_cabina.UseVisualStyleBackColor = true;
            this.btn_add_cabina.Click += new System.EventHandler(this.btn_add_cabina_Click);
            // 
            // btnCruceroAdd
            // 
            this.btnCruceroAdd.Location = new System.Drawing.Point(147, 351);
            this.btnCruceroAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnCruceroAdd.Name = "btnCruceroAdd";
            this.btnCruceroAdd.Size = new System.Drawing.Size(92, 22);
            this.btnCruceroAdd.TabIndex = 5;
            this.btnCruceroAdd.Text = "Agregar";
            this.btnCruceroAdd.UseVisualStyleBackColor = true;
            this.btnCruceroAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // dropdownModelo
            // 
            this.dropdownModelo.BackColor = System.Drawing.Color.Transparent;
            this.dropdownModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownModelo.LabelText = "Modelo";
            this.dropdownModelo.Location = new System.Drawing.Point(39, 94);
            this.dropdownModelo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownModelo.Name = "dropdownModelo";
            this.dropdownModelo.Size = new System.Drawing.Size(289, 67);
            this.dropdownModelo.TabIndex = 1;
            // 
            // dropdownFabricante
            // 
            this.dropdownFabricante.BackColor = System.Drawing.Color.Transparent;
            this.dropdownFabricante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownFabricante.LabelText = "Fabricante";
            this.dropdownFabricante.Location = new System.Drawing.Point(39, 51);
            this.dropdownFabricante.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownFabricante.Name = "dropdownFabricante";
            this.dropdownFabricante.Size = new System.Drawing.Size(289, 67);
            this.dropdownFabricante.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Identificador";
            // 
            // tbIdentificador
            // 
            this.tbIdentificador.Location = new System.Drawing.Point(133, 132);
            this.tbIdentificador.Name = "tbIdentificador";
            this.tbIdentificador.Size = new System.Drawing.Size(188, 20);
            this.tbIdentificador.TabIndex = 8;
            // 
            // Form_Crucero_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 398);
            this.Controls.Add(this.tbIdentificador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_delete_cabina);
            this.Controls.Add(this.btnCruceroAdd);
            this.Controls.Add(this.btn_add_cabina);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownModelo);
            this.Controls.Add(this.dropdownFabricante);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Crucero_Add";
            this.ShowIcon = false;
            this.Text = "Agregar Crucero";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.DropdownControl dropdownFabricante;
        private Components.DropdownControl dropdownModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_add_cabina;
        private System.Windows.Forms.Button btnCruceroAdd;
        private _Components.DataListViewControl listviewCabinas;
        private System.Windows.Forms.Button btn_delete_cabina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIdentificador;

    }
}