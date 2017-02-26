using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class UserDAO : IDataAccessObject<User>
    {
        private readonly string SQL_STORE_PROC_USER_SELECT = "";
        private readonly string SQL_STORE_PROC_USER_INSERT = "";
        private readonly string SQL_STORE_PROC_USER_UPDATE = "";
        private readonly string SQL_STORE_PROC_USER_DELETE = "";
        private DataProvider _dataProvider;
        private static UserDAO _instance;
        private UserDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static UserDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_USER_SELECT,
                                              CommandType.Text);
        }

        public int Add(User user)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_USER_INSERT,
                                              CommandType.StoredProcedure,
                                              new SqlParameter("@Username", user.Username),
                                              new SqlParameter("@Password", user.Password),
                                              new SqlParameter("@PhoneNumber", user.PhoneNumber),
                                              new SqlParameter("@Address", user.Address),
                                              new SqlParameter("@Email", user.Email),
                                              new SqlParameter("@RoleId", user.RoleId));
        }

        public int Update(User user)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_USER_UPDATE,
                                              CommandType.StoredProcedure,
                                              new SqlParameter("@Username", user.Username),
                                              new SqlParameter("@Password", user.Password),
                                              new SqlParameter("@PhoneNumber", user.PhoneNumber),
                                              new SqlParameter("@Address", user.Address),
                                              new SqlParameter("@Email", user.Email),
                                              new SqlParameter("@RoleId", user.RoleId),
                                              new SqlParameter("@UserId", user.UserId));
        }

        public int Delete(int userId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_USER_SELECT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@UserId", userId));
        }
    }
}
