using DatabaseAccess.DataTransferObjects;
using System.Data;
using System.Data.SqlClient;
using System;

namespace DatabaseAccess.DatabaseAccessObjects
{
    public class CopyDAO : IDataAccessObject<Copy>
    {
        private readonly string SQL_COPY_SELECT = "SELECT * FROM Copies";

        //required @BookId
        private readonly string SQL_COPY_INSERT = "InsertCopy";//return -1 if BookId not exists in Books
                                                                          //return 1 if Insert Successfully
        private readonly string SQL_COPY_UPDATE = "";

        //required @CopyId
        private readonly string SQL_COPY_DELETE = "DeleteCopiesById";//return -1 if this Copy adlready reference by the other

        //return 0 if this Id not exists
        //return 1 if delete successfully
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
            return _dataProvider.ExecuteQuery(SQL_COPY_SELECT,
                                              CommandType.Text);
        }
        public int Add(Copy copy)
        {
            return _dataProvider.ExecuteNonQuery(SQL_COPY_INSERT,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@CopyCode", copy.CopyId),
                                                new SqlParameter("@BookId", copy.BookId),
                                                new SqlParameter("@IsAvailable", copy.IsAvailable));
        }
        public int Update(Copy copy)
        {
            return _dataProvider.ExecuteNonQuery(SQL_COPY_UPDATE,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@BookId", copy.BookId),
                                                new SqlParameter("@IsAvailable", copy.IsAvailable),
                                                new SqlParameter("@CopyCode", copy.CopyId));
        }
        public int Delete(int CopyId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_COPY_DELETE,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@CopyCode", CopyId));
        }
        public bool CheckValidCopyId(int copyId)
        {
            return _dataProvider.ExecuteQuery("SELECT * FROM Copies WHERE CopyId = @CopyId",
                                               CommandType.Text,
                                               new SqlParameter("@CopyId", copyId)).Rows.Count > 0;
        }
    }
}
