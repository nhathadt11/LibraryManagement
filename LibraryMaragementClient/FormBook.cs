using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
namespace LibraryMaragementClient
{
    public partial class FormBook : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormBook _instance;
        private DataTable _data;
        private BookServiceReference.IBookService _bookService;
        private FormBook()
        {
            InitializeComponent();
            _bookService = new BookServiceReference.BookServiceClient();
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
            List<Book> list = _bookService.GetBooks();

            //_data = _bookService.GetAll();
            _data = new DataTable();
            _data.Columns.Add("BookId");
            _data.Columns.Add("Isbn");
            _data.Columns.Add("Title");
            _data.Columns.Add("Description");
            _data.Columns.Add("CoverImageUrl");
            _data.Columns.Add("PageNumber");
            _data.Columns.Add("PublishedDate");
            _data.Columns.Add("AuthorId");
            _data.Columns.Add("CategoryId");
            _data.Columns.Add("PublisherId");
            _data.Columns.Add("Discontinued");

            foreach (var item in list)
            {
                _data.Rows.Add(
                    item.BookId,
                    item.Isbn,
                    item.Title,
                    item.Description,
                    item.CoverImageUrl,
                    item.PageNumber,
                    item.PublishedDate,
                    item.AuthorId,
                    item.CategoryId,
                    item.PublisherId,
                    item.Discontinued
                    );
            }
            _data.PrimaryKey = new DataColumn[] { _data.Columns["BookId"] };
            dgvBooks.DataSource = _data;
        }
     
        public void DeleteFromDataTable()
        {
            DataRow row = GetCurrentSelectedDataRow();
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
            int key = Convert.ToInt32(dgvBooks.CurrentRow.Cells["BookId"].Value);
            return _data.Rows.Find(key);
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
