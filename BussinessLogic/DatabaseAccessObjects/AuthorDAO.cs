using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    class AuthorDAO : IDataAccessObject<Author>
    {
        private readonly string SQL_STORE_PROC_AUTHOR_SELECT = "";
        private readonly string SQL_STORE_PROC_AUTHOR_INSERT = "";
        private readonly string SQL_STORE_PROC_AUTHOR_UPDATE = "";
        private readonly string SQL_STORE_PROC_AUTHOR_DELETE = "";
        private DataProvider _dataProvider;
        private static AuthorDAO _instance;
        private AuthorDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static AuthorDAO Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AuthorDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_AUTHOR_SELECT,
                                              CommandType.StoredProcedure);
        }

        public int Add(Author author)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_AUTHOR_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@FullName", author.FullName),
                                                 new SqlParameter("@Contact", author.Contact),
                                                 new SqlParameter("@Address", author.Address),
                                                 new SqlParameter("@Bio", author.Bio));
        }

        public int Update(Author author)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_AUTHOR_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@FullName", author.FullName),
                                                 new SqlParameter("@Contact", author.Contact),
                                                 new SqlParameter("@Address", author.Address),
                                                 new SqlParameter("@Bio", author.Bio),
                                                 new SqlParameter("@AuthorId", author.AuthorId));
        }

        public int Delete(int authorId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_AUTHOR_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@AuthorId", authorId));
        }
    }
}
