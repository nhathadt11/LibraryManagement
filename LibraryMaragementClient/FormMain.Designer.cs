namespace LibraryMaragementClient
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtBook = new System.Windows.Forms.ToolStripButton();
            this.tsbtAuthor = new System.Windows.Forms.ToolStripButton();
            this.tsbtCategory = new System.Windows.Forms.ToolStripButton();
            this.tsbtCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbtPublisher = new System.Windows.Forms.ToolStripButton();
            this.tsbtLoan = new System.Windows.Forms.ToolStripButton();
            this.tsbtMember = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtNew,
            this.tsbtBook,
            this.tsbtAuthor,
            this.tsbtCategory,
            this.tsbtCopy,
            this.tsbtPublisher,
            this.tsbtLoan,
            this.tsbtMember});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(999, 65);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtNew
            // 
            this.tsbtNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtNew.Image")));
            this.tsbtNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtNew.Name = "tsbtNew";
            this.tsbtNew.Size = new System.Drawing.Size(51, 62);
            this.tsbtNew.Text = "New";
            // 
            // tsbtBook
            // 
            this.tsbtBook.Image = ((System.Drawing.Image)(resources.GetObject("tsbtBook.Image")));
            this.tsbtBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtBook.Name = "tsbtBook";
            this.tsbtBook.Size = new System.Drawing.Size(54, 62);
            this.tsbtBook.Text = "Book";
            this.tsbtBook.Click += new System.EventHandler(this.tsbtBook_Click);
            // 
            // tsbtAuthor
            // 
            this.tsbtAuthor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtAuthor.Image")));
            this.tsbtAuthor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtAuthor.Name = "tsbtAuthor";
            this.tsbtAuthor.Size = new System.Drawing.Size(64, 62);
            this.tsbtAuthor.Text = "Author";
            this.tsbtAuthor.Click += new System.EventHandler(this.tsbtAuthor_Click);
            // 
            // tsbtCategory
            // 
            this.tsbtCategory.Image = ((System.Drawing.Image)(resources.GetObject("tsbtCategory.Image")));
            this.tsbtCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCategory.Name = "tsbtCategory";
            this.tsbtCategory.Size = new System.Drawing.Size(75, 62);
            this.tsbtCategory.Text = "Category";
            // 
            // tsbtCopy
            // 
            this.tsbtCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbtCopy.Image")));
            this.tsbtCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCopy.Name = "tsbtCopy";
            this.tsbtCopy.Size = new System.Drawing.Size(55, 62);
            this.tsbtCopy.Text = "Copy";
            // 
            // tsbtPublisher
            // 
            this.tsbtPublisher.Image = ((System.Drawing.Image)(resources.GetObject("tsbtPublisher.Image")));
            this.tsbtPublisher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtPublisher.Name = "tsbtPublisher";
            this.tsbtPublisher.Size = new System.Drawing.Size(76, 62);
            this.tsbtPublisher.Text = "Publisher";
            // 
            // tsbtLoan
            // 
            this.tsbtLoan.Image = ((System.Drawing.Image)(resources.GetObject("tsbtLoan.Image")));
            this.tsbtLoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtLoan.Name = "tsbtLoan";
            this.tsbtLoan.Size = new System.Drawing.Size(53, 62);
            this.tsbtLoan.Text = "Loan";
            // 
            // tsbtMember
            // 
            this.tsbtMember.Image = ((System.Drawing.Image)(resources.GetObject("tsbtMember.Image")));
            this.tsbtMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtMember.Name = "tsbtMember";
            this.tsbtMember.Size = new System.Drawing.Size(72, 62);
            this.tsbtMember.Text = "Member";
            this.tsbtMember.Click += new System.EventHandler(this.tsbtMember_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 508);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "Library Management Client";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtBook;
        private System.Windows.Forms.ToolStripButton tsbtNew;
        private System.Windows.Forms.ToolStripButton tsbtAuthor;
        private System.Windows.Forms.ToolStripButton tsbtCategory;
        private System.Windows.Forms.ToolStripButton tsbtCopy;
        private System.Windows.Forms.ToolStripButton tsbtPublisher;
        private System.Windows.Forms.ToolStripButton tsbtLoan;
        private System.Windows.Forms.ToolStripButton tsbtMember;
    }
}

