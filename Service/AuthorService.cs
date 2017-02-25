﻿using BussinessLogic.DatabaseAccessObjects;
using BussinessLogic.DataTransferObjects;
using System.Data;

namespace Service
{
    class AuthorService : ICommonService<Author>
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