using System;
using Service;
using System.Windows.Forms;
using DatabaseAccess.DataTransferObjects;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormLoan : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormLoan _instance;
        private LoanService _loanService;
        private DataTable _data;
        private FormLoan()
        {
            InitializeComponent();
            _loanService = new LoanService();
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
            _data = _loanService.GetAll();
            _data.PrimaryKey = new DataColumn[] { _data.Columns["LoanId"] };
            dgvLoans.DataSource = _data;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            return _data.Rows[dgvLoans.CurrentRow.Index];
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Loan loan = obj as Loan;
            _data.RejectChanges();
            _data.Rows.Add(loan.LoanId,
                           loan.IssueDate,
                           loan.LimitDay,
                           loan.MemberId,
                           loan.LibrarianId);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Loan loan = obj as Loan;
            DataRow row = _data.Rows.Find(loan.LoanId);
            row["MemberId"] = loan.MemberId;
            row["IssueDate"] = loan.IssueDate;
            row["LimitDay"] = loan.LimitDay;
            row["LibrarianId"] = loan.LibrarianId;
            dgvLoans.Refresh();
        }

        public void DeleteFromDataTable()
        {
            throw new Exception("Function not supported");
        }
    }
}
