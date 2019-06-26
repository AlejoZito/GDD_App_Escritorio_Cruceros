namespace FrbaCrucero.UI.AbmPuerto
{
    partial class Form_Puerto_Edit
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
            this.GuardarButton = new System.Windows.Forms.Button();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.checkbox_activo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GuardarButton.Location = new System.Drawing.Point(207, 93);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(85, 28);
            this.GuardarButton.TabIndex = 7;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click_1);
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NombreTextBox.Location = new System.Drawing.Point(111, 29);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(182, 20);
            this.NombreTextBox.TabIndex = 5;
            // 
            // NombreLabel
            // 
            this.NombreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLabel.Location = new System.Drawing.Point(12, 33);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(60, 16);
            this.NombreLabel.TabIndex = 4;
            this.NombreLabel.Text = "Nombre:";
            // 
            // checkbox_activo
            // 
            this.checkbox_activo.AutoSize = true;
            this.checkbox_activo.Location = new System.Drawing.Point(241, 53);
            this.checkbox_activo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkbox_activo.Name = "checkbox_activo";
            this.checkbox_activo.Size = new System.Drawing.Size(56, 17);
            this.checkbox_activo.TabIndex = 8;
            this.checkbox_activo.Text = "Activo";
            this.checkbox_activo.UseVisualStyleBackColor = true;
            // 
            // Form_Puerto_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 150);
            this.Controls.Add(this.checkbox_activo);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.NombreLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Puerto_Edit";
            this.ShowIcon = false;
            this.Text = "Editar Puerto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.CheckBox checkbox_activo;
    }
}