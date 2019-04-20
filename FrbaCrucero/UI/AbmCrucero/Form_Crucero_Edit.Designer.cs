namespace FrbaCrucero.UI.AbmCrucero
{
    partial class Form_Crucero_Edit
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
            this.button_edit = new System.Windows.Forms.Button();
            this.textBox_nombreCrucero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(527, 96);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(167, 41);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "button1";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // textBox_nombreCrucero
            // 
            this.textBox_nombreCrucero.Location = new System.Drawing.Point(434, 205);
            this.textBox_nombreCrucero.Name = "textBox_nombreCrucero";
            this.textBox_nombreCrucero.Size = new System.Drawing.Size(363, 22);
            this.textBox_nombreCrucero.TabIndex = 2;
            // 
            // Form_Crucero_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.textBox_nombreCrucero);
            this.Controls.Add(this.button_edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Crucero_Edit";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.TextBox textBox_nombreCrucero;
    }
}