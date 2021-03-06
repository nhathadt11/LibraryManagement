﻿using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace LibraryMaragementClient
{
    public partial class FormPublisher : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormPublisher _instance;
        private PublisherServiceReference.IPublisherService _publisherService;
        private DataTable _data;
        private FormPublisher()
        {
            InitializeComponent();
            _publisherService = new PublisherServiceReference.PublisherServiceClient();
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
            //_data = _publisherService.GetAll();
            _data = new DataTable();
            _data.Columns.Add("PublisherId");
            _data.Columns.Add("Name");
            _data.Columns.Add("Contact");
            _data.Columns.Add("Address");
            _data.Columns.Add("Description");

            List<Publisher> publishers = _publisherService.GetPublishers();
            foreach (var publisher in publishers)
            {
                _data.Rows.Add(publisher.PublisherId,
                               publisher.Name,
                               publisher.Contact,
                               publisher.Address,
                               publisher.Description);
            }

            _data.PrimaryKey = new DataColumn[] { _data.Columns["PublisherId"] };
            dgvPublishers.DataSource = _data;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            int key = Convert.ToInt32(dgvPublishers.CurrentRow.Cells["PublisherId"].Value);
            return _data.Rows.Find(key);
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Publisher publisher = obj as Publisher;
            _data.Rows.Add(publisher.PublisherId,
                           publisher.Name,
                           publisher.Contact,
                           publisher.Address,
                           publisher.Description);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Publisher publisher = obj as Publisher;
            DataRow row = _data.Rows.Find(publisher.PublisherId);
            row["Name"] = publisher.Name;
            row["Contact"] = publisher.Contact;
            row["Address"] = publisher.Address;
            row["Description"] = publisher.Description;
            dgvPublishers.Refresh();
        }

        public void DeleteFromDataTable()
        {
            DataRow row = GetCurrentSelectedDataRow();
            if (_publisherService.Delete(Convert.ToInt32(row["PublisherId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["Name"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["Name"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtPublisherNameFilter_TextChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = "Name LIKE '%" + txtPublisherNameFilter.Text + "%'";
        }
    }
}
