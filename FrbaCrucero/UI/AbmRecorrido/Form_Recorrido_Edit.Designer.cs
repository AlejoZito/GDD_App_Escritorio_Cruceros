namespace FrbaCrucero.UI.AbmRecorrido
{
    partial class Form_Recorrido_Edit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listTramos = new FrbaCrucero.UI._Components.DataListViewControl();
            this.btn_tramoAdd = new System.Windows.Forms.Button();
            this.btn_TramoDelete = new System.Windows.Forms.Button();
            this.checkbox_activo = new System.Windows.Forms.CheckBox();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editar recorrido";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listTramos);
            this.groupBox1.Location = new System.Drawing.Point(32, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tramos";
            // 
            // listTramos
            // 
            this.listTramos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listTramos.Location = new System.Drawing.Point(18, 33);
            this.listTramos.Name = "listTramos";
            this.listTramos.Size = new System.Drawing.Size(301, 245);
            this.listTramos.TabIndex = 0;
            this.listTramos.UseCompatibleStateImageBehavior = false;
            this.listTramos.View = System.Windows.Forms.View.Details;
            // 
            // btn_tramoAdd
            // 
            this.btn_tramoAdd.Location = new System.Drawing.Point(270, 27);
            this.btn_tramoAdd.Name = "btn_tramoAdd";
            this.btn_tramoAdd.Size = new System.Drawing.Size(94, 32);
            this.btn_tramoAdd.TabIndex = 3;
            this.btn_tramoAdd.Text = "Agregar";
            this.btn_tramoAdd.UseVisualStyleBackColor = true;
            this.btn_tramoAdd.Click += new System.EventHandler(this.btn_tramoAdd_Click_1);
            // 
            // btn_TramoDelete
            // 
            this.btn_TramoDelete.Location = new System.Drawing.Point(170, 27);
            this.btn_TramoDelete.Name = "btn_TramoDelete";
            this.btn_TramoDelete.Size = new System.Drawing.Size(94, 32);
            this.btn_TramoDelete.TabIndex = 4;
            this.btn_TramoDelete.Text = "Eliminar";
            this.btn_TramoDelete.UseVisualStyleBackColor = true;
            this.btn_TramoDelete.Click += new System.EventHandler(this.btn_TramoDelete_Click_1);
            // 
            // checkbox_activo
            // 
            this.checkbox_activo.AutoSize = true;
            this.checkbox_activo.Location = new System.Drawing.Point(302, 349);
            this.checkbox_activo.Name = "checkbox_activo";
            this.checkbox_activo.Size = new System.Drawing.Size(68, 21);
            this.checkbox_activo.TabIndex = 5;
            this.checkbox_activo.Text = "Activo";
            this.checkbox_activo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkbox_activo.UseVisualStyleBackColor = true;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Location = new System.Drawing.Point(276, 394);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(94, 32);
            this.btn_actualizar.TabIndex = 6;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // Form_Recorrido_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 438);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.checkbox_activo);
            this.Controls.Add(this.btn_TramoDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_tramoAdd);
            this.Controls.Add(this.label1);
            this.Name = "Form_Recorrido_Edit";
            this.Text = "Form_Recorrido_Edit";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_tramoAdd;
        private _Components.DataListViewControl listTramos;
        private System.Windows.Forms.Button btn_TramoDelete;
        private System.Windows.Forms.CheckBox checkbox_activo;
        private System.Windows.Forms.Button btn_actualizar;
    }
}