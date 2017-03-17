using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class CopyDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private BookCopyService _copyService;
        private BookService _bookService;
        private Copy _copy;
        private ActionType _action;
        public CopyDialog()
        {
            InitializeComponent();
            _copyService = new BookCopyService();
            _action = ActionType.Add;
        }
        public CopyDialog(DataRow row ) : this()
        {
            txtCopyId.Text = Convert.ToString(row["CopyId"]);
            rbtCopyAvailableYes.Checked = Convert.ToBoolean(row["IsAvailable"]);
            _action = ActionType.Edit;
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _copy;
        }

        private void CopyDialog_Load(object sender, EventArgs e)
        {
            cbxBookTitle.DataSource = _bookService.GetAll();
            cbxBookTitle.ValueMember = "BookId";
            cbxBookTitle.DisplayMember = "Title";
        }

        private void btnCopyOK_Click(object sender, EventArgs e)
        {
            if (!IsVaild())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _copy = new Copy
                {
                    BookId = Convert.ToInt32(cbxBookTitle.SelectedValue),
                    IsAvailable = rbtCopyAvailableYes.Checked
                };
                if (_action == ActionType.Add) // insert
                {
                    _copy.CopyId = _copyService.Add(_copy);
                    if (_copy.CopyId > 0) // success
                    {
                        MessageBox.Show("Successfully added copy with ID: " + _copy.CopyId + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not add copy with ID: " + _copy.CopyId + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update
                {
                    _copy.CopyId = Convert.ToInt32(txtCopyId.Text);
                    if (_copyService.Update(_copy) > 0) // success
                    {
                        MessageBox.Show("Successfully updated copy with ID: " + _copy.CopyId + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not update copy with ID: " + _copy.CopyId + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }
        private bool IsVaild()
        {
            return true;
        }
    }
}
