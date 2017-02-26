namespace LibraryMaragementClient
{
    partial class FormPublisher
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
            this.dgvPublishers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublishers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPublishers
            // 
            this.dgvPublishers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublishers.Location = new System.Drawing.Point(11, 11);
            this.dgvPublishers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPublishers.Name = "dgvPublishers";
            this.dgvPublishers.RowTemplate.Height = 28;
            this.dgvPublishers.Size = new System.Drawing.Size(745, 454);
            this.dgvPublishers.TabIndex = 0;
            // 
            // FormPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 476);
            this.Controls.Add(this.dgvPublishers);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormPublisher";
            this.Text = "FormPublisher";
            this.Load += new System.EventHandler(this.FormPublisher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublishers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPublishers;
    }
}