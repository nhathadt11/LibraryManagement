using System;
using System.Windows.Forms;
using Service;
using DatabaseAccess.DataTransferObjects;
using System.Data;
using System.Collections.Generic;

namespace LibraryMaragementClient
{
    public partial class FormCopy : Form, IMaintainDataTable<DataTranseferObject>
    {
        private BookCopyServiceReference.IBookCopyService _copyService;
        private static FormCopy _instance;
        private DataTable _data;
        private FormCopy()
        {
            InitializeComponent();
            _copyService = new BookCopyServiceReference.BookCopyServiceClient();
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
            //_data = _copyService.GetAll();
            _data = new DataTable();
            _data.Columns.Add("CopyId");
            _data.Columns.Add("BookId");
            _data.Columns.Add("IsAvailable");

            List<Copy> copies = _copyService.GetCopies();
            foreach (var copy in copies)
            {
                _data.Rows.Add(copy.CopyId,
                               copy.BookId,
                               copy.IsAvailable);
            }
            _data.PrimaryKey = new DataColumn[] { _data.Columns["CopyId"] };
            dgvBookCopies.DataSource = _data;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            int key = Convert.ToInt32(dgvBookCopies.CurrentRow.Cells["CopyId"].Value);
            return _data.Rows.Find(key);
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Copy copy = obj as Copy;
            _data.Rows.Add(copy.CopyId,
                           copy.BookId,
                           copy.IsAvailable);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Copy copy = obj as Copy;
            DataRow row = _data.Rows.Find(copy.CopyId);
            row["BookId"] = copy.BookId;
            row["IsAvailable"] = copy.IsAvailable;
        }

        public void DeleteFromDataTable()
        {
            DataRow row = GetCurrentSelectedDataRow();
            if (_copyService.Delete(Convert.ToInt32(row["CopyId"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["CopyId"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["CopyId"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtCopyFilterById_TextChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = "Convert(CopyId,'System.String') LIKE '%" + txtCopyFilterById.Text + "%'";
        }
    }
}
