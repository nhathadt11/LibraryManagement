using DatabaseAccess.DataTransferObjects;
using LibraryMaragementClient.Dialogs;
using System;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Text = "Library Management System - Welcome, " 
                      + FormLogin.Instance.CurrentUser.FullName;
        }

        private void tsbtBook_Click(object sender, EventArgs e)
        {
            FormBook frmBook = FormBook.Instance;
            frmBook.MdiParent = this;
            frmBook.Show();
            frmBook.Activate();
        }

        private void tsbtAuthor_Click(object sender, EventArgs e)
        {
            FormAuthor frmAuthor = FormAuthor.Instance;
            frmAuthor.MdiParent = this;
            frmAuthor.Show();
            frmAuthor.Activate();
        }

        private void tsbtCategory_Click(object sender, EventArgs e)
        {
            FormCategory frmCategory = FormCategory.Instance;
            frmCategory.MdiParent = this;
            frmCategory.Show();
            frmCategory.Activate();
        }

        private void tsbtCopy_Click(object sender, EventArgs e)
        {
            FormCopy frmCopy = FormCopy.Instance;
            frmCopy.MdiParent = this;
            frmCopy.Show();
            frmCopy.Activate();
        }

        private void tsbtPublisher_Click(object sender, EventArgs e)
        {
            FormPublisher frmPublisher = FormPublisher.Instance;
            frmPublisher.MdiParent = this;
            frmPublisher.Show();
            frmPublisher.Activate();
        }

        private void tsbtLoan_Click(object sender, EventArgs e)
        {
            FormLoan frmLoan = FormLoan.Instance;
            frmLoan.MdiParent = this;
            frmLoan.Show();
            frmLoan.Activate();
        }

        private void tsbtMember_Click(object sender, EventArgs e)
        {
            FormUser frmUser = FormUser.Instance;
            frmUser.MdiParent = this;
            frmUser.Show();
            frmUser.Activate();
        }

        private void tsbtNew_Click(object sender, EventArgs e)
        {
            TakeUserAction(ActionType.Add);
        }

        private void tsbtEdit_Click(object sender, EventArgs e)
        {
            TakeUserAction(ActionType.Edit);
        }

        private void tsbtDelete_Click(object sender, EventArgs e)
        {
            TakeUserAction(ActionType.Delete);
        }
        private void TakeUserAction(ActionType action)
        {
            Form activeForm = this.ActiveMdiChild;
            IMaintainDataTable<DataTranseferObject> frmMaintain;
            IDetailsDialog<DataTranseferObject> dlgDetails;
            if (activeForm is FormBook)
            {
                frmMaintain = activeForm as FormBook;
                dlgDetails = action == ActionType.Add
                           ? new BookDialog()
                           : new BookDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else if (activeForm is FormAuthor)
            {
                frmMaintain = activeForm as FormAuthor;
                dlgDetails = action == ActionType.Add
                           ? new AuthorDialog()
                           : new AuthorDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else if (activeForm is FormCategory)
            {
                frmMaintain = activeForm as FormCategory;
                dlgDetails = action == ActionType.Add
                           ? new CategoryDialog()
                           : new CategoryDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else if (activeForm is FormCopy)
            {
                frmMaintain = activeForm as FormCopy;
                dlgDetails = action == ActionType.Add
                           ? new CopyDialog()
                           : new CopyDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else if (activeForm is FormLoan)
            {
                frmMaintain = activeForm as FormLoan;
                dlgDetails = action == ActionType.Add
                           ? new LoanDialog()
                           : new LoanDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else if (activeForm is FormPublisher)
            {
                frmMaintain = activeForm as FormPublisher;
                dlgDetails = action == ActionType.Add
                           ? new PublisherDialog()
                           : new PublisherDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else if(activeForm is FormUser)
            {
                frmMaintain = activeForm as FormUser;
                dlgDetails = action == ActionType.Add
                           ? new UserDialog()
                           : new UserDialog(frmMaintain.GetCurrentSelectedDataRow());
            }
            else
            {
                MessageBox.Show("Please Choose a form!",
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            AddUpdateOrDelete(frmMaintain, dlgDetails, action);
        }
        private void AddUpdateOrDelete(IMaintainDataTable<DataTranseferObject> frmMaintain,
                                       IDetailsDialog<DataTranseferObject> dlgDetails,
                                       ActionType action)
        {
            switch (action)
            {
                case ActionType.Add:
                    if (dlgDetails.ShowDialog() == DialogResult.OK)
                    {
                        frmMaintain.AddToDataTable(dlgDetails.GetCurrentObject());
                    }
                    break;
                case ActionType.Edit:
                    if (dlgDetails.ShowDialog() == DialogResult.OK)
                    {
                        frmMaintain.UpdateToDataTable(dlgDetails.GetCurrentObject());
                    }
                    break;
                case ActionType.Delete:
                    if (frmMaintain is FormLoan)
                    {
                        MessageBox.Show("Cannot delete loan once it was added!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        break;
                    }
                    if (MessageBox.Show("Are you sure?",
                                        "Confirm Dialog",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmMaintain.DeleteFromDataTable();
                    }
                    break;
                default:
                    break;
            }
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to logout?", 
                                                  "Confirm Dialog",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                FormLogin.Instance.Show();
                this.Dispose();
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }

    enum ActionType {
        Add, Edit, Delete
    }
}
