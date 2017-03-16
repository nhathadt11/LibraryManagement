namespace LibraryMaragementClient
{
    partial class FormBook
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
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookFilter = new System.Windows.Forms.TextBox();
            this.rtbBookId = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtBookTitle = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(12, 12);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(868, 397);
            this.dgvBooks.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            // 
            // txtBookFilter
            // 
            this.txtBookFilter.Location = new System.Drawing.Point(90, 428);
            this.txtBookFilter.Name = "txtBookFilter";
            this.txtBookFilter.Size = new System.Drawing.Size(245, 20);
            this.txtBookFilter.TabIndex = 2;
            this.txtBookFilter.TextChanged += new System.EventHandler(this.txtBookFilter_TextChanged);
            // 
            // rtbBookId
            // 
            this.rtbBookId.AutoSize = true;
            this.rtbBookId.Checked = true;
            this.rtbBookId.Location = new System.Drawing.Point(423, 429);
            this.rtbBookId.Name = "rtbBookId";
            this.rtbBookId.Size = new System.Drawing.Size(36, 17);
            this.rtbBookId.TabIndex = 3;
            this.rtbBookId.TabStop = true;
            this.rtbBookId.Text = "ID";
            this.rtbBookId.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "by";
            // 
            // rbtBookTitle
            // 
            this.rbtBookTitle.AutoSize = true;
            this.rbtBookTitle.Location = new System.Drawing.Point(480, 429);
            this.rbtBookTitle.Name = "rbtBookTitle";
            this.rbtBookTitle.Size = new System.Drawing.Size(45, 17);
            this.rbtBookTitle.TabIndex = 5;
            this.rbtBookTitle.TabStop = true;
            this.rbtBookTitle.Text = "Title";
            this.rbtBookTitle.UseVisualStyleBackColor = true;
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 465);
            this.Controls.Add(this.rbtBookTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbBookId);
            this.Controls.Add(this.txtBookFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBooks);
            this.Name = "FormBook";
            this.Text = "FormBook";
            this.Load += new System.EventHandler(this.FormBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookFilter;
        private System.Windows.Forms.RadioButton rtbBookId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtBookTitle;
    }
}