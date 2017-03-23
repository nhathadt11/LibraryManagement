using DatabaseAccess.DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess.DatabaseAccessObjects
{
    public class PublisherDAO : IDataAccessObject<Publisher>
    {
        private readonly string SQL_PUBLISHER_SELECT = "SELECT * FROM Publishers";

        //required @Name nvarchar(300),
        //optional @Contact nvarchar(1000) = null,
        //optional @Address nvarchar(300) = null,
        //opntinal @Description nvarchar(MAX) = null
        private readonly string SQL_PUBLISHER_INSERT = "InsertPublisher";//return publisherId if insert successfully

        //@PublisherId int,
        //@Name nvarchar(300),
        //@Contact nvarchar(1000),
        //@Address nvarchar(300),
        //@Description nvarchar(MAX)
        private readonly string SQL_PUBLISHER_UPDATE = "UpdatePublisherById"; //return 0 if this Id does not exists
                                                                              //return > 0 if Update Successfully
        //required @PublisherId
        private readonly string SQL_PUBLISHER_DELETE = "DeletePublisherById";//return -1 if has been reference by the other
                                                                                        //return 0 if not exists this Id
                                                                                        //return 1 if insert successfully
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
            return _dataProvider.ExecuteQuery(SQL_PUBLISHER_SELECT,
                                              CommandType.Text);
        }

        public int Add(Publisher publisher)
        {
            return _dataProvider.ExecuteNonQuery(SQL_PUBLISHER_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", publisher.Name),
                                                 new SqlParameter("@Contact", publisher.Contact),
                                                 new SqlParameter("@Address", publisher.Address),
                                                 new SqlParameter("@Description", publisher.Description));
        }

        public int Update(Publisher publisher)
        {
            return _dataProvider.ExecuteNonQuery(SQL_PUBLISHER_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Name", publisher.Name),
                                                 new SqlParameter("@Contact", publisher.Contact),
                                                 new SqlParameter("@Address", publisher.Address),
                                                 new SqlParameter("@Description", publisher.Description),
                                                 new SqlParameter("@PublisherId", publisher.PublisherId));
        }

        public int Delete(int publisherId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_PUBLISHER_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@PublisherId", publisherId));
        }
    }
}
