namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_Cabina_Add
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
            this.btn_add = new System.Windows.Forms.Button();
            this.dropdownTipo = new FrbaCrucero.UI.Components.DropdownControl();
            this.inputPiso = new FrbaCrucero.UI.Components.InputTextControl();
            this.inputNumero = new FrbaCrucero.UI.Components.InputTextControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar cabina";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(208, 197);
            this.btn_add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(95, 24);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Agregar";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dropdownTipo
            // 
            this.dropdownTipo.BackColor = System.Drawing.Color.Transparent;
            this.dropdownTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownTipo.LabelText = "Tipo";
            this.dropdownTipo.Location = new System.Drawing.Point(18, 128);
            this.dropdownTipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownTipo.Name = "dropdownTipo";
            this.dropdownTipo.Size = new System.Drawing.Size(289, 67);
            this.dropdownTipo.TabIndex = 3;
            // 
            // inputPiso
            // 
            this.inputPiso.BackColor = System.Drawing.Color.Transparent;
            this.inputPiso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputPiso.LabelText = "Piso";
            this.inputPiso.Location = new System.Drawing.Point(16, 80);
            this.inputPiso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputPiso.Name = "inputPiso";
            this.inputPiso.Size = new System.Drawing.Size(289, 43);
            this.inputPiso.TabIndex = 2;
            // 
            // inputNumero
            // 
            this.inputNumero.BackColor = System.Drawing.Color.Transparent;
            this.inputNumero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputNumero.LabelText = "Número";
            this.inputNumero.Location = new System.Drawing.Point(16, 32);
            this.inputNumero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputNumero.Name = "inputNumero";
            this.inputNumero.Size = new System.Drawing.Size(289, 43);
            this.inputNumero.TabIndex = 0;
            // 
            // Form_Cabina_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 241);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dropdownTipo);
            this.Controls.Add(this.inputPiso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputNumero);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Cabina_Add";
            this.ShowIcon = false;
            this.Text = "Agregar Cabina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.InputTextControl inputNumero;
        private System.Windows.Forms.Label label1;
        private Components.InputTextControl inputPiso;
        private Components.DropdownControl dropdownTipo;
        private System.Windows.Forms.Button btn_add;
    }
}