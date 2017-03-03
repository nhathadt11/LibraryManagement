using BussinessLogic.DataTransferObjects;
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
            _bookService = new BookService();
            _action = ActionType.Add;
        }
        public CopyDialog(DataRow row ) : this()
        {
            txtCopyCode.Text = Convert.ToString(row["CopyCode"]);
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
                    _copy.CopyCode = _copyService.Add(_copy);
                    if (_copy.CopyCode > 0) // success
                    {
                        MessageBox.Show("Successfully added " + _copy.CopyCode + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not add " + _copy.CopyCode + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update
                {
                    if (_copyService.Update(_copy) > 0) // success
                    {
                        MessageBox.Show("Successfully updated " + _copy.CopyCode + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not update " + _copy.CopyCode + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
