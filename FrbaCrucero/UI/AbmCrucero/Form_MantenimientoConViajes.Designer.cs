﻿namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_MantenimientoConViajes
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
            this.buttonDemorar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "El crucero tiene viajes programados. ¿Desea cancelarlos o demorarlos?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDemorar
            // 
            this.buttonDemorar.Location = new System.Drawing.Point(241, 122);
            this.buttonDemorar.Name = "buttonDemorar";
            this.buttonDemorar.Size = new System.Drawing.Size(146, 38);
            this.buttonDemorar.TabIndex = 1;
            this.buttonDemorar.Text = "Demorarlos";
            this.buttonDemorar.UseVisualStyleBackColor = true;
            this.buttonDemorar.Click += new System.EventHandler(this.buttonDemorar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(65, 122);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(146, 38);
            this.buttonCancelar.TabIndex = 2;
            this.buttonCancelar.Text = "Cancelarlos";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // Form_MantenimientoConViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 197);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonDemorar);
            this.Controls.Add(this.label1);
            this.Name = "Form_MantenimientoConViajes";
            this.Text = "Form_MantenimientoConViajes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDemorar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}