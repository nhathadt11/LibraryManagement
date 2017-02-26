using Service;
using System;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormPublisher : Form
    {
        private PublisherService _service;
        private static FormPublisher _instance;
        private FormPublisher()
        {
            InitializeComponent();
            _service = new PublisherService();
        }
        public static FormPublisher Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormPublisher();
                }
                return _instance;
            }
        }

        private void FormPublisher_Load(object sender, EventArgs e)
        {
            dgvPublishers.DataSource = _service.GetAll();

        }
    }
}
