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
            this.btn_delete_cabina = new System.Windows.Forms.Button();
            this.btn_add_cabina = new System.Windows.Forms.Button();
            this.btnCruceroEdit = new System.Windows.Forms.Button();
            this.listviewCabinas = new FrbaCrucero.UI._Components.DataListViewControl();
            this.dropdownModelo = new FrbaCrucero.UI.Components.DropdownControl();
            this.dropdownFabricante = new FrbaCrucero.UI.Components.DropdownControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agregar crucero";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_delete_cabina);
            this.groupBox1.Controls.Add(this.listviewCabinas);
            this.groupBox1.Location = new System.Drawing.Point(78, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 152);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabinas";
            // 
            // btn_delete_cabina
            // 
            this.btn_delete_cabina.Location = new System.Drawing.Point(204, 0);
            this.btn_delete_cabina.Name = "btn_delete_cabina";
            this.btn_delete_cabina.Size = new System.Drawing.Size(80, 30);
            this.btn_delete_cabina.TabIndex = 6;
            this.btn_delete_cabina.Text = "Eliminar";
            this.btn_delete_cabina.UseVisualStyleBackColor = true;
            this.btn_delete_cabina.Click += new System.EventHandler(this.btn_delete_cabina_Click);
            // 
            // btn_add_cabina
            // 
            this.btn_add_cabina.Location = new System.Drawing.Point(368, 262);
            this.btn_add_cabina.Name = "btn_add_cabina";
            this.btn_add_cabina.Size = new System.Drawing.Size(80, 30);
            this.btn_add_cabina.TabIndex = 4;
            this.btn_add_cabina.Text = "Agregar";
            this.btn_add_cabina.UseVisualStyleBackColor = true;
            this.btn_add_cabina.Click += new System.EventHandler(this.btn_add_cabina_Click);
            // 
            // btnCruceroEdit
            // 
            this.btnCruceroEdit.Location = new System.Drawing.Point(340, 447);
            this.btnCruceroEdit.Name = "btnCruceroEdit";
            this.btnCruceroEdit.Size = new System.Drawing.Size(122, 27);
            this.btnCruceroEdit.TabIndex = 5;
            this.btnCruceroEdit.Text = "Actualizar";
            this.btnCruceroEdit.UseVisualStyleBackColor = true;
            this.btnCruceroEdit.Click += new System.EventHandler(this.btnCrucerEdit_Click);
            // 
            // listviewCabinas
            // 
            this.listviewCabinas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listviewCabinas.Location = new System.Drawing.Point(12, 23);
            this.listviewCabinas.Name = "listviewCabinas";
            this.listviewCabinas.Size = new System.Drawing.Size(357, 118);
            this.listviewCabinas.TabIndex = 0;
            this.listviewCabinas.UseCompatibleStateImageBehavior = false;
            this.listviewCabinas.View = System.Windows.Forms.View.Details;
            // 
            // dropdownModelo
            // 
            this.dropdownModelo.BackColor = System.Drawing.Color.Transparent;
            this.dropdownModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownModelo.LabelText = "Modelo";
            this.dropdownModelo.Location = new System.Drawing.Point(78, 153);
            this.dropdownModelo.Name = "dropdownModelo";
            this.dropdownModelo.Size = new System.Drawing.Size(385, 83);
            this.dropdownModelo.TabIndex = 1;
            // 
            // dropdownFabricante
            // 
            this.dropdownFabricante.BackColor = System.Drawing.Color.Transparent;
            this.dropdownFabricante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownFabricante.LabelText = "Fabricante";
            this.dropdownFabricante.Location = new System.Drawing.Point(78, 64);
            this.dropdownFabricante.Name = "dropdownFabricante";
            this.dropdownFabricante.Size = new System.Drawing.Size(385, 83);
            this.dropdownFabricante.TabIndex = 0;
            // 
            // Form_Crucero_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 490);
            this.Controls.Add(this.btnCruceroEdit);
            this.Controls.Add(this.btn_add_cabina);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownModelo);
            this.Controls.Add(this.dropdownFabricante);
            this.Name = "Form_Crucero_Edit";
            this.Text = "Form_Crucero_Add";
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
        private System.Windows.Forms.Button btnCruceroEdit;
        private _Components.DataListViewControl listviewCabinas;
        private System.Windows.Forms.Button btn_delete_cabina;

    }
}