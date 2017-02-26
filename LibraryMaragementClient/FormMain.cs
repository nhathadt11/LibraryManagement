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
    }
}
