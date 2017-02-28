using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormBook : Form
    {
        private static FormBook _instance;
        private DataTable _data;
        private BookService _bookService;
        public DataRow CurrentSelectedDataRow
        {
            get
            {
                return _data.Rows[dgvBooks.CurrentRow.Index];
            }
        }
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
            dgvBooks.DataSource = _data;
        }
    }
}
