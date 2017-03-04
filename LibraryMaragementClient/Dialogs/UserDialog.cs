using BussinessLogic.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class UserDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private RoleService _roleService;
        private UserService _userService;
        private ActionType _actionType;
        private User _user;
        public UserDialog()
        {
            InitializeComponent();
            _roleService = new RoleService();
            _userService = new UserService();
            _actionType = ActionType.Add;
        }
        public UserDialog(DataRow row) : this()
        {
            txtUsername.Text = Convert.ToString(row["Username"]);
            txtPassword.Text = Convert.ToString(row["Password"]);
            txtPhoneNumber.Text = Convert.ToString(row["PhoneNumber"]);
            txtAddress.Text = Convert.ToString(row["Address"]);
            txtEmail.Text = Convert.ToString(row["Email"]);
            cbRole.SelectedValue = Convert.ToInt32(row["RoleId"]);
            _actionType = ActionType.Edit;
        }

        public DataTranseferObject GetCurrentObject()
        {
            throw new NotImplementedException();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                this.DialogResult = DialogResult.None;

            }else {
                _user = new User()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    RoleId =Convert.ToInt32(cbRole.SelectedValue)
                };
                if (_actionType == ActionType.Add)
                {

                }
                else
                {

                }
            }
            
        }
        private bool IsValid()
        {
            bool result = true;
            //check Username
            if (txtUsername.Text.Equals(string.Empty))
            {
                epvUsername.SetError(txtUsername, "Required!!");
                result = false;
            } else if (!Regex.IsMatch(txtUsername.Text, @"\w{10,50}"){
                epvUsername.SetError(txtUsername, "User name must from 10 to 50 character!!");
                result = false;
            }
            else if (_userService.IsExisted(txtUsername.Text) == 1) {
                epvUsername.SetError(txtUsername, "User name existed!!");
                result = false;
            }
            //check Password
            if (txtPassword.Text.Equals(string.Empty))
            {
                epvPassword.SetError(txtPassword, "Required!!");
                result = false;
            } else if (!Regex.IsMatch(txtPassword.Text, @"\w{10,50}"))
            {
                epvPassword.SetError(txtPassword, "Password must from 10 to 50 character!!");
                result = false;
            }
            //check phone number
            if (txtPhoneNumber.Equals(string.Empty))
            {
                epvPhoneNumber.SetError(txtPhoneNumber, "Required!!");
                result = false;
            } else if (!Regex.IsMatch(txtPhoneNumber.Text, @"\d{10,11}")){
                epvPhoneNumber.SetError(txtPhoneNumber, "Phone Number must from 10 to 11 digit!!");
                result = false;
            }
            //check address
            if (txtAddress.Text.Equals(string.Empty)){
                epvAddress.SetError(txtAddress, "Required!!");
                result = false;
            }
            //check email
            if (txtEmail.Text.Equals(string.Empty))
            {
                epvEmail.SetError(txtEmail, "Requred!!");
                result = false;
            }else if(!Regex.IsMatch(txtEmail.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                epvEmail.SetError(txtEmail, "Email invalid");
                result = false;
            }
            return result;
        }

        private void UserDialog_Load(object sender, EventArgs e)
        {
            cbRole.DataSource = _roleService.GetAll();
            cbRole.ValueMember = "RoleId";
            cbRole.DisplayMember = "RoleName";
        }
    }
}
