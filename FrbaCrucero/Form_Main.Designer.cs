namespace FrbaCrucero
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.Content = new System.Windows.Forms.Panel();
            this.Nav_Panel = new System.Windows.Forms.Panel();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnRecorridos = new System.Windows.Forms.Button();
            this.btnCruceros = new System.Windows.Forms.Button();
            this.btnRutasViaje = new System.Windows.Forms.Button();
            this.btnPuertos = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.button_CerrarSesion = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.Nav_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Content.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Content.Location = new System.Drawing.Point(0, 33);
            this.Content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(1280, 720);
            this.Content.TabIndex = 3;
            // 
            // Nav_Panel
            // 
            this.Nav_Panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.Nav_Panel.Controls.Add(this.labelUsername);
            this.Nav_Panel.Controls.Add(this.btnEstadisticas);
            this.Nav_Panel.Controls.Add(this.btnRoles);
            this.Nav_Panel.Controls.Add(this.btnRecorridos);
            this.Nav_Panel.Controls.Add(this.btnCruceros);
            this.Nav_Panel.Controls.Add(this.btnRutasViaje);
            this.Nav_Panel.Controls.Add(this.btnPuertos);
            this.Nav_Panel.Controls.Add(this.btnHome);
            this.Nav_Panel.Controls.Add(this.UsernameLabel);
            this.Nav_Panel.Controls.Add(this.button_CerrarSesion);
            this.Nav_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Nav_Panel.Location = new System.Drawing.Point(0, 0);
            this.Nav_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Nav_Panel.Name = "Nav_Panel";
            this.Nav_Panel.Size = new System.Drawing.Size(1280, 49);
            this.Nav_Panel.TabIndex = 4;
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEstadisticas.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticas.Image = global::FrbaCrucero.Properties.Resources.icons8_combo_chart_100_50;
            this.btnEstadisticas.Location = new System.Drawing.Point(360, 0);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(60, 49);
            this.btnEstadisticas.TabIndex = 18;
            this.btnEstadisticas.UseVisualStyleBackColor = false;
            this.btnEstadisticas.Visible = false;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRoles.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Image = global::FrbaCrucero.Properties.Resources.icons8_people_100_sm;
            this.btnRoles.Location = new System.Drawing.Point(300, 0);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(60, 49);
            this.btnRoles.TabIndex = 17;
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Visible = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnRecorridos
            // 
            this.btnRecorridos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRecorridos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRecorridos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecorridos.Image = global::FrbaCrucero.Properties.Resources.icons8_signpost_100_sm;
            this.btnRecorridos.Location = new System.Drawing.Point(240, 0);
            this.btnRecorridos.Name = "btnRecorridos";
            this.btnRecorridos.Size = new System.Drawing.Size(60, 49);
            this.btnRecorridos.TabIndex = 16;
            this.btnRecorridos.UseVisualStyleBackColor = false;
            this.btnRecorridos.Visible = false;
            this.btnRecorridos.Click += new System.EventHandler(this.btnRecorridos_Click);
            // 
            // btnCruceros
            // 
            this.btnCruceros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCruceros.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCruceros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCruceros.Image = global::FrbaCrucero.Properties.Resources.icons8_float_100_sm;
            this.btnCruceros.Location = new System.Drawing.Point(180, 0);
            this.btnCruceros.Name = "btnCruceros";
            this.btnCruceros.Size = new System.Drawing.Size(60, 49);
            this.btnCruceros.TabIndex = 15;
            this.btnCruceros.UseVisualStyleBackColor = false;
            this.btnCruceros.Visible = false;
            this.btnCruceros.Click += new System.EventHandler(this.btnCruceros_Click);
            // 
            // btnRutasViaje
            // 
            this.btnRutasViaje.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRutasViaje.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRutasViaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutasViaje.Image = global::FrbaCrucero.Properties.Resources.icons8_world_map_100_sm21;
            this.btnRutasViaje.Location = new System.Drawing.Point(120, 0);
            this.btnRutasViaje.Name = "btnRutasViaje";
            this.btnRutasViaje.Size = new System.Drawing.Size(60, 49);
            this.btnRutasViaje.TabIndex = 14;
            this.btnRutasViaje.UseVisualStyleBackColor = false;
            this.btnRutasViaje.Visible = false;
            this.btnRutasViaje.Click += new System.EventHandler(this.btnRutasViaje_Click);
            // 
            // btnPuertos
            // 
            this.btnPuertos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPuertos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPuertos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuertos.Image = global::FrbaCrucero.Properties.Resources.icons8_location_100_sm;
            this.btnPuertos.Location = new System.Drawing.Point(60, 0);
            this.btnPuertos.Name = "btnPuertos";
            this.btnPuertos.Size = new System.Drawing.Size(60, 49);
            this.btnPuertos.TabIndex = 13;
            this.btnPuertos.UseVisualStyleBackColor = false;
            this.btnPuertos.Visible = false;
            this.btnPuertos.Click += new System.EventHandler(this.btnPuertos_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Image = global::FrbaCrucero.Properties.Resources.icons8_home_32;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(60, 49);
            this.btnHome.TabIndex = 12;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.UsernameLabel.Location = new System.Drawing.Point(780, 11);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(0, 24);
            this.UsernameLabel.TabIndex = 4;
            // 
            // button_CerrarSesion
            // 
            this.button_CerrarSesion.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_CerrarSesion.Location = new System.Drawing.Point(1174, 0);
            this.button_CerrarSesion.Name = "button_CerrarSesion";
            this.button_CerrarSesion.Size = new System.Drawing.Size(106, 49);
            this.button_CerrarSesion.TabIndex = 2;
            this.button_CerrarSesion.Text = "Cerrar Sesión";
            this.button_CerrarSesion.UseVisualStyleBackColor = true;
            this.button_CerrarSesion.Click += new System.EventHandler(this.button_CerrarSesion_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(1105, 14);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(54, 21);
            this.labelUsername.TabIndex = 19;
            this.labelUsername.Text = "label1";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 753);
            this.Controls.Add(this.Nav_Panel);
            this.Controls.Add(this.Content);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Nav_Panel.ResumeLayout(false);
            this.Nav_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Panel Nav_Panel;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button button_CerrarSesion;
        private System.Windows.Forms.Button btnPuertos;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnRecorridos;
        private System.Windows.Forms.Button btnCruceros;
        private System.Windows.Forms.Button btnRutasViaje;
        private System.Windows.Forms.Label labelUsername;

    }
}