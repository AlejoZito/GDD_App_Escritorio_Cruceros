namespace FrbaCrucero
{
    partial class Form_Main
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_AbmPuerto = new System.Windows.Forms.Button();
            this.Nav_Panel = new System.Windows.Forms.Panel();
            this.Content = new System.Windows.Forms.Panel();
            this.button_AbmCruceros = new System.Windows.Forms.Button();
            this.Nav_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_AbmPuerto
            // 
            this.button_AbmPuerto.Location = new System.Drawing.Point(8, 6);
            this.button_AbmPuerto.Name = "button_AbmPuerto";
            this.button_AbmPuerto.Size = new System.Drawing.Size(151, 41);
            this.button_AbmPuerto.TabIndex = 0;
            this.button_AbmPuerto.Text = "ABM Puertos";
            this.button_AbmPuerto.UseVisualStyleBackColor = true;
            this.button_AbmPuerto.Click += new System.EventHandler(this.button_AbmPuerto_Click);
            // 
            // Nav_Panel
            // 
            this.Nav_Panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Nav_Panel.Controls.Add(this.button_AbmCruceros);
            this.Nav_Panel.Controls.Add(this.button_AbmPuerto);
            this.Nav_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Nav_Panel.Location = new System.Drawing.Point(0, 0);
            this.Nav_Panel.Name = "Nav_Panel";
            this.Nav_Panel.Size = new System.Drawing.Size(1262, 54);
            this.Nav_Panel.TabIndex = 1;
            // 
            // Content
            // 
            this.Content.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 54);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(1262, 619);
            this.Content.TabIndex = 2;
            // 
            // button_AbmCruceros
            // 
            this.button_AbmCruceros.Location = new System.Drawing.Point(165, 6);
            this.button_AbmCruceros.Name = "button_AbmCruceros";
            this.button_AbmCruceros.Size = new System.Drawing.Size(151, 41);
            this.button_AbmCruceros.TabIndex = 1;
            this.button_AbmCruceros.Text = "ABM Cruceros";
            this.button_AbmCruceros.UseVisualStyleBackColor = true;
            this.button_AbmCruceros.Click += new System.EventHandler(this.button_AbmCruceros_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Nav_Panel);
            this.Name = "Main";
            this.Text = "Form1";
            this.Nav_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_AbmPuerto;
        private System.Windows.Forms.Panel Nav_Panel;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Button button_AbmCruceros;
    }
}

