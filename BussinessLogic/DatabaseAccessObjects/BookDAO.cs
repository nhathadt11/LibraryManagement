using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class BookDAO : IDataAccessObject<Book>
    {
        private readonly string SQL_BOOK_SELECT = "SELECT * FROM vBooks";

        //optional - @Isbn nvarchar(MAX) = N'N/A'
        //required - @Title nvarchar(MAX) 
        //optional - @Description nvarchar(MAX) = N'N/A',
        //optional - @CoverImageUrl nvarchar(MAX) = N'DefaultCover.jpg',
        //optional - @PageNumber int = 300,
        //opntional - @PublishedDate date = getdate,
        //required - @AuthorId int,
        //required - @CategoryId int,
        //required - @PublisherId int,
        //opntional - @Discontinued bit = 0
        private readonly string SQL_BOOK_INSERT = "InsertBook";//return -1 if AuthorId not valid
                                                                        //return -2 if PublisherId not valid
                                                                        //return -3 if CategoryId not valid
                                                                        //return BookId if insert successfully

        private readonly string SQL_BOOK_UPDATE = "";

        //required - @BookId
        private readonly string SQL_BOOK_DELETE = "DeleteBookById";//return -1 if this Book already reference by the other
                                                                              //return 0 if this BookId not exists in Database
                                                                              //return 1 if delete successfully
        private DataProvider _dataProvider;
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
                                              CommandType.Text);
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
            return _dataProvider.ExecuteNonQuery(SQL_BOOK_DELETE,
                                                CommandType.StoredProcedure,
                                                new SqlParameter("@BookId", bookId));
        }
    }
}
