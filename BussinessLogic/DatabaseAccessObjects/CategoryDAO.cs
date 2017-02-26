using BussinessLogic.DataTransferObjects;
using System.Data;
using DatabaseAccess;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class CategoryDAO : IDataAccessObject<Category>
    {
        private readonly string SQL_CATEGORY_SELECT = "SELECT * FROM Categories";

        //required @Name
        private readonly string SQL_CATEGORY_INSERT = "InsertCategory";//return Id this Category if insert successfully
                                                                                  //return -1 if this Category already existed

        private readonly string SQL_CATEGORY_UPDATE = "";

        //required @CategoryID
        private readonly string SQL_CATEGORY_DELETE = "DeleteCategoryByID";//return -1 if this category already reference by the others
                                                                                      //return 0 if this category does not exists
                                                                                      //return 1 if this category deleted successfully
        private DataProvider _dataProvider;
        private static CategoryDAO _instance;
        private CategoryDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static CategoryDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoryDAO();
                }
                return _instance;
            }
        }
        public int Add(Category category)
        {
            return _dataProvider.ExecuteNonQuery(SQL_CATEGORY_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", category.Name));
        }

        public int Delete(int categoryId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_CATEGORY_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@CategoryId", categoryId));
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_CATEGORY_SELECT,
                                              CommandType.Text);
        }

        public int Update(Category category)
        {
            return _dataProvider.ExecuteNonQuery(SQL_CATEGORY_UPDATE,
                                              CommandType.StoredProcedure,
                                              new SqlParameter("@Name", category.Name),
                                              new SqlParameter("@CategoryId", category.CategoryId));
        }
    }
}
