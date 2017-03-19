using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class AuthorService : ICommonService<Author>, IAuthorService
    {
        private AuthorDAO _authorDAO;
        public AuthorService()
        {
            _authorDAO = AuthorDAO.Instance;
        }

        public int Add(Author author)
        {
            return _authorDAO.Add(author);
        }

        public int Delete(int authorId)
        {
            return _authorDAO.Delete(authorId);
        }

        public DataTable GetAll()
        {
            return _authorDAO.GetAll();
        }

        public List<Author> GetAuthors()
        {
            return _authorDAO.GetAll().Rows.Cast<DataRow>()
                .Select<DataRow, Author>(r => new Author
                {
                    AuthorId = Convert.ToInt32(r["AuthorId"]),
                    FullName = Convert.ToString(r["FullName"]),
                    Contact = Convert.ToString(r["Contact"]),
                    Address = Convert.ToString(r["Address"]),
                    Bio = Convert.ToString(r["Bio"])
                }).ToList();
        }

        public int Update(Author author)
        {
            return _authorDAO.Update(author);
        }
    }
}
