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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar cabina";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(278, 243);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(127, 30);
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
            this.dropdownTipo.Location = new System.Drawing.Point(24, 158);
            this.dropdownTipo.Name = "dropdownTipo";
            this.dropdownTipo.Size = new System.Drawing.Size(385, 83);
            this.dropdownTipo.TabIndex = 3;
            // 
            // inputPiso
            // 
            this.inputPiso.BackColor = System.Drawing.Color.Transparent;
            this.inputPiso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputPiso.LabelText = "Piso";
            this.inputPiso.Location = new System.Drawing.Point(21, 99);
            this.inputPiso.Name = "inputPiso";
            this.inputPiso.Size = new System.Drawing.Size(385, 53);
            this.inputPiso.TabIndex = 2;
            // 
            // inputNumero
            // 
            this.inputNumero.BackColor = System.Drawing.Color.Transparent;
            this.inputNumero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inputNumero.LabelText = "Número";
            this.inputNumero.Location = new System.Drawing.Point(21, 40);
            this.inputNumero.Name = "inputNumero";
            this.inputNumero.Size = new System.Drawing.Size(385, 53);
            this.inputNumero.TabIndex = 0;
            // 
            // Form_Cabina_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 297);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dropdownTipo);
            this.Controls.Add(this.inputPiso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputNumero);
            this.Name = "Form_Cabina_Add";
            this.Text = "Form_Cabina_Add";
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