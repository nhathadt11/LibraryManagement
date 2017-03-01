namespace LibraryMaragementClient.Dialogs
{
    partial class AuthorDialog
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
            this.txtAuthorId = new System.Windows.Forms.TextBox();
            this.txtAuthorFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthorContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthorAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtAuthorBio = new System.Windows.Forms.RichTextBox();
            this.btnAuthorOK = new System.Windows.Forms.Button();
            this.btnAuthorCancel = new System.Windows.Forms.Button();
            this.epvAuthorFullName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvAuthorContact = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvAuthorAddress = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epvAuthorFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvAuthorContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvAuthorAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtAuthorId
            // 
            this.txtAuthorId.Location = new System.Drawing.Point(86, 29);
            this.txtAuthorId.Name = "txtAuthorId";
            this.txtAuthorId.ReadOnly = true;
            this.txtAuthorId.Size = new System.Drawing.Size(100, 20);
            this.txtAuthorId.TabIndex = 1;
            // 
            // txtAuthorFullName
            // 
            this.txtAuthorFullName.Location = new System.Drawing.Point(86, 55);
            this.txtAuthorFullName.Name = "txtAuthorFullName";
            this.txtAuthorFullName.Size = new System.Drawing.Size(198, 20);
            this.txtAuthorFullName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Full name";
            // 
            // txtAuthorContact
            // 
            this.txtAuthorContact.Location = new System.Drawing.Point(86, 81);
            this.txtAuthorContact.Name = "txtAuthorContact";
            this.txtAuthorContact.Size = new System.Drawing.Size(198, 20);
            this.txtAuthorContact.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contact";
            // 
            // txtAuthorAddress
            // 
            this.txtAuthorAddress.Location = new System.Drawing.Point(86, 107);
            this.txtAuthorAddress.Name = "txtAuthorAddress";
            this.txtAuthorAddress.Size = new System.Drawing.Size(275, 20);
            this.txtAuthorAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bio";
            // 
            // rtxtAuthorBio
            // 
            this.rtxtAuthorBio.Location = new System.Drawing.Point(86, 133);
            this.rtxtAuthorBio.Name = "rtxtAuthorBio";
            this.rtxtAuthorBio.Size = new System.Drawing.Size(275, 149);
            this.rtxtAuthorBio.TabIndex = 9;
            this.rtxtAuthorBio.Text = "";
            // 
            // btnAuthorOK
            // 
            this.btnAuthorOK.Location = new System.Drawing.Point(111, 308);
            this.btnAuthorOK.Name = "btnAuthorOK";
            this.btnAuthorOK.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorOK.TabIndex = 10;
            this.btnAuthorOK.Text = "OK";
            this.btnAuthorOK.UseVisualStyleBackColor = true;
            this.btnAuthorOK.Click += new System.EventHandler(this.btnAuthorOK_Click);
            // 
            // btnAuthorCancel
            // 
            this.btnAuthorCancel.Location = new System.Drawing.Point(209, 308);
            this.btnAuthorCancel.Name = "btnAuthorCancel";
            this.btnAuthorCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorCancel.TabIndex = 11;
            this.btnAuthorCancel.Text = "Cancel";
            this.btnAuthorCancel.UseVisualStyleBackColor = true;
            // 
            // epvAuthorFullName
            // 
            this.epvAuthorFullName.ContainerControl = this;
            // 
            // epvAuthorContact
            // 
            this.epvAuthorContact.ContainerControl = this;
            // 
            // epvAuthorAddress
            // 
            this.epvAuthorAddress.ContainerControl = this;
            // 
            // AuthorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 353);
            this.Controls.Add(this.btnAuthorCancel);
            this.Controls.Add(this.btnAuthorOK);
            this.Controls.Add(this.rtxtAuthorBio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAuthorAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAuthorContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAuthorFullName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAuthorId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorDialog";
            this.Text = "Author Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.epvAuthorFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvAuthorContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvAuthorAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthorId;
        private System.Windows.Forms.TextBox txtAuthorFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthorContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthorAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxtAuthorBio;
        private System.Windows.Forms.Button btnAuthorOK;
        private System.Windows.Forms.Button btnAuthorCancel;
        private System.Windows.Forms.ErrorProvider epvAuthorFullName;
        private System.Windows.Forms.ErrorProvider epvAuthorContact;
        private System.Windows.Forms.ErrorProvider epvAuthorAddress;
    }
}