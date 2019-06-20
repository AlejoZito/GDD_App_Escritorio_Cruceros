using System;
namespace FrbaCrucero
{
    partial class MenuPrincipal
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
            this.btnAbmRol = new System.Windows.Forms.Button();
            this.btnPagarReserva = new System.Windows.Forms.Button();
            this.btnPasaje = new System.Windows.Forms.Button();
            this.button_RutasDeViaje = new System.Windows.Forms.Button();
            this.button_AbmRecorridos = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.button_CerrarSesion = new System.Windows.Forms.Button();
            this.button_AbmCruceros = new System.Windows.Forms.Button();
            this.Content = new System.Windows.Forms.Panel();
            this.Nav_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_AbmPuerto
            // 
            this.button_AbmPuerto.Location = new System.Drawing.Point(6, 5);
            this.button_AbmPuerto.Margin = new System.Windows.Forms.Padding(2);
            this.button_AbmPuerto.Name = "button_AbmPuerto";
            this.button_AbmPuerto.Size = new System.Drawing.Size(78, 33);
            this.button_AbmPuerto.TabIndex = 0;
            this.button_AbmPuerto.Text = "ABM Puertos";
            this.button_AbmPuerto.UseVisualStyleBackColor = true;
            this.button_AbmPuerto.Click += new System.EventHandler(this.button_AbmPuerto_Click);
            // 
            // Nav_Panel
            // 
            this.Nav_Panel.AutoSize = true;
            this.Nav_Panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Nav_Panel.Controls.Add(this.btnAbmRol);
            this.Nav_Panel.Controls.Add(this.btnPagarReserva);
            this.Nav_Panel.Controls.Add(this.btnPasaje);
            this.Nav_Panel.Controls.Add(this.button_RutasDeViaje);
            this.Nav_Panel.Controls.Add(this.button_AbmRecorridos);
            this.Nav_Panel.Controls.Add(this.UsernameLabel);
            this.Nav_Panel.Controls.Add(this.welcomeLabel);
            this.Nav_Panel.Controls.Add(this.button_CerrarSesion);
            this.Nav_Panel.Controls.Add(this.button_AbmCruceros);
            this.Nav_Panel.Controls.Add(this.button_AbmPuerto);
            this.Nav_Panel.Location = new System.Drawing.Point(0, 0);
            this.Nav_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Nav_Panel.Name = "Nav_Panel";
            this.Nav_Panel.Size = new System.Drawing.Size(961, 48);
            this.Nav_Panel.TabIndex = 1;
            // 
            // btnAbmRol
            // 
            this.btnAbmRol.Location = new System.Drawing.Point(533, 5);
            this.btnAbmRol.Name = "btnAbmRol";
            this.btnAbmRol.Size = new System.Drawing.Size(57, 32);
            this.btnAbmRol.TabIndex = 9;
            this.btnAbmRol.Text = "ABM Rol";
            this.btnAbmRol.UseVisualStyleBackColor = true;
            this.btnAbmRol.Click += new System.EventHandler(this.btnAbmRol_Click);
            // 
            // btnPagarReserva
            // 
            this.btnPagarReserva.Location = new System.Drawing.Point(440, 5);
            this.btnPagarReserva.Name = "btnPagarReserva";
            this.btnPagarReserva.Size = new System.Drawing.Size(87, 32);
            this.btnPagarReserva.TabIndex = 8;
            this.btnPagarReserva.Text = "Pagar Reserva";
            this.btnPagarReserva.UseVisualStyleBackColor = true;
            this.btnPagarReserva.Click += new System.EventHandler(this.btnPagarReserva_Click);
            // 
            // btnPasaje
            // 
            this.btnPasaje.Location = new System.Drawing.Point(385, 5);
            this.btnPasaje.Name = "btnPasaje";
            this.btnPasaje.Size = new System.Drawing.Size(48, 32);
            this.btnPasaje.TabIndex = 7;
            this.btnPasaje.Text = "Pasaje";
            this.btnPasaje.UseVisualStyleBackColor = true;
            this.btnPasaje.Click += new System.EventHandler(this.btnPasaje_Click);
            // 
            // button_RutasDeViaje
            // 
            this.button_RutasDeViaje.Location = new System.Drawing.Point(271, 5);
            this.button_RutasDeViaje.Margin = new System.Windows.Forms.Padding(2);
            this.button_RutasDeViaje.Name = "button_RutasDeViaje";
            this.button_RutasDeViaje.Size = new System.Drawing.Size(109, 33);
            this.button_RutasDeViaje.TabIndex = 6;
            this.button_RutasDeViaje.Text = "ABM Rutas de viaje";
            this.button_RutasDeViaje.UseVisualStyleBackColor = true;
            this.button_RutasDeViaje.Click += new System.EventHandler(this.button_RutasDeViaje_Click);
            // 
            // button_AbmRecorridos
            // 
            this.button_AbmRecorridos.Location = new System.Drawing.Point(175, 5);
            this.button_AbmRecorridos.Margin = new System.Windows.Forms.Padding(2);
            this.button_AbmRecorridos.Name = "button_AbmRecorridos";
            this.button_AbmRecorridos.Size = new System.Drawing.Size(92, 33);
            this.button_AbmRecorridos.TabIndex = 5;
            this.button_AbmRecorridos.Text = "ABM Recorridos";
            this.button_AbmRecorridos.UseVisualStyleBackColor = true;
            this.button_AbmRecorridos.Click += new System.EventHandler(this.button_AbmRecorridos_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.UsernameLabel.Location = new System.Drawing.Point(780, 11);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(0, 18);
            this.UsernameLabel.TabIndex = 4;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.welcomeLabel.Location = new System.Drawing.Point(701, 11);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(80, 18);
            this.welcomeLabel.TabIndex = 3;
            this.welcomeLabel.Text = "Bienvenido";
            // 
            // button_CerrarSesion
            // 
            this.button_CerrarSesion.Location = new System.Drawing.Point(845, 5);
            this.button_CerrarSesion.Name = "button_CerrarSesion";
            this.button_CerrarSesion.Size = new System.Drawing.Size(106, 33);
            this.button_CerrarSesion.TabIndex = 2;
            this.button_CerrarSesion.Text = "Cerrar Sesión";
            this.button_CerrarSesion.UseVisualStyleBackColor = true;
            this.button_CerrarSesion.Click += new System.EventHandler(this.button_CerrarSesion_Click);
            // 
            // button_AbmCruceros
            // 
            this.button_AbmCruceros.Location = new System.Drawing.Point(88, 5);
            this.button_AbmCruceros.Margin = new System.Windows.Forms.Padding(2);
            this.button_AbmCruceros.Name = "button_AbmCruceros";
            this.button_AbmCruceros.Size = new System.Drawing.Size(83, 33);
            this.button_AbmCruceros.TabIndex = 1;
            this.button_AbmCruceros.Text = "ABM Cruceros";
            this.button_AbmCruceros.UseVisualStyleBackColor = true;
            this.button_AbmCruceros.Click += new System.EventHandler(this.button_AbmCruceros_Click);
            // 
            // Content
            // 
            this.Content.AutoSize = true;
            this.Content.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Content.Location = new System.Drawing.Point(0, 44);
            this.Content.Margin = new System.Windows.Forms.Padding(2);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(961, 556);
            this.Content.TabIndex = 2;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(963, 598);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Nav_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            this.Shown += new System.EventHandler(this.MenuPrincipal_Shown);
            this.Nav_Panel.ResumeLayout(false);
            this.Nav_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_AbmPuerto;
        private System.Windows.Forms.Panel Nav_Panel;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Button button_AbmCruceros;
        private System.Windows.Forms.Button button_CerrarSesion;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button button_AbmRecorridos;
        private System.Windows.Forms.Button button_RutasDeViaje;
        private System.Windows.Forms.Button btnPasaje;
        private System.Windows.Forms.Button btnPagarReserva;
        private System.Windows.Forms.Button btnAbmRol;
    }
}

