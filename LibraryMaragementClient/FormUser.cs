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
            dgvUsers.DataSource = _service.GetAll();
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            throw new NotImplementedException();
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            throw new NotImplementedException();
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
