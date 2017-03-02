using Service;
using System;
using System.Data;
using System.Windows.Forms;
using BussinessLogic.DataTransferObjects;

namespace LibraryMaragementClient
{
    public partial class FormCategory : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormCategory _instance;
        private CategoryService _service;
        private DataTable _data;
        public DataRow CurrentSelectedDataRow
        {
            get
            {
                return _data.Rows[dgvCategorys.CurrentRow.Index];
            }
        }

        private FormCategory()
        {
            InitializeComponent();
            _service = new CategoryService();
        }
        public static FormCategory Instance
        {
            get
            {
                if (_instance == null ||_instance.IsDisposed)
                {
                    _instance = new FormCategory();
                }
                return _instance;
            }
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            _data = _service.GetAll();
            dgvCategorys.DataSource = _data;
        }

        public void DeleteFromDataTable()
        {
            throw new NotImplementedException();
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            return _data.Rows[dgvCategorys.CurrentRow.Index];
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
