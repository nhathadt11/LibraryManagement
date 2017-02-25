using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    class BookDAO : IDataAccessObject<Book>
    {
        private static readonly string SQL_BOOK_SELECT = "";
        private static readonly string SQL_BOOK_INSERT = "";
        private static readonly string SQL_BOOK_UPDATE = "";
        private static readonly string SQL_BOOK_DELETE = "";
        private static DataProvider _dataProvider;
        private static BookDAO _instance;
        private BookDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static BookDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookDAO();
                }
                return _instance;
            }
        }
        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_BOOK_SELECT,
                                              CommandType.StoredProcedure);
        }
        public int Add(Book book)
        {
            return _dataProvider.ExecuteNonQuery(SQL_BOOK_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Isbn", book.Isbn),
                                                 new SqlParameter("@Title", book.Title),
                                                 new SqlParameter("@Description", book.Description),
                                                 new SqlParameter("@CoverImageUrl", book.CoverImageUrl),
                                                 new SqlParameter("@PageNumber", book.PageNumber),
                                                 new SqlParameter("@PublishedDate", book.PublishedDate),
                                                 new SqlParameter("@Discontinued", book.Discontinued),
                                                 new SqlParameter("@AuthorId", book.AuthorId),
                                                 new SqlParameter("@CategoryId", book.CategoryId),
                                                 new SqlParameter("@PublisherId", book.PublisherId));
        }
        public int Update(Book book)
        {
            return _dataProvider.ExecuteNonQuery(SQL_BOOK_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Isbn", book.Isbn),
                                                 new SqlParameter("@Title", book.Title),
                                                 new SqlParameter("@Description", book.Description),
                                                 new SqlParameter("@CoverImageUrl", book.CoverImageUrl),
                                                 new SqlParameter("@PageNumber", book.PageNumber),
                                                 new SqlParameter("@PublishedDate", book.PublishedDate),
                                                 new SqlParameter("@Discontinued", book.Discontinued),
                                                 new SqlParameter("@AuthorId", book.AuthorId),
                                                 new SqlParameter("@CategoryId", book.CategoryId),
                                                 new SqlParameter("@PublisherId", book.PublisherId),
                                                 new SqlParameter("@BookId", book.BookId));
        }
        public int Delete(int bookId)
        {
            DataProvider dataProvider = DataProvider.Instance;
            string sql = ""; // store proc name
            return dataProvider.ExecuteNonQuery(sql,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@BookId", bookId));
        }
    }
}
