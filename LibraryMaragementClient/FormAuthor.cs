using System;
using System.Data;
using System.Windows.Forms;
using BussinessLogic.DataTransferObjects;
using Service;
namespace LibraryMaragementClient
{
    public partial class FormAuthor : Form
    {
        private static FormAuthor _instance;
        private AuthorService _authorService;
        private DataTable _data;
        private FormAuthor()
        {
            InitializeComponent();
            _authorService = new AuthorService();
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

        public DataRow CurrentSelectedDataRow
        {
            get
            {
                return _data.Rows[dgvAuthors.CurrentRow.Index];
            }
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            _data = _authorService.GetAll();
            _data.PrimaryKey = new DataColumn[] { _data.Columns["AuthorId"] };
            dgvAuthors.DataSource = _data;
        }

        internal void AddToDataTable(Author author)
        {
            _data.RejectChanges();
            _data.Rows.Add(author.AuthorId, author.FullName,
                           author.Contact, author.Address,
                           author.Bio);
            _data.AcceptChanges();
        }

        internal void UpdateToDataTable(Author author)
        {
            DataRow row = _data.Rows.Find(author.AuthorId);
            row["FullName"] = author.FullName;
            row["Contact"] = author.Contact;
            row["Address"] = author.Address;
            row["Bio"] = author.Bio;
            dgvAuthors.Refresh();
        }

        internal void DeleteFromDataTable()
        {
            DataRow row = _data.Rows[dgvAuthors.CurrentRow.Index];
            if (_authorService.Delete(Convert.ToInt32(row["AuthorId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["FullName"] + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["FullName"] + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
