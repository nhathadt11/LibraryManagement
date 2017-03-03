namespace LibraryMaragementClient.Dialogs
{
    partial class PublisherDialog
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
            this.txtPublisherId = new System.Windows.Forms.TextBox();
            this.txtPublisherName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublisherContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPublisherAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtPublisherDescription = new System.Windows.Forms.RichTextBox();
            this.btnPublisherOK = new System.Windows.Forms.Button();
            this.btnPublisherCancel = new System.Windows.Forms.Button();
            this.epvPublisherName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvPublisherContact = new System.Windows.Forms.ErrorProvider(this.components);
            this.epvPublisherAddress = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epvPublisherName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvPublisherContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvPublisherAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtPublisherId
            // 
            this.txtPublisherId.Location = new System.Drawing.Point(89, 22);
            this.txtPublisherId.Name = "txtPublisherId";
            this.txtPublisherId.ReadOnly = true;
            this.txtPublisherId.Size = new System.Drawing.Size(135, 20);
            this.txtPublisherId.TabIndex = 1;
            // 
            // txtPublisherName
            // 
            this.txtPublisherName.Location = new System.Drawing.Point(89, 48);
            this.txtPublisherName.Name = "txtPublisherName";
            this.txtPublisherName.Size = new System.Drawing.Size(228, 20);
            this.txtPublisherName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtPublisherContact
            // 
            this.txtPublisherContact.Location = new System.Drawing.Point(89, 74);
            this.txtPublisherContact.Name = "txtPublisherContact";
            this.txtPublisherContact.Size = new System.Drawing.Size(228, 20);
            this.txtPublisherContact.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contact";
            // 
            // txtPublisherAddress
            // 
            this.txtPublisherAddress.Location = new System.Drawing.Point(89, 100);
            this.txtPublisherAddress.Name = "txtPublisherAddress";
            this.txtPublisherAddress.Size = new System.Drawing.Size(228, 20);
            this.txtPublisherAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Description";
            // 
            // rtxtPublisherDescription
            // 
            this.rtxtPublisherDescription.Location = new System.Drawing.Point(41, 145);
            this.rtxtPublisherDescription.Name = "rtxtPublisherDescription";
            this.rtxtPublisherDescription.Size = new System.Drawing.Size(346, 165);
            this.rtxtPublisherDescription.TabIndex = 9;
            this.rtxtPublisherDescription.Text = "";
            // 
            // btnPublisherOK
            // 
            this.btnPublisherOK.Location = new System.Drawing.Point(121, 329);
            this.btnPublisherOK.Name = "btnPublisherOK";
            this.btnPublisherOK.Size = new System.Drawing.Size(75, 23);
            this.btnPublisherOK.TabIndex = 10;
            this.btnPublisherOK.Text = "OK";
            this.btnPublisherOK.UseVisualStyleBackColor = true;
            this.btnPublisherOK.Click += new System.EventHandler(this.btnPublisherOK_Click);
            // 
            // btnPublisherCancel
            // 
            this.btnPublisherCancel.Location = new System.Drawing.Point(224, 329);
            this.btnPublisherCancel.Name = "btnPublisherCancel";
            this.btnPublisherCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPublisherCancel.TabIndex = 11;
            this.btnPublisherCancel.Text = "Cancel";
            this.btnPublisherCancel.UseVisualStyleBackColor = true;
            // 
            // epvPublisherName
            // 
            this.epvPublisherName.ContainerControl = this;
            // 
            // epvPublisherContact
            // 
            this.epvPublisherContact.ContainerControl = this;
            // 
            // epvPublisherAddress
            // 
            this.epvPublisherAddress.ContainerControl = this;
            // 
            // PublisherDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 375);
            this.Controls.Add(this.btnPublisherCancel);
            this.Controls.Add(this.btnPublisherOK);
            this.Controls.Add(this.rtxtPublisherDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPublisherAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPublisherContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPublisherName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPublisherId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublisherDialog";
            this.Text = "PublisherDialog";
            ((System.ComponentModel.ISupportInitialize)(this.epvPublisherName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvPublisherContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvPublisherAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPublisherId;
        private System.Windows.Forms.TextBox txtPublisherName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublisherContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPublisherAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxtPublisherDescription;
        private System.Windows.Forms.Button btnPublisherOK;
        private System.Windows.Forms.Button btnPublisherCancel;
        private System.Windows.Forms.ErrorProvider epvPublisherName;
        private System.Windows.Forms.ErrorProvider epvPublisherContact;
        private System.Windows.Forms.ErrorProvider epvPublisherAddress;
    }
}