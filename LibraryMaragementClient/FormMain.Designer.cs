﻿namespace LibraryMaragementClient
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
            this.tsbtEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtBook = new System.Windows.Forms.ToolStripButton();
            this.tsbtAuthor = new System.Windows.Forms.ToolStripButton();
            this.tsbtCategory = new System.Windows.Forms.ToolStripButton();
            this.tsbtCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbtPublisher = new System.Windows.Forms.ToolStripButton();
            this.tsbtLoan = new System.Windows.Forms.ToolStripButton();
            this.tsbtMember = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtNew,
            this.tsbtEdit,
            this.tsbtDelete,
            this.toolStripSeparator1,
            this.tsbtBook,
            this.tsbtAuthor,
            this.tsbtCategory,
            this.tsbtCopy,
            this.tsbtPublisher,
            this.tsbtLoan,
            this.tsbtMember,
            this.toolStripSeparator2,
            this.tsbLogout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(908, 52);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtNew
            // 
            this.tsbtNew.AutoSize = false;
            this.tsbtNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtNew.Image")));
            this.tsbtNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtNew.Name = "tsbtNew";
            this.tsbtNew.Size = new System.Drawing.Size(100, 80);
            this.tsbtNew.Text = "Add";
            this.tsbtNew.Click += new System.EventHandler(this.tsbtNew_Click);
            // 
            // tsbtEdit
            // 
            this.tsbtEdit.AutoSize = false;
            this.tsbtEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtEdit.Image")));
            this.tsbtEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEdit.Name = "tsbtEdit";
            this.tsbtEdit.Size = new System.Drawing.Size(100, 80);
            this.tsbtEdit.Text = "Edit";
            this.tsbtEdit.Click += new System.EventHandler(this.tsbtEdit_Click);
            // 
            // tsbtDelete
            // 
            this.tsbtDelete.AutoSize = false;
            this.tsbtDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtDelete.Image")));
            this.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDelete.Name = "tsbtDelete";
            this.tsbtDelete.Size = new System.Drawing.Size(100, 80);
            this.tsbtDelete.Text = "Delete";
            this.tsbtDelete.Click += new System.EventHandler(this.tsbtDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbtBook
            // 
            this.tsbtBook.AutoSize = false;
            this.tsbtBook.Image = ((System.Drawing.Image)(resources.GetObject("tsbtBook.Image")));
            this.tsbtBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtBook.Name = "tsbtBook";
            this.tsbtBook.Size = new System.Drawing.Size(120, 80);
            this.tsbtBook.Text = "Book";
            this.tsbtBook.Click += new System.EventHandler(this.tsbtBook_Click);
            // 
            // tsbtAuthor
            // 
            this.tsbtAuthor.AutoSize = false;
            this.tsbtAuthor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtAuthor.Image")));
            this.tsbtAuthor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtAuthor.Name = "tsbtAuthor";
            this.tsbtAuthor.Size = new System.Drawing.Size(120, 80);
            this.tsbtAuthor.Text = "Author";
            this.tsbtAuthor.Click += new System.EventHandler(this.tsbtAuthor_Click);
            // 
            // tsbtCategory
            // 
            this.tsbtCategory.AutoSize = false;
            this.tsbtCategory.Image = ((System.Drawing.Image)(resources.GetObject("tsbtCategory.Image")));
            this.tsbtCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCategory.Name = "tsbtCategory";
            this.tsbtCategory.Size = new System.Drawing.Size(120, 80);
            this.tsbtCategory.Text = "Category";
            this.tsbtCategory.Click += new System.EventHandler(this.tsbtCategory_Click);
            // 
            // tsbtCopy
            // 
            this.tsbtCopy.AutoSize = false;
            this.tsbtCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbtCopy.Image")));
            this.tsbtCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCopy.Name = "tsbtCopy";
            this.tsbtCopy.Size = new System.Drawing.Size(120, 80);
            this.tsbtCopy.Text = "Book Copy";
            this.tsbtCopy.Click += new System.EventHandler(this.tsbtCopy_Click);
            // 
            // tsbtPublisher
            // 
            this.tsbtPublisher.AutoSize = false;
            this.tsbtPublisher.Image = ((System.Drawing.Image)(resources.GetObject("tsbtPublisher.Image")));
            this.tsbtPublisher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtPublisher.Name = "tsbtPublisher";
            this.tsbtPublisher.Size = new System.Drawing.Size(120, 80);
            this.tsbtPublisher.Text = "Publisher";
            this.tsbtPublisher.Click += new System.EventHandler(this.tsbtPublisher_Click);
            // 
            // tsbtLoan
            // 
            this.tsbtLoan.AutoSize = false;
            this.tsbtLoan.Image = ((System.Drawing.Image)(resources.GetObject("tsbtLoan.Image")));
            this.tsbtLoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtLoan.Name = "tsbtLoan";
            this.tsbtLoan.Size = new System.Drawing.Size(120, 80);
            this.tsbtLoan.Text = "Loan";
            this.tsbtLoan.Click += new System.EventHandler(this.tsbtLoan_Click);
            // 
            // tsbtMember
            // 
            this.tsbtMember.AutoSize = false;
            this.tsbtMember.Image = ((System.Drawing.Image)(resources.GetObject("tsbtMember.Image")));
            this.tsbtMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtMember.Name = "tsbtMember";
            this.tsbtMember.Size = new System.Drawing.Size(120, 80);
            this.tsbtMember.Text = "Member";
            this.tsbtMember.Click += new System.EventHandler(this.tsbtMember_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // tsbLogout
            // 
            this.tsbLogout.AutoSize = false;
            this.tsbLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogout.Image")));
            this.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(73, 28);
            this.tsbLogout.Text = "Logout";
            this.tsbLogout.Click += new System.EventHandler(this.tsbLogout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 482);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "Library Management Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
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
        private System.Windows.Forms.ToolStripButton tsbtEdit;
        private System.Windows.Forms.ToolStripButton tsbtDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbLogout;
    }
}

