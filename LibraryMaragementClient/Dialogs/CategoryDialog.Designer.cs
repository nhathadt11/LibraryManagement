namespace LibraryMaragementClient.Dialogs
{
    partial class CategoryDialog
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
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCategoryOK = new System.Windows.Forms.Button();
            this.btnCategoryCancel = new System.Windows.Forms.Button();
            this.epvCategoryName = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epvCategoryName)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(87, 29);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.ReadOnly = true;
            this.txtCategoryId.Size = new System.Drawing.Size(145, 20);
            this.txtCategoryId.TabIndex = 1;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(87, 64);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(243, 20);
            this.txtCategoryName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // btnCategoryOK
            // 
            this.btnCategoryOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCategoryOK.Location = new System.Drawing.Point(87, 108);
            this.btnCategoryOK.Name = "btnCategoryOK";
            this.btnCategoryOK.Size = new System.Drawing.Size(75, 23);
            this.btnCategoryOK.TabIndex = 4;
            this.btnCategoryOK.Text = "OK";
            this.btnCategoryOK.UseVisualStyleBackColor = true;
            this.btnCategoryOK.Click += new System.EventHandler(this.btnCategoryOK_Click);
            // 
            // btnCategoryCancel
            // 
            this.btnCategoryCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCategoryCancel.Location = new System.Drawing.Point(197, 108);
            this.btnCategoryCancel.Name = "btnCategoryCancel";
            this.btnCategoryCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCategoryCancel.TabIndex = 5;
            this.btnCategoryCancel.Text = "Cancel";
            this.btnCategoryCancel.UseVisualStyleBackColor = true;
            // 
            // epvCategoryName
            // 
            this.epvCategoryName.ContainerControl = this;
            // 
            // CategoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 158);
            this.Controls.Add(this.btnCategoryCancel);
            this.Controls.Add(this.btnCategoryOK);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryDialog";
            this.Text = "Category Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.epvCategoryName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCategoryOK;
        private System.Windows.Forms.Button btnCategoryCancel;
        private System.Windows.Forms.ErrorProvider epvCategoryName;
    }
}