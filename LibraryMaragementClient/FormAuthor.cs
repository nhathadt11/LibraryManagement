using System;
using System.Windows.Forms;
using Service;
namespace LibraryMaragementClient
{
    public partial class FormAuthor : Form
    {
        private AuthorService _service;
        private static FormAuthor _instance;
        private FormAuthor()
        {
            InitializeComponent();
            _service = new AuthorService();
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
            dgvAuthors.DataSource = _service.GetAll();
        }
    }
}
