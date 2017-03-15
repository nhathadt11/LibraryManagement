namespace LibraryMaragementClient.Dialogs
{
    partial class CopyDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCopyId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtCopyAvailableYes = new System.Windows.Forms.RadioButton();
            this.rbtCopyAvailableNo = new System.Windows.Forms.RadioButton();
            this.btnCopyOK = new System.Windows.Forms.Button();
            this.btnCopyCancel = new System.Windows.Forms.Button();
            this.cbxBookTitle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtCopyId
            // 
            this.txtCopyId.Location = new System.Drawing.Point(94, 26);
            this.txtCopyId.Name = "txtCopyId";
            this.txtCopyId.Size = new System.Drawing.Size(147, 20);
            this.txtCopyId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Available";
            // 
            // rbtCopyAvailableYes
            // 
            this.rbtCopyAvailableYes.AutoSize = true;
            this.rbtCopyAvailableYes.Location = new System.Drawing.Point(125, 100);
            this.rbtCopyAvailableYes.Name = "rbtCopyAvailableYes";
            this.rbtCopyAvailableYes.Size = new System.Drawing.Size(43, 17);
            this.rbtCopyAvailableYes.TabIndex = 5;
            this.rbtCopyAvailableYes.Text = "Yes";
            this.rbtCopyAvailableYes.UseVisualStyleBackColor = true;
            // 
            // rbtCopyAvailableNo
            // 
            this.rbtCopyAvailableNo.AutoSize = true;
            this.rbtCopyAvailableNo.Checked = true;
            this.rbtCopyAvailableNo.Location = new System.Drawing.Point(192, 100);
            this.rbtCopyAvailableNo.Name = "rbtCopyAvailableNo";
            this.rbtCopyAvailableNo.Size = new System.Drawing.Size(39, 17);
            this.rbtCopyAvailableNo.TabIndex = 6;
            this.rbtCopyAvailableNo.TabStop = true;
            this.rbtCopyAvailableNo.Text = "No";
            this.rbtCopyAvailableNo.UseVisualStyleBackColor = true;
            // 
            // btnCopyOK
            // 
            this.btnCopyOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCopyOK.Location = new System.Drawing.Point(128, 133);
            this.btnCopyOK.Name = "btnCopyOK";
            this.btnCopyOK.Size = new System.Drawing.Size(75, 23);
            this.btnCopyOK.TabIndex = 7;
            this.btnCopyOK.Text = "OK";
            this.btnCopyOK.UseVisualStyleBackColor = true;
            this.btnCopyOK.Click += new System.EventHandler(this.btnCopyOK_Click);
            // 
            // btnCopyCancel
            // 
            this.btnCopyCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCopyCancel.Location = new System.Drawing.Point(233, 133);
            this.btnCopyCancel.Name = "btnCopyCancel";
            this.btnCopyCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCopyCancel.TabIndex = 8;
            this.btnCopyCancel.Text = "Cancel";
            this.btnCopyCancel.UseVisualStyleBackColor = true;
            // 
            // cbxBookTitle
            // 
            this.cbxBookTitle.FormattingEnabled = true;
            this.cbxBookTitle.Location = new System.Drawing.Point(94, 62);
            this.cbxBookTitle.Name = "cbxBookTitle";
            this.cbxBookTitle.Size = new System.Drawing.Size(281, 21);
            this.cbxBookTitle.TabIndex = 9;
            // 
            // CopyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 179);
            this.Controls.Add(this.rbtCopyAvailableYes);
            this.Controls.Add(this.rbtCopyAvailableNo);
            this.Controls.Add(this.cbxBookTitle);
            this.Controls.Add(this.btnCopyCancel);
            this.Controls.Add(this.btnCopyOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCopyId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyDialog";
            this.Text = "CopyDialog";
            this.Load += new System.EventHandler(this.CopyDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCopyId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtCopyAvailableYes;
        private System.Windows.Forms.RadioButton rbtCopyAvailableNo;
        private System.Windows.Forms.Button btnCopyOK;
        private System.Windows.Forms.Button btnCopyCancel;
        private System.Windows.Forms.ComboBox cbxBookTitle;
    }
}