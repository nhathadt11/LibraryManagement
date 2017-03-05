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
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.AllowUserToResizeRows = false;
            this.dgvLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Location = new System.Drawing.Point(11, 11);
            this.dgvLoans.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.RowTemplate.Height = 28;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(525, 417);
            this.dgvLoans.TabIndex = 0;
            // 
            // FormLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 439);
            this.Controls.Add(this.dgvLoans);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLoan";
            this.Text = "FormLoan";
            this.Load += new System.EventHandler(this.FormLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoans;
    }
}