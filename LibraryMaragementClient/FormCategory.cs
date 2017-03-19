using Service;
using System;
using System.Data;
using System.Windows.Forms;
using DatabaseAccess.DataTransferObjects;
using System.Collections.Generic;
namespace LibraryMaragementClient
{
    public partial class FormCategory : Form, IMaintainDataTable<DataTranseferObject>
    {
        private static FormCategory _instance;
        private CategoryServiceReference.ICategoryService _categoryService;
        private DataTable _data;

        private FormCategory()
        {
            InitializeComponent();
            _categoryService = new CategoryServiceReference.CategoryServiceClient();
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
            //_data = _categoryService.GetAll();
            _data = new DataTable();
            _data.Columns.Add("CategoryId");
            _data.Columns.Add("Name");

            List<Category> categories = _categoryService.GetCategories();
            foreach (var category in categories)
            {
                _data.Rows.Add(category.CategoryId,
                               category.Name);
            }

            _data.PrimaryKey = new DataColumn[] { _data.Columns["CategoryId"] };
            dgvCategorys.DataSource = _data;
        }

        public void DeleteFromDataTable()
        {
            DataRow row = GetCurrentSelectedDataRow();
            if (_categoryService.Delete(Convert.ToInt32(row["CategoryId"])) > 0)
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

        public DataRow GetCurrentSelectedDataRow()
        {
            int key = Convert.ToInt32(dgvCategorys.CurrentRow.Cells["CategoryId"].Value);
            return _data.Rows.Find(key);
        }

        public void AddToDataTable(DataTranseferObject obj)
        {
            Category category = obj as Category;
            _data.Rows.Add(category.CategoryId,
                           category.Name);
            _data.AcceptChanges();
        }

        public void UpdateToDataTable(DataTranseferObject obj)
        {
            Category category = obj as Category;
            DataRow row = _data.Rows.Find(category.CategoryId);
            row["Name"] = category.Name;
            dgvCategorys.Refresh();
        }

        private void txtCategoryNameFilter_TextChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = "Name LIKE '%" + txtCategoryNameFilter.Text + "%'";
        }
    }
}
