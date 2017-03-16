using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.DataTransferObjects;
using Service;
namespace Server
{
    class AuthorService_Server : IAuthorServer
    {
        AuthorService _authorService = new AuthorService();
        public AuthorService_Server()
        {

        }
        public int Add(Author author)
        {
            return _authorService.Add(author);
        }

        public int Delete(int authorId)
        {
            return _authorService.Delete(authorId);
        }

        public DataTable GetAll()
        {
            return _authorService.GetAll();
        }

        public int Update(Author author)
        {
            return _authorService.Update(author);
        }
    }
}
