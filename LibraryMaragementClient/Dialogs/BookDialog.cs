using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class BookDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private BookServiceReference.IBookService _bookService;
        private AuthorServiceReference.IAuthorService _authorService;
        private PublisherServiceReference.IPublisherService _publisherService;
        private CategoryServiceReference.ICategoryService _categoryService;
        private Book _book;
        private ActionType _action;
        public BookDialog()
        {
            InitializeComponent();
            _bookService = new BookServiceReference.BookServiceClient();
            _authorService = new AuthorServiceReference.AuthorServiceClient();
            _publisherService = new PublisherServiceReference.PublisherServiceClient();
            _categoryService = new CategoryServiceReference.CategoryServiceClient();
            _action = ActionType.Add;

            cbxBookAuthor.DataSource = _authorService.GetAuthors();
            cbxBookAuthor.ValueMember = "AuthorId";
            cbxBookAuthor.DisplayMember = "FullName";

            cbxBookCategory.DataSource = _categoryService.GetCategories();
            cbxBookCategory.ValueMember = "CategoryId";
            cbxBookCategory.DisplayMember = "Name";

            cbxBookPublisher.DataSource = _publisherService.GetPublishers();
            cbxBookPublisher.ValueMember = "PublisherId";
            cbxBookPublisher.DisplayMember = "Name";
        }
        public BookDialog(DataRow row) : this()
        {   
            txtBookId.Text = Convert.ToString(row["BookId"]);
            txtBookIsbn.Text = Convert.ToString(row["Isbn"]);
            txtBookTitle.Text = Convert.ToString(row["Title"]);
            rtxtBookDescription.Text = Convert.ToString(row["Description"]);
            txtBookImageUrl.Text = Convert.ToString(row["CoverImageUrl"]);
            txtBookPageNumber.Text = Convert.ToString(row["PageNumber"]);
            dtpBookPublishedDate.Value = Convert.ToDateTime(row["PublishedDate"]);
            cbxBookAuthor.SelectedValue = Convert.ToInt32(row["AuthorId"]);
            cbxBookCategory.SelectedValue = Convert.ToInt32(row["CategoryId"]);
            cbxBookPublisher.SelectedValue = Convert.ToInt32(row["PublisherId"]);
            rbtBookDiscontinuedYes.Checked = Convert.ToBoolean(row["Discontinued"]);
            _action = ActionType.Edit;
        }

        private void btnBookOK_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _book = new Book
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

                if (_action == ActionType.Add)// insert book
                {
                    _book.BookId = _bookService.Add(_book);
                    if (_book.BookId > 0) // success
                    {
                        MessageBox.Show("Successfully added " + _book.Title + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not add " + _book.Title + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update book
                {
                    _book.BookId = Convert.ToInt32(txtBookId.Text);
                    if (_bookService.Update(_book) > 0) // success
                    {
                        MessageBox.Show("Successfully updated " + _book.Title + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not update " + _book.Title + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }

        private bool IsValid()
        {
            bool result = true;
            if (txtBookTitle.Text.Equals(string.Empty))
            {
                epvBookTitle.SetError(txtBookTitle, "Required");
                result = false;
            }
            if (txtBookIsbn.Text.Equals(string.Empty))
            {
                epvBookIsbn.SetError(txtBookIsbn, "Required");
                result = false;
            }
            else if (!Regex.IsMatch(txtBookIsbn.Text, @"\d{13}"))
            {
                epvBookIsbn.SetError(txtBookIsbn, "Must contain 13 digits");
                result = false;
            }
            if (!Regex.IsMatch(txtBookPageNumber.Text, @"\d+"))
            {
                epvBookPageNumber.SetError(txtBookPageNumber, "Required and must be a number");
                result = false;
            }
            if (dtpBookPublishedDate.Value.CompareTo(DateTime.Today) >= 0)
            {
                epvBookPublishedDate.SetError(dtpBookPublishedDate, "Cannot be later than today");
                result = false;
            }
            return result;
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _book;
        }

        private void btnBookCoverImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"d:\";
            fdlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtBookImageUrl.Text = fdlg.FileName;
            }
        }
    }
}
