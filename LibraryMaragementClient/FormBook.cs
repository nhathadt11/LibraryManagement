using Service;
using System;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormBook : Form
    {
        private static FormBook _instance;
        private FormBook()
        {
            InitializeComponent();
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
            BookService bookService = new BookService();
            dgvBooks.DataSource = bookService.GetAll();
        }
    }
}
