using DatabaseAccess.DataTransferObjects;
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
    public partial class FormLogin : Form
    {
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        private static FormLogin _instance;
        public static FormLogin Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormLogin();
                }
                return _instance;
            }
        }
        private FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClearErrors();
            using (UserServiceReference.UserServiceClient client = new UserServiceReference.UserServiceClient())
            {
                if (IsValid())
                {
                    try
                    {
                        User user = client.CheckLogin(txtUsername.Text, txtPassword.Text);
                        if (user != null)
                        {
                            CurrentUser = user;
                            new FormMain(this, user).Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username OR Password!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Connection failed!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
;       }
        private bool IsValid()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                epvUsername.SetError(txtUsername, "Required!");
                result = false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                epvPassword.SetError(txtPassword, "Required!");
                result = false;
            }
            return result;
        }
        private void ClearErrors()
        {
            epvUsername.Clear();
            epvPassword.Clear();
        }
    }
}
