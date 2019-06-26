namespace FrbaCrucero.UI.AbmPuerto
{
    partial class Form_Puerto_Add
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
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NombreLabel
            // 
            this.NombreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLabel.Location = new System.Drawing.Point(16, 42);
            this.NombreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(73, 20);
            this.NombreLabel.TabIndex = 0;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NombreTextBox.Location = new System.Drawing.Point(148, 37);
            this.NombreTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(241, 22);
            this.NombreTextBox.TabIndex = 1;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GuardarButton.Location = new System.Drawing.Point(276, 116);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(113, 34);
            this.GuardarButton.TabIndex = 3;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // AltaPuerto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(407, 178);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.NombreLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AltaPuerto";
            this.ShowIcon = false;
            this.Text = "Ingresar Nuevo Puerto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
    }
}