using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
namespace LibraryMaragementClient
{
    public partial class FormAuthor : Form
    {
        private static FormAuthor _instance;
        public static FormAuthor Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormAuthor();
                }
                return _instance;
            }
        }
        private FormAuthor()
        {
            InitializeComponent();
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            AuthorService authorService = new AuthorService();
            dgvAuthors.DataSource = authorService.GetAll();
        }
    }
}
