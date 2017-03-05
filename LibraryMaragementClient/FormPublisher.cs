using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Windows.Forms;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormPublisher : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormPublisher _instance;
        private PublisherService _publisherService;
        private DataTable _data;
        private FormPublisher()
        {
            InitializeComponent();
            _publisherService = new PublisherService();
        }
        public static FormPublisher Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormPublisher();
                }
                return _instance;
            }
        }

        private void FormPublisher_Load(object sender, EventArgs e)
        {
            _data = _publisherService.GetAll();
            _data.PrimaryKey = new DataColumn[] { _data.Columns["PublisherId"] };
            dgvPublishers.DataSource = _data;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            return _data.Rows[dgvPublishers.CurrentRow.Index];
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Publisher publisher = obj as Publisher;
            _data.RejectChanges();
            _data.Rows.Add(publisher.PublisherId,
                           publisher.Name,
                           publisher.Contact,
                           publisher.Address,
                           publisher.Description);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Publisher publisher = obj as Publisher;
            DataRow row = _data.Rows.Find(publisher.PublisherId);
            row["Name"] = publisher.Name;
            row["Contact"] = publisher.Contact;
            row["Address"] = publisher.Address;
            row["Description"] = publisher.Description;
            dgvPublishers.Refresh();
        }

        public void DeleteFromDataTable()
        {
            DataRow row = _data.Rows[dgvPublishers.CurrentRow.Index];
            if (_publisherService.Delete(Convert.ToInt32(row["PublisherId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["Name"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["Name"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
