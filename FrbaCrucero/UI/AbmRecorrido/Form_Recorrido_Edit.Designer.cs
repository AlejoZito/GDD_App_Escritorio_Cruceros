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
            this.listTramos = new FrbaCrucero.UI._Components.DataListViewControl();
            this.btnRecorridoAdd = new System.Windows.Forms.Button();
            this.btn_TramoDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDown = new System.Windows.Forms.PictureBox();
            this.buttonUp = new System.Windows.Forms.PictureBox();
            this.btn_tramoAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkbox_activo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonUp)).BeginInit();
            this.SuspendLayout();
            // 
            // listTramos
            // 
            this.listTramos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listTramos.Location = new System.Drawing.Point(44, 33);
            this.listTramos.Name = "listTramos";
            this.listTramos.Size = new System.Drawing.Size(300, 245);
            this.listTramos.TabIndex = 0;
            this.listTramos.UseCompatibleStateImageBehavior = false;
            this.listTramos.View = System.Windows.Forms.View.Details;
            // 
            // btnRecorridoAdd
            // 
            this.btnRecorridoAdd.Location = new System.Drawing.Point(281, 377);
            this.btnRecorridoAdd.Name = "btnRecorridoAdd";
            this.btnRecorridoAdd.Size = new System.Drawing.Size(94, 32);
            this.btnRecorridoAdd.TabIndex = 10;
            this.btnRecorridoAdd.Text = "Actualizar";
            this.btnRecorridoAdd.UseVisualStyleBackColor = true;
            // 
            // btn_TramoDelete
            // 
            this.btn_TramoDelete.Location = new System.Drawing.Point(181, 33);
            this.btn_TramoDelete.Name = "btn_TramoDelete";
            this.btn_TramoDelete.Size = new System.Drawing.Size(94, 32);
            this.btn_TramoDelete.TabIndex = 9;
            this.btn_TramoDelete.Text = "Eliminar";
            this.btn_TramoDelete.UseVisualStyleBackColor = true;
            this.btn_TramoDelete.Click += new System.EventHandler(this.btn_TramoDelete_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.buttonDown);
            this.groupBox1.Controls.Add(this.buttonUp);
            this.groupBox1.Controls.Add(this.listTramos);
            this.groupBox1.Location = new System.Drawing.Point(20, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 300);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tramos";
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDown.Image = global::FrbaCrucero.Properties.Resources.icons8_down_button_24;
            this.buttonDown.InitialImage = null;
            this.buttonDown.Location = new System.Drawing.Point(9, 140);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(24, 24);
            this.buttonDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.buttonDown.TabIndex = 2;
            this.buttonDown.TabStop = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUp.Image = global::FrbaCrucero.Properties.Resources.icons8_slide_up_24;
            this.buttonUp.InitialImage = null;
            this.buttonUp.Location = new System.Drawing.Point(9, 110);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(24, 24);
            this.buttonUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.buttonUp.TabIndex = 1;
            this.buttonUp.TabStop = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // btn_tramoAdd
            // 
            this.btn_tramoAdd.Location = new System.Drawing.Point(281, 33);
            this.btn_tramoAdd.Name = "btn_tramoAdd";
            this.btn_tramoAdd.Size = new System.Drawing.Size(94, 32);
            this.btn_tramoAdd.TabIndex = 8;
            this.btn_tramoAdd.Text = "Agregar";
            this.btn_tramoAdd.UseVisualStyleBackColor = true;
            this.btn_tramoAdd.Click += new System.EventHandler(this.btn_tramoAdd_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Editar recorrido";
            // 
            // checkbox_activo
            // 
            this.checkbox_activo.AutoSize = true;
            this.checkbox_activo.Location = new System.Drawing.Point(29, 377);
            this.checkbox_activo.Name = "checkbox_activo";
            this.checkbox_activo.Size = new System.Drawing.Size(68, 21);
            this.checkbox_activo.TabIndex = 11;
            this.checkbox_activo.Text = "Activo";
            this.checkbox_activo.UseVisualStyleBackColor = true;
            // 
            // Form_Recorrido_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 438);
            this.Controls.Add(this.checkbox_activo);
            this.Controls.Add(this.btnRecorridoAdd);
            this.Controls.Add(this.btn_TramoDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_tramoAdd);
            this.Controls.Add(this.label1);
            this.Name = "Form_Recorrido_Edit";
            this.Text = "Form_Recorrido_Edit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _Components.DataListViewControl listTramos;
        private System.Windows.Forms.Button btnRecorridoAdd;
        private System.Windows.Forms.Button btn_TramoDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox buttonDown;
        private System.Windows.Forms.PictureBox buttonUp;
        private System.Windows.Forms.Button btn_tramoAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkbox_activo;

    }
}