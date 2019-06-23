using System;
namespace FrbaCrucero.MenuPrincipal
{
    partial class Form_MenuPrincipal
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
            this.Content = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.AutoSize = true;
            this.Content.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Content.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Content.Location = new System.Drawing.Point(0, 44);
            this.Content.Margin = new System.Windows.Forms.Padding(2);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(1926, 1283);
            this.Content.TabIndex = 2;
            // 
            // Form_MenuPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(963, 598);
            this.Controls.Add(this.Content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_MenuPrincipal";
            this.Text = "Menu Principal";
            this.Shown += new System.EventHandler(this.MenuPrincipal_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Content;
    }
}

