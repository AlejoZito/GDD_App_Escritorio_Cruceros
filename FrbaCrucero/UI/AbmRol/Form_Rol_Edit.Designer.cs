namespace FrbaCrucero.UI.AbmRol
{
    partial class Form_Rol_Edit
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
            this.btnRolEdit = new System.Windows.Forms.Button();
            this.btn_permisoDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listPermisos = new FrbaCrucero.UI._Components.DataListViewControl();
            this.btn_permisoAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombreRol = new System.Windows.Forms.TextBox();
            this.checkbox_activo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRolEdit
            // 
            this.btnRolEdit.Location = new System.Drawing.Point(207, 333);
            this.btnRolEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnRolEdit.Name = "btnRolEdit";
            this.btnRolEdit.Size = new System.Drawing.Size(70, 26);
            this.btnRolEdit.TabIndex = 16;
            this.btnRolEdit.Text = "Actualizar";
            this.btnRolEdit.UseVisualStyleBackColor = true;
            this.btnRolEdit.Click += new System.EventHandler(this.btnRolEdit_Click);
            // 
            // btn_permisoDelete
            // 
            this.btn_permisoDelete.Location = new System.Drawing.Point(132, 54);
            this.btn_permisoDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btn_permisoDelete.Name = "btn_permisoDelete";
            this.btn_permisoDelete.Size = new System.Drawing.Size(70, 26);
            this.btn_permisoDelete.TabIndex = 15;
            this.btn_permisoDelete.Text = "Eliminar";
            this.btn_permisoDelete.UseVisualStyleBackColor = true;
            this.btn_permisoDelete.Click += new System.EventHandler(this.btn_permisoDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listPermisos);
            this.groupBox1.Location = new System.Drawing.Point(11, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(273, 244);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos";
            // 
            // listPermisos
            // 
            this.listPermisos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listPermisos.Location = new System.Drawing.Point(23, 22);
            this.listPermisos.Margin = new System.Windows.Forms.Padding(2);
            this.listPermisos.Name = "listPermisos";
            this.listPermisos.Size = new System.Drawing.Size(226, 200);
            this.listPermisos.TabIndex = 1;
            this.listPermisos.UseCompatibleStateImageBehavior = false;
            this.listPermisos.View = System.Windows.Forms.View.Details;
            // 
            // btn_permisoAdd
            // 
            this.btn_permisoAdd.Location = new System.Drawing.Point(207, 54);
            this.btn_permisoAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btn_permisoAdd.Name = "btn_permisoAdd";
            this.btn_permisoAdd.Size = new System.Drawing.Size(70, 26);
            this.btn_permisoAdd.TabIndex = 14;
            this.btn_permisoAdd.Text = "Agregar";
            this.btn_permisoAdd.UseVisualStyleBackColor = true;
            this.btn_permisoAdd.Click += new System.EventHandler(this.btn_permisoAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre:";
            // 
            // tbNombreRol
            // 
            this.tbNombreRol.Location = new System.Drawing.Point(132, 19);
            this.tbNombreRol.Name = "tbNombreRol";
            this.tbNombreRol.Size = new System.Drawing.Size(138, 20);
            this.tbNombreRol.TabIndex = 17;
            // 
            // checkbox_activo
            // 
            this.checkbox_activo.AutoSize = true;
            this.checkbox_activo.Location = new System.Drawing.Point(18, 333);
            this.checkbox_activo.Margin = new System.Windows.Forms.Padding(2);
            this.checkbox_activo.Name = "checkbox_activo";
            this.checkbox_activo.Size = new System.Drawing.Size(56, 17);
            this.checkbox_activo.TabIndex = 18;
            this.checkbox_activo.Text = "Activo";
            this.checkbox_activo.UseVisualStyleBackColor = true;
            // 
            // Form_Rol_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 378);
            this.Controls.Add(this.checkbox_activo);
            this.Controls.Add(this.tbNombreRol);
            this.Controls.Add(this.btnRolEdit);
            this.Controls.Add(this.btn_permisoDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_permisoAdd);
            this.Controls.Add(this.label1);
            this.Name = "Form_Rol_Edit";
            this.Text = "Editar Recorrido";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRolEdit;
        private System.Windows.Forms.Button btn_permisoDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_permisoAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombreRol;
        private System.Windows.Forms.CheckBox checkbox_activo;
        private _Components.DataListViewControl listPermisos;
    }
}