using LibraryMaragementClient.Dialogs;
using System.Data;
using System.Windows.Forms;
using System;
using BussinessLogic.DataTransferObjects;
using System.Collections.Generic;
using Service;

namespace LibraryMaragementClient
{
    public partial class LoanDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private LoanService _loanService;
        private LoanDetailService _loanDetailService;
        private UserService _userService;
        private Loan _loan;
        private List<LoanDetail> _loanDetails;
        private DataTable _librarianData;
        private ActionType _action;
        public LoanDialog()
        {
            InitializeComponent();
            _loanService = new LoanService();
            _loanDetailService = new LoanDetailService();
            _userService = new UserService();
            _action = ActionType.Add;
        }
        public LoanDialog(DataRow row) : this()
        {
            txtLoanId.Text = Convert.ToString(row["LoanId"]);
            txtLoanMemberId.Text = Convert.ToString(row["MemberId"]);
            txtLoanLimitDay.Text = Convert.ToString(row["LimitDay"]);
            dtpLoanIssueDate.Value = Convert.ToDateTime(row["IssueDate"]);
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _loan;
        }

        private void LoanDialog_Load(object sender, EventArgs e)
        {
            _librarianData = _userService.GetAllLibrarians();
            cbxLibrarian.DataSource = _librarianData;
            cbxLibrarian.DisplayMember = "FullName";
            cbxLibrarian.ValueMember = "UserId";
        }

        private void btnLoanOk_Click(object sender, EventArgs e)
        {

        }
    }
}
