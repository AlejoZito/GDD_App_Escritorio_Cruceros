namespace FrbaCrucero.UI.CompraReservaPasaje
{
    partial class Form_Pago
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
            this.dropdownMediosDePago = new FrbaCrucero.UI.Components.DropdownControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dropdownMediosDePago
            // 
            this.dropdownMediosDePago.BackColor = System.Drawing.Color.Transparent;
            this.dropdownMediosDePago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropdownMediosDePago.LabelText = "Medio de pago";
            this.dropdownMediosDePago.Location = new System.Drawing.Point(55, 58);
            this.dropdownMediosDePago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropdownMediosDePago.Name = "dropdownMediosDePago";
            this.dropdownMediosDePago.Size = new System.Drawing.Size(289, 67);
            this.dropdownMediosDePago.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elija su forma de pago";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Green;
            this.btnPagar.Location = new System.Drawing.Point(296, 183);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(71, 33);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(222, 183);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Form_Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 233);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownMediosDePago);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Pago";
            this.ShowIcon = false;
            this.Text = "Pago";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.DropdownControl dropdownMediosDePago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCancelar;
    }
}