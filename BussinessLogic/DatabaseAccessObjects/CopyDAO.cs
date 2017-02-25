using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;
using System;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class CopyDAO : IDataAccessObject<Copy>
    {
        private readonly string SQL_STORE_PROC_COPY_SELECT = "";
        private readonly string SQL_STORE_PROC_COPY_INSERT = "";
        private readonly string SQL_STORE_PROC_COPY_UPDATE = "";
        private readonly string SQL_STORE_PROC_COPY_DELETE = "";
        private DataProvider _dataProvider;
        private static CopyDAO _instance;
        private CopyDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static CopyDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CopyDAO();
                }
                return _instance;
            }
        }
        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_COPY_SELECT,
                                             CommandType.StoredProcedure);
        }
        public int Add(Copy copy)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_COPY_INSERT,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@CopyCode", copy.CopyCode),
                                                new SqlParameter("@BookId", copy.BookId),
                                                new SqlParameter("@IsAvailable", copy.IsAvailable));
        }
        public int Update(Copy copy)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_COPY_UPDATE,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@BookId", copy.BookId),
                                                new SqlParameter("@IsAvailable", copy.IsAvailable),
                                                new SqlParameter("@CopyCode", copy.CopyCode));
        }
        public int Delete(int copyCode)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_COPY_DELETE,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@BookId", copyCode));
        }
    }
}
