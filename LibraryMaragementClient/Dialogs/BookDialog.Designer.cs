namespace LibraryMaragementClient.Dialogs
{
    partial class BookDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.txtBookIsbn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookPageNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBookPublishedDate = new System.Windows.Forms.DateTimePicker();
            this.cbxBookPublisher = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxBookCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxBookAuthor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtBookDiscontinuedYes = new System.Windows.Forms.RadioButton();
            this.rbtBookDiscontinuedNo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBookImageUrl = new System.Windows.Forms.TextBox();
            this.btnBookCoverImage = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.rtxtBookDescription = new System.Windows.Forms.RichTextBox();
            this.btnBookOK = new System.Windows.Forms.Button();
            this.btnBookCancel = new System.Windows.Forms.Button();
            this.epvBookIsbn = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvBookTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvBookPublisher = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvBookAuthor = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvBookCategory = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvBookPublishedDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvBookPageNumber = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epvBookIsbn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookPublisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookPublishedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookPageNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(126, 28);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.ReadOnly = true;
            this.txtBookId.Size = new System.Drawing.Size(100, 20);
            this.txtBookId.TabIndex = 1;
            // 
            // txtBookIsbn
            // 
            this.txtBookIsbn.Location = new System.Drawing.Point(126, 54);
            this.txtBookIsbn.Name = "txtBookIsbn";
            this.txtBookIsbn.Size = new System.Drawing.Size(175, 20);
            this.txtBookIsbn.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ISBN";
            // 
            // txtBookPageNumber
            // 
            this.txtBookPageNumber.Location = new System.Drawing.Point(126, 215);
            this.txtBookPageNumber.Name = "txtBookPageNumber";
            this.txtBookPageNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBookPageNumber.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Publisher";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Location = new System.Drawing.Point(126, 82);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(275, 20);
            this.txtBookTitle.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Publish Date";
            // 
            // dtpBookPublishedDate
            // 
            this.dtpBookPublishedDate.Location = new System.Drawing.Point(126, 189);
            this.dtpBookPublishedDate.Name = "dtpBookPublishedDate";
            this.dtpBookPublishedDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBookPublishedDate.TabIndex = 9;
            // 
            // cbxBookPublisher
            // 
            this.cbxBookPublisher.FormattingEnabled = true;
            this.cbxBookPublisher.Location = new System.Drawing.Point(126, 108);
            this.cbxBookPublisher.Name = "cbxBookPublisher";
            this.cbxBookPublisher.Size = new System.Drawing.Size(200, 21);
            this.cbxBookPublisher.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Page Number";
            // 
            // cbxBookCategory
            // 
            this.cbxBookCategory.FormattingEnabled = true;
            this.cbxBookCategory.Location = new System.Drawing.Point(126, 162);
            this.cbxBookCategory.Name = "cbxBookCategory";
            this.cbxBookCategory.Size = new System.Drawing.Size(200, 21);
            this.cbxBookCategory.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Category";
            // 
            // cbxBookAuthor
            // 
            this.cbxBookAuthor.FormattingEnabled = true;
            this.cbxBookAuthor.Location = new System.Drawing.Point(126, 135);
            this.cbxBookAuthor.Name = "cbxBookAuthor";
            this.cbxBookAuthor.Size = new System.Drawing.Size(200, 21);
            this.cbxBookAuthor.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Author";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Discontinued";
            // 
            // rbtBookDiscontinuedYes
            // 
            this.rbtBookDiscontinuedYes.AutoSize = true;
            this.rbtBookDiscontinuedYes.Location = new System.Drawing.Point(126, 245);
            this.rbtBookDiscontinuedYes.Name = "rbtBookDiscontinuedYes";
            this.rbtBookDiscontinuedYes.Size = new System.Drawing.Size(43, 17);
            this.rbtBookDiscontinuedYes.TabIndex = 17;
            this.rbtBookDiscontinuedYes.Text = "Yes";
            this.rbtBookDiscontinuedYes.UseVisualStyleBackColor = true;
            // 
            // rbtBookDiscontinuedNo
            // 
            this.rbtBookDiscontinuedNo.AutoSize = true;
            this.rbtBookDiscontinuedNo.Checked = true;
            this.rbtBookDiscontinuedNo.Location = new System.Drawing.Point(217, 245);
            this.rbtBookDiscontinuedNo.Name = "rbtBookDiscontinuedNo";
            this.rbtBookDiscontinuedNo.Size = new System.Drawing.Size(39, 17);
            this.rbtBookDiscontinuedNo.TabIndex = 18;
            this.rbtBookDiscontinuedNo.TabStop = true;
            this.rbtBookDiscontinuedNo.Text = "No";
            this.rbtBookDiscontinuedNo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cover Image";
            // 
            // txtBookImageUrl
            // 
            this.txtBookImageUrl.Location = new System.Drawing.Point(126, 271);
            this.txtBookImageUrl.Name = "txtBookImageUrl";
            this.txtBookImageUrl.Size = new System.Drawing.Size(200, 20);
            this.txtBookImageUrl.TabIndex = 20;
            // 
            // btnBookCoverImage
            // 
            this.btnBookCoverImage.Location = new System.Drawing.Point(332, 269);
            this.btnBookCoverImage.Name = "btnBookCoverImage";
            this.btnBookCoverImage.Size = new System.Drawing.Size(75, 23);
            this.btnBookCoverImage.TabIndex = 21;
            this.btnBookCoverImage.Text = "Browse";
            this.btnBookCoverImage.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Description";
            // 
            // rtxtBookDescription
            // 
            this.rtxtBookDescription.Location = new System.Drawing.Point(45, 314);
            this.rtxtBookDescription.Name = "rtxtBookDescription";
            this.rtxtBookDescription.Size = new System.Drawing.Size(362, 122);
            this.rtxtBookDescription.TabIndex = 23;
            this.rtxtBookDescription.Text = "";
            // 
            // btnBookOK
            // 
            this.btnBookOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBookOK.Location = new System.Drawing.Point(126, 454);
            this.btnBookOK.Name = "btnBookOK";
            this.btnBookOK.Size = new System.Drawing.Size(75, 23);
            this.btnBookOK.TabIndex = 24;
            this.btnBookOK.Text = "OK";
            this.btnBookOK.UseVisualStyleBackColor = true;
            this.btnBookOK.Click += new System.EventHandler(this.btnBookOK_Click);
            // 
            // btnBookCancel
            // 
            this.btnBookCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBookCancel.Location = new System.Drawing.Point(226, 454);
            this.btnBookCancel.Name = "btnBookCancel";
            this.btnBookCancel.Size = new System.Drawing.Size(75, 23);
            this.btnBookCancel.TabIndex = 25;
            this.btnBookCancel.Text = "Cancel";
            this.btnBookCancel.UseVisualStyleBackColor = true;
            // 
            // epvBookIsbn
            // 
            this.epvBookIsbn.ContainerControl = this;
            // 
            // epvBookTitle
            // 
            this.epvBookTitle.ContainerControl = this;
            // 
            // epvBookPublisher
            // 
            this.epvBookPublisher.ContainerControl = this;
            // 
            // epvBookAuthor
            // 
            this.epvBookAuthor.ContainerControl = this;
            // 
            // epvBookCategory
            // 
            this.epvBookCategory.ContainerControl = this;
            // 
            // epvBookPublishedDate
            // 
            this.epvBookPublishedDate.ContainerControl = this;
            // 
            // epvBookPageNumber
            // 
            this.epvBookPageNumber.ContainerControl = this;
            // 
            // BookDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 482);
            this.Controls.Add(this.btnBookCancel);
            this.Controls.Add(this.btnBookOK);
            this.Controls.Add(this.rtxtBookDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBookCoverImage);
            this.Controls.Add(this.txtBookImageUrl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rbtBookDiscontinuedNo);
            this.Controls.Add(this.rbtBookDiscontinuedYes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxBookAuthor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxBookCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxBookPublisher);
            this.Controls.Add(this.dtpBookPublishedDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBookPageNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBookIsbn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBookId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Book details Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.epvBookIsbn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookPublisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookPublishedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvBookPageNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.TextBox txtBookIsbn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBookPageNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBookPublishedDate;
        private System.Windows.Forms.ComboBox cbxBookPublisher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxBookCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxBookAuthor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtBookDiscontinuedYes;
        private System.Windows.Forms.RadioButton rbtBookDiscontinuedNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBookImageUrl;
        private System.Windows.Forms.Button btnBookCoverImage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtxtBookDescription;
        private System.Windows.Forms.Button btnBookOK;
        private System.Windows.Forms.Button btnBookCancel;
        private System.Windows.Forms.ErrorProvider epvBookIsbn;
        private System.Windows.Forms.ErrorProvider epvBookTitle;
        private System.Windows.Forms.ErrorProvider epvBookPublisher;
        private System.Windows.Forms.ErrorProvider epvBookAuthor;
        private System.Windows.Forms.ErrorProvider epvBookCategory;
        private System.Windows.Forms.ErrorProvider epvBookPublishedDate;
        private System.Windows.Forms.ErrorProvider epvBookPageNumber;
    }
}