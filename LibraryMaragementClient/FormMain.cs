using BussinessLogic.DataTransferObjects;
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
            if (activeForm is FormBook)
            {
                frmMaintain = activeForm as FormBook;
            }
            else if (activeForm is FormAuthor)
            {
                frmMaintain = activeForm as FormAuthor;
            }
            else if (activeForm is FormCategory)
            {
                frmMaintain = activeForm as FormCategory;
            }
            else if (activeForm is FormCopy)
            {
                frmMaintain = activeForm as FormCopy;
            }
            else if (activeForm is FormLoan)
            {
                frmMaintain = activeForm as FormLoan;
            }
            else if (activeForm is FormPublisher)
            {
                frmMaintain = activeForm as FormPublisher;
            }
            else
            {
                frmMaintain = activeForm as FormUser;
            }
            AddUpdateOrDelete(frmMaintain, action);
        }
        private void AddUpdateOrDelete(IMaintainDataTable<DataTranseferObject> form, ActionType action)
        {
            IDetailsDialog<DataTranseferObject> detailDialog;
            switch (action)
            {
                case ActionType.Add:
                    detailDialog = new BookDialog();
                    if (detailDialog.ShowDialog() == DialogResult.OK)
                    {
                        form.AddToDataTable(detailDialog.GetCurrentObject());
                    }
                    break;
                case ActionType.Edit:
                    detailDialog = new BookDialog(form.GetCurrentSelectedDataRow());
                    if (detailDialog.ShowDialog() == DialogResult.OK)
                    {
                        form.UpdateToDataTable(detailDialog.GetCurrentObject() as Book);
                    }
                    break;
                case ActionType.Delete:
                    if (MessageBox.Show("Are you sure?", "Confirm Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        form.DeleteFromDataTable();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public enum ActionType {
        Add, Edit, Delete
    }
}
