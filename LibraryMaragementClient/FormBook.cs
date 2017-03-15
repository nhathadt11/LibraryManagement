using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormBook : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormBook _instance;
        private DataTable _data;
        private BookService _bookService;
        private FormBook()
        {
            InitializeComponent();
            _bookService = new BookService();
        }
        public static FormBook Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormBook();
                }
                return _instance;
            }
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            _data = _bookService.GetAll();
            _data.PrimaryKey = new DataColumn[] { _data.Columns["BookId"] };
            dgvBooks.DataSource = _data;
        }
     
        public void DeleteFromDataTable()
        {
            DataRow row = _data.Rows[dgvBooks.CurrentRow.Index];
            if (_bookService.Delete(Convert.ToInt32(row["BookId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["Title"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["Title"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            return _data.Rows[dgvBooks.CurrentRow.Index];
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Book book = obj as Book;
            _data.RejectChanges();
            _data.Rows.Add(book.BookId, book.Isbn, book.Title,
                           book.Description, book.CoverImageUrl,
                           book.PageNumber, book.PublishedDate,
                           book.AuthorId, book.CategoryId,
                           book.PublisherId, book.Discontinued);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Book book = obj as Book;
            DataRow row = _data.Rows.Find(book.BookId);
            row["Isbn"] = book.Isbn;
            row["Title"] = book.Title;
            row["Description"] = book.Description;
            row["CoverImageUrl"] = book.CoverImageUrl;
            row["PageNumber"] = book.PageNumber;
            row["PublishedDate"] = book.PublishedDate;
            row["AuthorId"] = book.AuthorId;
            row["CategoryId"] = book.CategoryId;
            row["PublisherId"] = book.PublisherId;
            row["Discontinued"] = book.Discontinued;
            dgvBooks.Refresh();
        }

        private void txtBookFilter_TextChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = (rbtBookTitle.Checked
                                          ? "Title "
                                          : "Convert(BookId, 'System.String') ")
                                          + "LIKE '%" + txtBookFilter.Text + "%'";
        }
    }
}
