using System;
using System.Collections.Generic;
using System.Data;
using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Linq;

namespace Service
{
    public class CategoryService : ICommonService<Category>, ICategoryService
    {
        private CategoryDAO _categoryDAO;
        public CategoryService()
        {
            _categoryDAO = CategoryDAO.Instance;
        }

        public int Add(Category category)
        {
            return _categoryDAO.Add(category);
        }

        public int Delete(int categoryId)
        {
            return _categoryDAO.Delete(categoryId);
        }

        public DataTable GetAll()
        {
            return _categoryDAO.GetAll();
        }

        public List<Category> GetCategories()
        {
            return _categoryDAO.GetAll().Rows.Cast<DataRow>()
                .Select<DataRow, Category>(r => new Category
                {
                    CategoryId = Convert.ToInt32(r["CategoryId"]),
                    Name = Convert.ToString(r["Name"])
                }).ToList();
        }

        public int Update(Category category)
        {
            return _categoryDAO.Update(category);
        }
    }
}
