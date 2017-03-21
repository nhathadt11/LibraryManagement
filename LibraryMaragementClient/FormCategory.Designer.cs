namespace LibraryMaragementClient
{
    partial class FormCategory
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
            this.dgvCategorys = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoryNameFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorys)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCategorys
            // 
            this.dgvCategorys.AllowUserToAddRows = false;
            this.dgvCategorys.AllowUserToDeleteRows = false;
            this.dgvCategorys.AllowUserToResizeRows = false;
            this.dgvCategorys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategorys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorys.Location = new System.Drawing.Point(11, 11);
            this.dgvCategorys.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCategorys.MultiSelect = false;
            this.dgvCategorys.Name = "dgvCategorys";
            this.dgvCategorys.ReadOnly = true;
            this.dgvCategorys.RowTemplate.Height = 28;
            this.dgvCategorys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorys.Size = new System.Drawing.Size(445, 428);
            this.dgvCategorys.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter by Name";
            // 
            // txtCategoryNameFilter
            // 
            this.txtCategoryNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCategoryNameFilter.Location = new System.Drawing.Point(121, 457);
            this.txtCategoryNameFilter.Name = "txtCategoryNameFilter";
            this.txtCategoryNameFilter.Size = new System.Drawing.Size(208, 20);
            this.txtCategoryNameFilter.TabIndex = 2;
            this.txtCategoryNameFilter.TextChanged += new System.EventHandler(this.txtCategoryNameFilter_TextChanged);
            // 
            // FormCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 489);
            this.Controls.Add(this.txtCategoryNameFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCategorys);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCategory";
            this.Text = "FormCategory";
            this.Load += new System.EventHandler(this.FormCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategorys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryNameFilter;
    }
}