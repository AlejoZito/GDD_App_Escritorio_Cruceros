namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_Crucero_Edit
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
            this.btnCruceroEdit = new System.Windows.Forms.Button();
            this.dropdownModelo = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownFabricante = new FrbaCrucero.UI.Components.DropdownControl();
            this.tbIdentificador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Editar Crucero";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listviewCabinas);
            this.groupBox1.Location = new System.Drawing.Point(58, 176);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(288, 171);
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
            this.listviewCabinas.Size = new System.Drawing.Size(269, 138);
            this.listviewCabinas.TabIndex = 0;
            this.listviewCabinas.UseCompatibleStateImageBehavior = false;
            this.listviewCabinas.View = System.Windows.Forms.View.Details;
            // 
            // btnCruceroEdit
            // 
            this.btnCruceroEdit.Location = new System.Drawing.Point(255, 363);
            this.btnCruceroEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnCruceroEdit.Name = "btnCruceroEdit";
            this.btnCruceroEdit.Size = new System.Drawing.Size(92, 22);
            this.btnCruceroEdit.TabIndex = 5;
            this.btnCruceroEdit.Text = "Actualizar";
            this.btnCruceroEdit.UseVisualStyleBackColor = true;
            this.btnCruceroEdit.Click += new System.EventHandler(this.btnCrucerEdit_Click);
            // 
            // dropdownModelo
            // 
            this.dropdownModelo.BackColor = System.Drawing.Color.Transparent;
            this.dropdownModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownModelo.LabelText = "Modelo";
            this.dropdownModelo.Location = new System.Drawing.Point(57, 92);
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
            this.dropdownFabricante.Location = new System.Drawing.Point(58, 52);
            this.dropdownFabricante.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownFabricante.Name = "dropdownFabricante";
            this.dropdownFabricante.Size = new System.Drawing.Size(289, 67);
            this.dropdownFabricante.TabIndex = 0;
            // 
            // tbIdentificador
            // 
            this.tbIdentificador.Location = new System.Drawing.Point(153, 134);
            this.tbIdentificador.Name = "tbIdentificador";
            this.tbIdentificador.Size = new System.Drawing.Size(188, 20);
            this.tbIdentificador.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Identificador";
            // 
            // Form_Crucero_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 398);
            this.Controls.Add(this.tbIdentificador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCruceroEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownModelo);
            this.Controls.Add(this.dropdownFabricante);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Crucero_Edit";
            this.ShowIcon = false;
            this.Text = "Editar Crucero";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.DropdownControl dropdownFabricante;
        private Components.DropdownControl dropdownModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCruceroEdit;
        private _Components.DataListViewControl listviewCabinas;
        private System.Windows.Forms.TextBox tbIdentificador;
        private System.Windows.Forms.Label label2;

    }
}