using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Windows.Forms;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormUser : Form, IMaintainDataTable<DataTranseferObject>
    {
        private UserService _service;
        private DataTable _data;
        private static FormUser _instance;
        private FormUser()
        {
            InitializeComponent();
            _service = new UserService();
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
            _data = _service.GetAll();
            _data.PrimaryKey = new DataColumn[] { _data.Columns["UserId"] };
            dgvUsers.DataSource = _data;
            dgvUsers.Columns[1].Visible = false;
            dgvUsers.Columns[2].Visible = false;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            int key = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);
            return _data.Rows.Find(key);
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            User u = obj as User;
            _data.RejectChanges();
            _data.Rows.Add(u.UserId,u.Username,u.Password,u.FullName,u.PhoneNumber,u.Address,u.Email,u.RoleId);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            User u = obj as User;
            DataRow row = _data.Rows.Find(u.UserId);
            row["UserId"] = u.UserId;
            row["Username"] = u.Username;
            row["Password"] = u.Password;
            row["PhoneNumber"] = u.PhoneNumber;
            row["Address"] = u.Address;
            row["Email"] = u.Email;
            row["FullName"] = u.FullName;
            row["RoleId"] = u.RoleId;
            dgvUsers.Refresh();
        }

        public void DeleteFromDataTable()
        {
            DataRow row = GetCurrentSelectedDataRow();
            if(_service.Delete(Convert.ToInt32(row["UserId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["Username"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["Username"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = (rbtUserId.Checked ? "Convert(UserId,'System.String')" : "FullName")
                                        + " LIKE '%" + txtUserFilter.Text + "%'";
        }
    }
}
