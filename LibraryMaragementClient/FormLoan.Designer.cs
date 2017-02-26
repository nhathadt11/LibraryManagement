namespace LibraryMaragementClient
{
    partial class FormLoan
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
            this.dgvLoan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoan
            // 
            this.dgvLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoan.Location = new System.Drawing.Point(11, 11);
            this.dgvLoan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLoan.Name = "dgvLoan";
            this.dgvLoan.RowTemplate.Height = 28;
            this.dgvLoan.Size = new System.Drawing.Size(773, 454);
            this.dgvLoan.TabIndex = 0;
            // 
            // FormLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 476);
            this.Controls.Add(this.dgvLoan);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLoan";
            this.Text = "FormLoan";
            this.Load += new System.EventHandler(this.FormLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoan;
    }
}