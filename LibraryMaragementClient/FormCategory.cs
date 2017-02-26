using Service;
using System;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormCategory : Form
    {
        private CategoryService _service;
        private static FormCategory _instance;

        private FormCategory()
        {
            InitializeComponent();
            _service = new CategoryService();
        }
        public static FormCategory Instance
        {
            get
            {
                if (_instance == null | _instance.IsDisposed)
                {
                    _instance = new FormCategory();
                }
                return _instance;
            }
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            dgvCategorys.DataSource = _service.GetAll();
        }
    }
}
