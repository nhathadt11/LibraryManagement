using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;

namespace Service
{
    public class AuthorService : ICommonService<Author>
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

        public int Update(Author author)
        {
            return _authorDAO.Update(author);
        }
    }
}
