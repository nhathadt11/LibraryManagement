using BussinessLogic.DataTransferObjects;
using Service;
using System;
using System.Windows.Forms;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormPublisher : Form, IMaintainDataTable<DataTranseferObject>
    {
        private PublisherService _service;
        private static FormPublisher _instance;
        private FormPublisher()
        {
            InitializeComponent();
            _service = new PublisherService();
        }
        public static FormPublisher Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormPublisher();
                }
                return _instance;
            }
        }

        private void FormPublisher_Load(object sender, EventArgs e)
        {
            dgvPublishers.DataSource = _service.GetAll();

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
