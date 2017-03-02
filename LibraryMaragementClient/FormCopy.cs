using System;
using System.Windows.Forms;
using Service;
using BussinessLogic.DataTransferObjects;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormCopy : Form, IMaintainDataTable<DataTranseferObject>
    {
        private BookCopyService _service;
        private static FormCopy _instance;
        private FormCopy()
        {
            InitializeComponent();
            _service = new BookCopyService();
        }
        public static FormCopy Instance {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormCopy();
                }
                return _instance;
            }
        }

        private void FormBookCopy_Load(object sender, EventArgs e)
        {
            dgvBookCopys.DataSource = _service.GetAll();
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
