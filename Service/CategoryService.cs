using System.Data;
using BussinessLogic.DatabaseAccessObjects;
using BussinessLogic.DataTransferObjects;

namespace Service
{
    public class CategoryService : ICommonService<Category>
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

        public int Update(Category category)
        {
            return _categoryDAO.Update(category);
        }
    }
}
