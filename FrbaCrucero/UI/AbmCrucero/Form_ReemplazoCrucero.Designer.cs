namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_ReemplazoCrucero
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
            this.crucerosReemplazantes = new System.Windows.Forms.ListBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.btnAceptarReemplazo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crucerosReemplazantes
            // 
            this.crucerosReemplazantes.FormattingEnabled = true;
            this.crucerosReemplazantes.Location = new System.Drawing.Point(12, 68);
            this.crucerosReemplazantes.Name = "crucerosReemplazantes";
            this.crucerosReemplazantes.Size = new System.Drawing.Size(229, 212);
            this.crucerosReemplazantes.TabIndex = 0;
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Location = new System.Drawing.Point(12, 28);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(198, 26);
            this.labelHint.TabIndex = 1;
            this.labelHint.Text = "Seleccione un crucero que reemplazará \r\nal que es dado de baja";
            // 
            // btnAceptarReemplazo
            // 
            this.btnAceptarReemplazo.Location = new System.Drawing.Point(32, 296);
            this.btnAceptarReemplazo.Name = "btnAceptarReemplazo";
            this.btnAceptarReemplazo.Size = new System.Drawing.Size(191, 23);
            this.btnAceptarReemplazo.TabIndex = 2;
            this.btnAceptarReemplazo.Text = "Seleccionar";
            this.btnAceptarReemplazo.UseVisualStyleBackColor = true;
            // 
            // Form_ReemplazoCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 338);
            this.Controls.Add(this.btnAceptarReemplazo);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.crucerosReemplazantes);
            this.Name = "Form_ReemplazoCrucero";
            this.Text = "reemplazarCrucero";
            this.Load += new System.EventHandler(this.Form_ReemplazoCrucero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox crucerosReemplazantes;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.Button btnAceptarReemplazo;
    }
}