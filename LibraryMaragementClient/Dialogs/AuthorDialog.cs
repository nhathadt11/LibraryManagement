using BussinessLogic.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class AuthorDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private AuthorService _authorService;
        private ActionType _action;
        private Author _author;
        public AuthorDialog()
        {
            InitializeComponent();
            _authorService = new AuthorService();
            _action = ActionType.Add;
        }
        public AuthorDialog(DataRow row) : this()
        {
            txtAuthorId.Text = Convert.ToString(row["AuthorId"]);
            txtAuthorFullName.Text = Convert.ToString(row["FullName"]);
            txtAuthorContact.Text = Convert.ToString(row["Contact"]);
            txtAuthorAddress.Text = Convert.ToString(row["Address"]);
            rtxtAuthorBio.Text = Convert.ToString(row["Bio"]);
            _action = ActionType.Edit;
        }

        private void btnAuthorOK_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _author = new Author()
                {
                    FullName = txtAuthorFullName.Text,
                    Contact = txtAuthorContact.Text,
                    Address = txtAuthorAddress.Text,
                    Bio = rtxtAuthorBio.Text
                };
                if (_action == ActionType.Add) // insert author
                {
                    _author.AuthorId = _authorService.Add(_author);
                    if (_author.AuthorId > 0) // success
                    {
                        MessageBox.Show("Successfully added " + _author.FullName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not add " + _author.FullName + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update author
                {
                    int result;
                    if ((result = _authorService.Update(_author)) > 0) // success
                    {
                        MessageBox.Show("Successfully updated " + _author.FullName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not update " + _author.FullName + "! Error code: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }

        private bool IsValid()
        {
            bool valid = true;
            if (txtAuthorFullName.Text.Equals(string.Empty))
            {
                epvAuthorFullName.SetError(txtAuthorFullName, "Required");
                valid = false;
            }
            if (txtAuthorContact.Text.Equals(string.Empty))
            {
                epvAuthorContact.SetError(txtAuthorContact, "Required");
                valid = false;
            }
            if (txtAuthorAddress.Text.Equals(string.Empty))
            {
                epvAuthorAddress.SetError(txtAuthorAddress, "Required");
                valid = false;
            }
            return valid;
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _author;
        }
    }
}
