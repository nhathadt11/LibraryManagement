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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoanFilter = new System.Windows.Forms.TextBox();
            this.rbtLoanId = new System.Windows.Forms.RadioButton();
            this.rbtLoanMemberId = new System.Windows.Forms.RadioButton();
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
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.RowTemplate.Height = 28;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(525, 380);
            this.dgvLoans.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            // 
            // txtLoanFilter
            // 
            this.txtLoanFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLoanFilter.Location = new System.Drawing.Point(86, 405);
            this.txtLoanFilter.Name = "txtLoanFilter";
            this.txtLoanFilter.Size = new System.Drawing.Size(210, 20);
            this.txtLoanFilter.TabIndex = 2;
            this.txtLoanFilter.TextChanged += new System.EventHandler(this.txtLoanFilter_TextChanged);
            // 
            // rbtLoanId
            // 
            this.rbtLoanId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtLoanId.AutoSize = true;
            this.rbtLoanId.Location = new System.Drawing.Point(326, 408);
            this.rbtLoanId.Name = "rbtLoanId";
            this.rbtLoanId.Size = new System.Drawing.Size(60, 17);
            this.rbtLoanId.TabIndex = 3;
            this.rbtLoanId.Text = "LoanID";
            this.rbtLoanId.UseVisualStyleBackColor = true;
            // 
            // rbtLoanMemberId
            // 
            this.rbtLoanMemberId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtLoanMemberId.AutoSize = true;
            this.rbtLoanMemberId.Checked = true;
            this.rbtLoanMemberId.Location = new System.Drawing.Point(392, 408);
            this.rbtLoanMemberId.Name = "rbtLoanMemberId";
            this.rbtLoanMemberId.Size = new System.Drawing.Size(74, 17);
            this.rbtLoanMemberId.TabIndex = 4;
            this.rbtLoanMemberId.TabStop = true;
            this.rbtLoanMemberId.Text = "MemberID";
            this.rbtLoanMemberId.UseVisualStyleBackColor = true;
            // 
            // FormLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 439);
            this.Controls.Add(this.rbtLoanMemberId);
            this.Controls.Add(this.rbtLoanId);
            this.Controls.Add(this.txtLoanFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLoans);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLoan";
            this.Text = "FormLoan";
            this.Load += new System.EventHandler(this.FormLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoanFilter;
        private System.Windows.Forms.RadioButton rbtLoanId;
        private System.Windows.Forms.RadioButton rbtLoanMemberId;
    }
}