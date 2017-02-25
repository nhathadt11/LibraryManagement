using BussinessLogic.DataTransferObjects;
using System.Data;
using DatabaseAccess;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    class CategoryDAO : IDataAccessObject<Category>
    {
        private readonly string SQL_STORE_PROC_CATEGORY_SELECT = "";
        private readonly string SQL_STORE_PROC_CATEGORY_INSERT = "";
        private readonly string SQL_STORE_PROC_CATEGORY_UPDATE = "";
        private readonly string SQL_STORE_PROC_CATEGORY_DELETE = "";
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
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_CATEGORY_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", category.Name));
        }

        public int Delete(int categoryId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_CATEGORY_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@CategoryId", categoryId));
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_CATEGORY_SELECT,
                                              CommandType.StoredProcedure);
        }

        public int Update(Category category)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_CATEGORY_UPDATE,
                                              CommandType.StoredProcedure,
                                              new SqlParameter("@Name", category.Name),
                                              new SqlParameter("@CategoryId", category.CategoryId));
        }
    }
}
