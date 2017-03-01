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
            if (activeForm is FormBook)
            {
                // form book
                FormBook frmBook = activeForm as FormBook;
                AddUpdateOrDeleteBook(frmBook, action);
            }
            else if (activeForm is FormAuthor)
            {
                // form author
            }
            else if (activeForm is FormCategory)
            {
                // form category
            }
            else if (activeForm is FormCopy)
            {
                // form copy
            }
            else if (activeForm is FormLoan)
            {
                // form loan
            }
            else if (activeForm is FormPublisher)
            {
                // form publisher
            }
            else if (activeForm is FormUser)
            {
                // form user
            }
        }
        private void AddUpdateOrDeleteBook(FormBook frmBook, ActionType action)
        {
            BookDialog dlgBook;
            switch (action)
            {
                case ActionType.Add:
                    dlgBook = new BookDialog();
                    if (dlgBook.ShowDialog() == DialogResult.OK)
                    {
                        frmBook.AddToDataTable(dlgBook.Book);
                    }
                    break;
                case ActionType.Edit:
                    dlgBook = new BookDialog(frmBook.CurrentSelectedDataRow);
                    if (dlgBook.ShowDialog() == DialogResult.OK)
                    {
                        frmBook.UpdateToDataTable(dlgBook.Book);
                    }
                    break;
                case ActionType.Delete:
                    if (new ConfirmDialog().ShowDialog() == DialogResult.OK)
                    {
                        frmBook.DeleteFromDataTable();
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
