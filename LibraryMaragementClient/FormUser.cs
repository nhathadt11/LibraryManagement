using BussinessLogic.DataTransferObjects;
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
            dgvUsers.Columns[0].Visible = false;
            dgvUsers.Columns[2].Visible = false;
            dgvUsers.Columns[0].Visible = false;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            return _data.Rows[dgvUsers.CurrentRow.Index];
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            User u = obj as User;
            _data.RejectChanges();
            _data.Rows.Add(u.);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromDataTable()
        {
            throw new NotImplementedException();
        }
    }
}
