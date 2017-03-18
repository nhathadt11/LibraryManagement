using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BookService : ICommonService<Book>,IBookService
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

        public List<Book> getBooks()
        {
            return _bookDAO.GetAll().Rows.Cast<DataRow>().Select<DataRow, Book>(r => new Book
            {
                BookId = Convert.ToInt32(r["BookId"]),
                Isbn = Convert.ToString(r["Isbn"]),
                Title = Convert.ToString(r["Title"]),
                Description = Convert.ToString(r["Description"]),
                CoverImageUrl = Convert.ToString(r["CoverImageUrl"]),
                PageNumber = Convert.ToInt32(r["PageNumber"]),
                PublishedDate = Convert.ToDateTime(r["PublishedDate"]),
                AuthorId = Convert.ToInt32(r["AuthorId"]),
                CategoryId = Convert.ToInt32(r["CategoryId"]),
                PublisherId = Convert.ToInt32(r["PublisherId"]),
                Discontinued = Convert.ToBoolean(r["Discontinued"])
            }).ToList();
        }
    }
}
