using LibraryMaragementClient.Dialogs;
using System.Data;
using System.Windows.Forms;
using System;
using DatabaseAccess.DataTransferObjects;
using System.Collections.Generic;
using Service;
using System.Text.RegularExpressions;

namespace LibraryMaragementClient
{
    public partial class LoanDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private LoanService _loanService;
        private LoanDetailService _loanDetailService;
        private UserService _userService;
        private BookCopyService _copyService;
        private Loan _loan;
        private List<TextBox> _textBoxes;
        private DataTable _librarianData;
        private ActionType _action;
        public LoanDialog()
        {
            InitializeComponent();
            _loanService = new LoanService();
            _loanDetailService = new LoanDetailService();
            _userService = new UserService();
            _copyService = new BookCopyService();
            _textBoxes = new List<TextBox>();
            _textBoxes.AddRange(new TextBox[] { txtLoanCopyId1,
                                                txtLoanCopyId2,
                                                txtLoanCopyId3,
                                                txtLoanCopyId4,
                                                txtLoanCopyId5});
            _action = ActionType.Add;
        }
        public LoanDialog(DataRow row) : this()
        {
            txtLoanId.Text = Convert.ToString(row["LoanId"]);
            txtLoanMemberId.Text = Convert.ToString(row["MemberId"]);
            txtLoanLimitDay.Text = Convert.ToString(row["LimitDay"]);
            dtpLoanIssueDate.Value = Convert.ToDateTime(row["IssueDate"]);
            _loanDetailService.GetLoanDetailsByLoanId(Convert.ToInt32(txtLoanId.Text));
            CopyIdToTextBox();
            _textBoxes.ForEach(tb => tb.Enabled = false);
            _action = ActionType.Edit;
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
            if (!IsValid())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _loan = new Loan
                {
                    IssueDate = dtpLoanIssueDate.Value,
                    LimitDay = Convert.ToInt32(txtLoanLimitDay.Text),
                    MemberId = Convert.ToInt32(txtLoanMemberId.Text),
                    LibrarianId = Convert.ToInt32(cbxLibrarian.SelectedValue)
                };

                if (_action == ActionType.Add)// insert
                {
                    _loan.LoanId = _loanService.Add(_loan, ToLoanDetailList());
                    if (_loan.LoanId > 0) // success
                    {
                        MessageBox.Show("Successfully added loan with ID: " + _loan.LoanId + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not add loan with ID: " + _loan.LoanId + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update
                {
                    _loan.LoanId = Convert.ToInt32(txtLoanId.Text);
                    if (_loanService.Update(_loan) > 0) // success
                    {
                        MessageBox.Show("Successfully updated loan with ID: " + _loan.LoanId + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not update loan with ID: " + _loan.LoanId + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }
        private bool IsValid()
        {
            bool valid = true;
            if (txtLoanMemberId.Text.Trim() == string.Empty)
            {
                epvLoanMemberId.SetError(txtLoanMemberId, "Required!");
                valid = false;
            }
            else if (!Regex.IsMatch(txtLoanMemberId.Text, @"\d+")) {
                epvLoanMemberId.SetError(txtLoanMemberId, "Must contain only digits!");
                valid = false;
            }
            else if (!CheckValidUserId())
            {
                epvLoanMemberId.SetError(txtLoanMemberId, "Member ID not found!");
                valid = false;
            }
            else
            {
                epvLoanMemberId.Clear();
            }
            if (dtpLoanIssueDate.Value.CompareTo(DateTime.Today) > 0)
            {
                epvLoanIssueDate.SetError(dtpLoanIssueDate, "Issue date cannot be later than today!");
                valid = false;
            }
            else
            {
                epvLoanIssueDate.Clear();
            }
            List<ErrorProvider> errors = new List<ErrorProvider>();
            errors.AddRange(new ErrorProvider[] { epvLoanCopyId1,
                                                  epvLoanCopyId2,
                                                  epvLoanCopyId3,
                                                  epvLoanCopyId4,
                                                  epvLoanCopyId5});
            if (_textBoxes.FindAll(tb => tb.Text == string.Empty).Count == 5)
            {
                epvLoanCopyId1.SetError(txtLoanCopyId1, "At least one book copy is required!");
                valid = false;
            }
            else
            {
                for (int i = 0; i < _textBoxes.Count; i++)
                {
                    if (Regex.IsMatch(_textBoxes[i].Text, @"\d+") &&
                        !_copyService.CheckValidCopyId(Convert.ToInt32(_textBoxes[i].Text)))
                    {
                        errors[i].SetError(_textBoxes[i], "Copy ID not found!");
                        valid = false;
                    }
                    else
                    {
                        errors[i].Clear();
                    }
                }
            }
            return valid;
        }
        private List<LoanDetail> ToLoanDetailList()
        {
            List<LoanDetail> loanDetails = new List<LoanDetail>();
            _textBoxes.FindAll(tb => tb.Text != string.Empty)
                      .ForEach(tb => loanDetails.Add(new LoanDetail() { CopyId = int.Parse(tb.Text) }));
            return loanDetails;
        }
        private void CopyIdToTextBox()
        {
            List<LoanDetail> loanDetails = _loanDetailService.GetLoanDetailsByLoanId(Convert.ToInt32(txtLoanId.Text));
            int i;
            for (i = 0; i < loanDetails.Count; i++)
            {
                _textBoxes[i].Text = Convert.ToString(loanDetails[i].CopyId);
            }
        }
        private bool CheckValidUserId()
        {
            return _userService.CheckUserById(Convert.ToInt32(txtLoanMemberId.Text)) > 0;
        }

        private void txtLoanMemberId_TextChanged(object sender, EventArgs e)
        {
            txtLoanMemberId.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtLoanMemberId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable table = _userService.GetAll();
            foreach (DataRow row in table.Rows)
            {
                col.Add(row["UserId"].ToString());
            }
            txtLoanMemberId.AutoCompleteCustomSource = col;
        }
        private void suggest(TextBox t)
        {
            t.AutoCompleteMode = AutoCompleteMode.Suggest;
            t.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable table = _copyService.GetAll();
            foreach (DataRow row in table.Rows)
            {
                col.Add(row["CopyId"].ToString());
            }
            t.AutoCompleteCustomSource = col;
        }
        private void txtLoanCopyId5_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            suggest(t);
        }
    }
}
