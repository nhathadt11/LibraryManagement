using Service;
using System;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormUser : Form
    {
        private UserService _service;
        private static FormUser _instance;
        private FormUser()
        {
            InitializeComponent();
            _service = new UserService();
        }
        public static FormUser Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormUser();
                }
                return _instance;
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _service.GetAll();
        }
    }
}
