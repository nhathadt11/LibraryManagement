using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMaragementClient
{
    public partial class FormUser : Form
    {
        private static FormUser _instance;
        private FormUser()
        {
            InitializeComponent();
        }
        public static FormUser Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormUser();
                }
                return _instance;
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            dgvUsers.DataSource = userService.GetAll();
        }
    }
}
