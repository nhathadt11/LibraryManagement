using System;
using Service;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormLoan : Form
    {
        private LoanService _service;
        private static FormLoan _instance;
        private FormLoan()
        {
            InitializeComponent();
            _service = new LoanService();
        }
        public static FormLoan Instance
        {
            get{
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormLoan();
                }
                return _instance;
            }
        }

        private void FormLoan_Load(object sender, EventArgs e)
        {
            dgvLoans.DataSource = _service.GetAll();
        }
    }
}
