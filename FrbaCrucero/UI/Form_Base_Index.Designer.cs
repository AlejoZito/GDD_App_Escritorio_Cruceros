namespace FrbaCrucero.UI
{
    partial class Form_Base_Index<T>
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
            this.cruceroDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cruceroDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(527, 96);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(167, 41);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // cruceroDataGridView
            // 
            this.cruceroDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cruceroDataGridView.Location = new System.Drawing.Point(40, 160);
            this.cruceroDataGridView.Name = "cruceroDataGridView";
            this.cruceroDataGridView.RowTemplate.Height = 24;
            this.cruceroDataGridView.Size = new System.Drawing.Size(1200, 526);
            this.cruceroDataGridView.TabIndex = 2;
            this.cruceroDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form_Crucero_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.cruceroDataGridView);
            this.Controls.Add(this.button_edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Crucero_Index";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cruceroDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.DataGridView cruceroDataGridView;
    }
}