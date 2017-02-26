using System;
using System.Windows.Forms;
using Service;
namespace LibraryMaragementClient
{
    public partial class FormBookCopy : Form
    {
        private BookCopyService _service;
        private static FormBookCopy _instance;
        private FormBookCopy()
        {
            InitializeComponent();
            _service = new BookCopyService();
        }
        public static FormBookCopy Instance {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormBookCopy();
                }
                return _instance;
            }
        }

        private void FormBookCopy_Load(object sender, EventArgs e)
        {
            dgvBookCopys.DataSource = _service.GetAll();
        }
    }
}
