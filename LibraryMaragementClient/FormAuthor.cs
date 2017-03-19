using System;
using System.Data;
using System.Windows.Forms;
using DatabaseAccess.DataTransferObjects;
using Service;
using System.Collections.Generic;

namespace LibraryMaragementClient
{
    public partial class FormAuthor : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormAuthor _instance;
        private AuthorServiceReference.IAuthorService _authorService;
        private DataTable _data;
        private FormAuthor()
        {
            InitializeComponent();
            _authorService = new AuthorServiceReference.AuthorServiceClient();
        }
        public static FormAuthor Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormAuthor();
                }
                return _instance;
            }
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            //_data = _authorService.GetAll();
            _data = new DataTable();
            _data.Columns.Add("AuthorId");
            _data.Columns.Add("FullName");
            _data.Columns.Add("Contact");
            _data.Columns.Add("Address");
            _data.Columns.Add("Bio");

            List<Author> athors = _authorService.GetAuthors();
            foreach (var author in athors)
            {
                _data.Rows.Add(author.AuthorId,
                               author.FullName,
                               author.Contact,
                               author.Address,
                               author.Bio);
            }

            _data.PrimaryKey = new DataColumn[] { _data.Columns["AuthorId"] };
            dgvAuthors.DataSource = _data;
        }

        public void DeleteFromDataTable()
        {
            DataRow row = GetCurrentSelectedDataRow();
            if (_authorService.Delete(Convert.ToInt32(row["AuthorId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["FullName"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["FullName"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            int key = Convert.ToInt32(dgvAuthors.CurrentRow.Cells["AuthorId"].Value);
            return _data.Rows.Find(key);
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Author author = obj as Author;
            _data.RejectChanges();
            _data.Rows.Add(author.AuthorId,
                           author.FullName,
                           author.Contact,
                           author.Address,
                           author.Bio);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Author author = obj as Author;
            DataRow row = _data.Rows.Find(author.AuthorId);
            row["FullName"] = author.FullName;
            row["Contact"] = author.Contact;
            row["Address"] = author.Address;
            row["Bio"] = author.Bio;
            dgvAuthors.Refresh();
        }

        private void txtAuthorNameFilter_TextChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = "FullName LIKE '%" + txtAuthorNameFilter.Text + "%'";
        }
    }
}
