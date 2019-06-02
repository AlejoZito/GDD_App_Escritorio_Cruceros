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
            this.indexDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.indexDataGridView)).BeginInit();
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
            // indexDataGridView
            // 
            this.indexDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indexDataGridView.Location = new System.Drawing.Point(40, 160);
            this.indexDataGridView.Name = "indexDataGridView";
            this.indexDataGridView.RowTemplate.Height = 24;
            this.indexDataGridView.Size = new System.Drawing.Size(1200, 526);
            this.indexDataGridView.TabIndex = 2;
            this.indexDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form_Base_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.indexDataGridView);
            this.Controls.Add(this.button_edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Base_Index";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.indexDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.DataGridView indexDataGridView;
    }
}