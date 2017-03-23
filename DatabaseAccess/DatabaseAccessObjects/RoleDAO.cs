using DatabaseAccess.DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess.DatabaseAccessObjects
{
    public class RoleDAO : IDataAccessObject<Role>
    {
        private readonly string SQL_ROLE_SELECT = "SELECT * FROM Roles";

        //required @Name
        private readonly string SQL_ROLE_INSERT = "InsertRole";//return -1 if this name already existed
                                                               //return RoleId if insert successfully

        //required - @RoleId
        //required - @Name 
        private readonly string SQL_ROLE_UPDATE = "UpdateRoleById";//return >1 if update successfully
                                                                   //

        //required @RoleID
        private readonly string SQL_ROLE_DELETE = "DeleteRoleById";//return -1 if this has already reference by the others
                                                                              //return 0 if this id not exist
                                                                              //return 1 if delete successfully
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
            return _dataProvider.ExecuteQuery(SQL_ROLE_SELECT,
                                              CommandType.Text);
        }

        public int Add(Role role)
        {
            return _dataProvider.ExecuteNonQuery(SQL_ROLE_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", role.Name));
        }

        public int Update(Role role)
        {
            return _dataProvider.ExecuteNonQuery(SQL_ROLE_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", role.Name),
                                                 new SqlParameter("@RoleId", role.RoleId));
        }

        public int Delete(int rolerId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_ROLE_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@RoleId", rolerId));
        }
    }
}
