using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    class PublisherDAO : IDataAccessObject<Publisher>
    {
        private readonly string SQL_STORE_PROC_PUBLISHER_SELECT = "";
        private readonly string SQL_STORE_PROC_PUBLISHER_INSERT = "";
        private readonly string SQL_STORE_PROC_PUBLISHER_UPDATE = "";
        private readonly string SQL_STORE_PROC_PUBLISHER_DELETE = "";
        private DataProvider _dataProvider;
        private static PublisherDAO _instance;
        private PublisherDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static PublisherDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PublisherDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_PUBLISHER_SELECT,
                                                 CommandType.StoredProcedure);
        }

        public int Add(Publisher publisher)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_PUBLISHER_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", publisher.Name),
                                                 new SqlParameter("@Contact", publisher.Contact),
                                                 new SqlParameter("@Address", publisher.Address),
                                                 new SqlParameter("@Description", publisher.Description));
        }

        public int Update(Publisher publisher)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_PUBLISHER_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", publisher.Name),
                                                 new SqlParameter("@Contact", publisher.Contact),
                                                 new SqlParameter("@Address", publisher.Address),
                                                 new SqlParameter("@Description", publisher.Description),
                                                 new SqlParameter("@PublisherId", publisher.PublisherId));
        }

        public int Delete(int publisherId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_PUBLISHER_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@PublisherId", publisherId));
        }
    }
}
