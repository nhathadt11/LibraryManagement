using DatabaseAccess.DataTransferObjects;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{

    public partial class CategoryDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private CategoryService _categoryService;
        private Category _category;
        private ActionType _action;

        public CategoryDialog()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _action = ActionType.Add;
        }
        public CategoryDialog(DataRow row) : this()
        {
            txtCategoryId.Text = Convert.ToString(row["CategoryId"]);
            txtCategoryName.Text = Convert.ToString(row["Name"]);
            _action = ActionType.Edit;
        }
        private bool IsVaild()
        {
            bool valid = true;
            if (txtCategoryName.Text.Equals(string.Empty))
            {
                epvCategoryName.SetError(txtCategoryName, "Required");
                valid = false;
            }
            return valid;
        }

        private void btnCategoryOK_Click(object sender, EventArgs e)
        {
            if (!IsVaild())
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _category = new Category
                {
                    Name = txtCategoryName.Text
                };
                if (_action == ActionType.Add) // insert
                {
                    _category.CategoryId = _categoryService.Add(_category);
                    if (_category.CategoryId > 0) // success
                    {
                        MessageBox.Show("Successfully added " + _category.Name + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not add " + _category.Name + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else // update
                {
                    _category.CategoryId = Convert.ToInt32(txtCategoryId.Text);
                    if (_categoryService.Update(_category) > 0) // success
                    {
                        MessageBox.Show("Successfully updated " + _category.Name + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else // fail
                    {
                        MessageBox.Show("Could not update " + _category.Name + "!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _category;
        }
    }
}
