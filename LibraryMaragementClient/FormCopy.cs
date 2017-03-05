using System;
using System.Windows.Forms;
using Service;
using DatabaseAccess.DataTransferObjects;
using System.Data;

namespace LibraryMaragementClient
{
    public partial class FormCopy : Form, IMaintainDataTable<DataTranseferObject>
    {
        private BookCopyService _copyService;
        private static FormCopy _instance;
        private DataTable _data;
        private FormCopy()
        {
            InitializeComponent();
            _copyService = new BookCopyService();
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
            _data = _copyService.GetAll();
            _data.PrimaryKey = new DataColumn[] { _data.Columns["CopyCode"] };
            dgvBookCopies.DataSource = _data;
        }

        public DataRow GetCurrentSelectedDataRow()
        {
            return _data.Rows[dgvBookCopies.CurrentRow.Index];
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Copy copy = obj as Copy;
            _data.RejectChanges();
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
            DataRow row = _data.Rows[dgvBookCopies.CurrentRow.Index];
            if (_copyService.Delete(Convert.ToInt32(row["CopyCode"])) > 0)
            {
                MessageBox.Show("Successfully deleted " + row["CopyCode"] + "!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _data.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Could not delete " + row["CopyCode"] + "!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
