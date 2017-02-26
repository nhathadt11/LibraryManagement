namespace LibraryMaragementClient
{
    partial class FormCopy
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
            this.dgvBookCopys = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCopys)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBookCopys
            // 
            this.dgvBookCopys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookCopys.Location = new System.Drawing.Point(11, 11);
            this.dgvBookCopys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBookCopys.Name = "dgvBookCopys";
            this.dgvBookCopys.RowTemplate.Height = 28;
            this.dgvBookCopys.Size = new System.Drawing.Size(772, 454);
            this.dgvBookCopys.TabIndex = 0;
            // 
            // FormBookCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 476);
            this.Controls.Add(this.dgvBookCopys);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBookCopy";
            this.Text = "FormBookCopy";
            this.Load += new System.EventHandler(this.FormBookCopy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCopys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookCopys;
    }
}