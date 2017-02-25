using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    class RoleDAO : IDataAccessObject<Role>
    {
        private readonly string SQL_STORE_PROC_ROLE_SELECT = "";
        private readonly string SQL_STORE_PROC_ROLE_INSERT = "";
        private readonly string SQL_STORE_PROC_ROLE_UPDATE = "";
        private readonly string SQL_STORE_PROC_ROLE_DELETE = "";
        private DataProvider _dataProvider;
        private static RoleDAO _instance;
        private RoleDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static RoleDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoleDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_ROLE_SELECT,
                                              CommandType.StoredProcedure);
        }

        public int Add(Role role)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_ROLE_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", role.Name));
        }

        public int Update(Role role)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_ROLE_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", role.Name),
                                                 new SqlParameter("@RoleId", role.RoleId));
        }

        public int Delete(int rolerId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_ROLE_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@RoleId", rolerId));
        }
    }
}
