using System;
using Service;
using System.Windows.Forms;
using BussinessLogic.DataTransferObjects;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormLoan : Form, IMaintainDataTable<DataTranseferObject>
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

        public DataRow GetCurrentSelectedDataRow()
        {
            throw new NotImplementedException();
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromDataTable()
        {
            throw new NotImplementedException();
        }
    }
}
