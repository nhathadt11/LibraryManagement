namespace LibraryMaragementClient
{
    partial class FormAuthor
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
            this.dgvAuthors = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthorNameFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAuthors
            // 
            this.dgvAuthors.AllowUserToAddRows = false;
            this.dgvAuthors.AllowUserToDeleteRows = false;
            this.dgvAuthors.AllowUserToResizeRows = false;
            this.dgvAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuthors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuthors.Location = new System.Drawing.Point(11, 11);
            this.dgvAuthors.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAuthors.MultiSelect = false;
            this.dgvAuthors.Name = "dgvAuthors";
            this.dgvAuthors.ReadOnly = true;
            this.dgvAuthors.RowTemplate.Height = 28;
            this.dgvAuthors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuthors.Size = new System.Drawing.Size(547, 419);
            this.dgvAuthors.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter by Name";
            // 
            // txtAuthorNameFilter
            // 
            this.txtAuthorNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAuthorNameFilter.Location = new System.Drawing.Point(145, 444);
            this.txtAuthorNameFilter.Name = "txtAuthorNameFilter";
            this.txtAuthorNameFilter.Size = new System.Drawing.Size(218, 20);
            this.txtAuthorNameFilter.TabIndex = 2;
            this.txtAuthorNameFilter.TextChanged += new System.EventHandler(this.txtAuthorNameFilter_TextChanged);
            // 
            // FormAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 476);
            this.Controls.Add(this.txtAuthorNameFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAuthors);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAuthor";
            this.Text = "FormAuthor";
            this.Load += new System.EventHandler(this.FormAuthor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuthors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthorNameFilter;
    }
}