using BussinessLogic.DatabaseAccessObjects;
using BussinessLogic.DataTransferObjects;
using System.Data;

namespace Service
{
    public class BookService : ICommonService<Book>
    {
        private BookDAO _bookDAO;
        public BookService()
        {
            _bookDAO = BookDAO.Instance;
        }
        public DataTable GetAll()
        {
            return _bookDAO.GetAll();
        }
        public int Add(Book book)
        {
            return _bookDAO.Add(book);
        }
        public int Update(Book book)
        {
            return _bookDAO.Update(book);
        }
        public int Delete(int bookId)
        {
            return _bookDAO.Delete(bookId);
        }
    }
}
