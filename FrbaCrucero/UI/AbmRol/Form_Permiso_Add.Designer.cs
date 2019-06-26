namespace FrbaCrucero.UI.AbmRol
{
    partial class Form_Permiso_Add
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
            this.btnAgregarPermisos = new System.Windows.Forms.Button();
            this.listPermisos = new FrbaCrucero.UI._Components.DataListViewControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Permisos";
            // 
            // btnAgregarPermisos
            // 
            this.btnAgregarPermisos.Location = new System.Drawing.Point(170, 224);
            this.btnAgregarPermisos.Name = "btnAgregarPermisos";
            this.btnAgregarPermisos.Size = new System.Drawing.Size(90, 25);
            this.btnAgregarPermisos.TabIndex = 2;
            this.btnAgregarPermisos.Text = "Agregar";
            this.btnAgregarPermisos.UseVisualStyleBackColor = true;
            this.btnAgregarPermisos.Click += new System.EventHandler(this.btnAgregarPermisos_Click);
            // 
            // listPermisos
            // 
            this.listPermisos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listPermisos.Location = new System.Drawing.Point(25, 39);
            this.listPermisos.Margin = new System.Windows.Forms.Padding(2);
            this.listPermisos.Name = "listPermisos";
            this.listPermisos.Size = new System.Drawing.Size(226, 165);
            this.listPermisos.TabIndex = 3;
            this.listPermisos.UseCompatibleStateImageBehavior = false;
            this.listPermisos.View = System.Windows.Forms.View.Details;
            // 
            // Form_Permiso_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.listPermisos);
            this.Controls.Add(this.btnAgregarPermisos);
            this.Controls.Add(this.label1);
            this.Name = "Form_Permiso_Add";
            this.ShowIcon = false;
            this.Text = "Agregar Permisos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarPermisos;
        private _Components.DataListViewControl listPermisos;
    }
}