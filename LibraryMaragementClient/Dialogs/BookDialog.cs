using BussinessLogic.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class BookDialog : Form
    {
        private BookService _bookService;
        private AuthorService _authorService;
        private PublisherService _publisherService;
        private CategoryService _categoryService;
        public BookDialog()
        {
            InitializeComponent();
            _bookService = new BookService();
            _authorService = new AuthorService();
            _publisherService = new PublisherService();
            _categoryService = new CategoryService();
        }
        public BookDialog(DataRow row, ActionType type) : this()
        {
            txtBookId.Text = Convert.ToString(row.ItemArray[0]);
            txtBookIsbn.Text = Convert.ToString(row.ItemArray[1]);
            txtBookTitle.Text = Convert.ToString(row.ItemArray[2]);
            rtxtBookDescription.Text = Convert.ToString(row.ItemArray[3]);
            txtBookImageUrl.Text = Convert.ToString(row.ItemArray[4]);
            txtBookPageNumber.Text = Convert.ToString(row.ItemArray[5]);
            dtpBookPublishedDate.Value = Convert.ToDateTime(row.ItemArray[6]);
            cbxBookAuthor.SelectedValue = Convert.ToInt32(row.ItemArray[7]);
            cbxBookCategory.SelectedValue = Convert.ToInt32(row.ItemArray[8]);
            cbxBookPublisher.SelectedValue = Convert.ToInt32(row.ItemArray[9]);
            rbtBookDiscontinuedYes.Checked = Convert.ToBoolean(row.ItemArray[10]);
        }

        private void btnBookOK_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                Book book = new Book
                {
                    Title = txtBookTitle.Text,
                    Isbn = txtBookIsbn.Text,
                    CategoryId = Convert.ToInt32(cbxBookCategory.SelectedValue),
                    AuthorId = Convert.ToInt32(cbxBookAuthor.SelectedValue),
                    PublisherId = Convert.ToInt32(cbxBookPublisher.SelectedValue),
                    Discontinued = rbtBookDiscontinuedYes.Checked,
                    PublishedDate = dtpBookPublishedDate.Value,
                    CoverImageUrl = txtBookImageUrl.Text,
                    PageNumber = Convert.ToInt32(txtBookPageNumber.Text),
                    Description = rtxtBookDescription.Text
                };
                book.BookId = _bookService.Add(book);
                if (book.BookId > 0)
                {
                    MessageBox.Show("Successfully added " + book.Title + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Could not added " + book.Title + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }
        }

        private bool IsValid()
        {
            bool result = true;
            if (txtBookTitle.Text.Equals(string.Empty))
            {
                epvBookTitle.SetError(txtBookTitle, "Cannot be empty");
                result = false;
            }
            if (txtBookIsbn.Text.Equals(string.Empty))
            {
                epvBookIsbn.SetError(txtBookIsbn, "Cannot be empty");
                result = false;
            }
            else if (!Regex.IsMatch(txtBookIsbn.Text, @"\d{13}"))
            {
                epvBookIsbn.SetError(txtBookIsbn, "Must contain 13 digits");
                result = false;
            }
            if (!Regex.IsMatch(txtBookPageNumber.Text, @"\d+"))
            {
                epvBookPageNumber.SetError(txtBookPageNumber, "Cannot be empty and must be a number");
                result = false;
            }
            if (dtpBookPublishedDate.Value.CompareTo(DateTime.Today) > 0)
            {
                epvBookPublishedDate.SetError(dtpBookPublishedDate, "Cannot be later than today");
                result = false;
            }
            return result;
        }

        private void BookDialog_Load(object sender, EventArgs e)
        {
            cbxBookAuthor.DataSource = _authorService.GetAll().DefaultView;
            cbxBookAuthor.ValueMember = "AuthorId";
            cbxBookAuthor.DisplayMember = "FullName";

            cbxBookCategory.DataSource = _categoryService.GetAll();
            cbxBookCategory.ValueMember = "CategoryId";
            cbxBookCategory.DisplayMember = "Name";

            cbxBookPublisher.DataSource = _publisherService.GetAll();
            cbxBookPublisher.ValueMember = "PublisherId";
            cbxBookPublisher.DisplayMember = "Name";
        }
    }
}
