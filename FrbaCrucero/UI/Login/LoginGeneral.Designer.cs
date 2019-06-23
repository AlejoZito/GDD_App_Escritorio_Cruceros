namespace FrbaCrucero.UI.Login
{
    partial class LoginGeneral
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
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(223, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido a FRBA - Crucero";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdmin.BackColor = System.Drawing.Color.White;
            this.btnAdmin.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnAdmin.Image = global::FrbaCrucero.Properties.Resources.icons8_worker_100;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdmin.Location = new System.Drawing.Point(230, 223);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(231, 129);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "Ingreso Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCliente.BackColor = System.Drawing.Color.White;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Image = global::FrbaCrucero.Properties.Resources.icons8_standing_man_100;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCliente.Location = new System.Drawing.Point(520, 223);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(231, 129);
            this.btnCliente.TabIndex = 3;
            this.btnCliente.Text = "Ingreso Cliente";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // LoginGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaCrucero.Properties.Resources._21352699;
            this.ClientSize = new System.Drawing.Size(953, 546);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginGeneral";
            this.Text = "FRBA - Crucero";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnCliente;
    }
}