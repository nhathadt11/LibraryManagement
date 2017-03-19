using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class PublisherDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private PublisherServiceReference.IPublisherService _publisherService;
        private Publisher _publisher;
        private ActionType _action;
        public PublisherDialog()
        {
            InitializeComponent();
            _publisherService = new PublisherServiceReference.PublisherServiceClient();
            _action = ActionType.Add;
        }
        public PublisherDialog(DataRow row) : this()
        {
            txtPublisherId.Text = Convert.ToString(row["PublisherId"]);
            txtPublisherName.Text = Convert.ToString(row["Name"]);
            txtPublisherContact.Text = Convert.ToString(row["Contact"]);
            txtPublisherAddress.Text = Convert.ToString(row["Address"]);
            rtxtPublisherDescription.Text = Convert.ToString(row["Description"]);
            _action = ActionType.Edit;
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _publisher;
        }
        bool IsValid()
        {
            bool valid = true;
            if (txtPublisherName.Text.Equals(string.Empty))
            {
                epvPublisherName.SetError(txtPublisherName, "Required");
                valid = false;
            }
            if (txtPublisherContact.Text.Equals(string.Empty))
            {
                epvPublisherContact.SetError(txtPublisherContact, "Required");
                valid = false;
            }
            if (txtPublisherAddress.Text.Equals(string.Empty))
            {
                epvPublisherAddress.SetError(txtPublisherAddress, "Required");
                valid = false;
            }
            return valid;
        }

        private void btnPublisherOK_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _publisher = new Publisher
                {
                    Name = txtPublisherName.Text,
                    Contact = txtPublisherContact.Text,
                    Address = txtPublisherAddress.Text,
                    Description = rtxtPublisherDescription.Text
                };
                if (_action == ActionType.Add) // insert
                {
                    _publisher.PublisherId = _publisherService.Add(_publisher);
                    if (_publisher.PublisherId > 0)
                    {
                        MessageBox.Show("Successfully added " + _publisher.Name + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Could not add " + _publisher.Name + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update
                {
                    _publisher.PublisherId = Convert.ToInt32(txtPublisherId.Text);
                    if (_publisherService.Update(_publisher) > 0)
                    {
                        MessageBox.Show("Successfully updated " + _publisher.Name + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Could not update " + _publisher.Name + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }
    }
}
