﻿using DatabaseAccess.DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess.DatabaseAccessObjects
{
    public class AuthorDAO : IDataAccessObject<Author>
    {
        private readonly string SQL_AUTHOR_SELECT = "SELECT * FROM Authors";
        private readonly string SQL_AUTHOR_INSERT = "InsertAuthor"; //return Author ID 
                                                                    //@FullName - required
                                                                    //@Contact - optional
                                                                    //@Address - optional
                                                                    //@Bio - opntional
        //@AuthorId int,
        //@FullName nvarchar(300),
        //@Contact nvarchar(1000),
        //@Address nvarchar(300),
        //@Bio nvarchar(MAX)
        private readonly string SQL_AUTHOR_UPDATE = "UpdateAuthorById"; //return 0 if this id not exists
                                                                        //return -1 if has been reference
                                                                        //return > 0 if update successfully


        private readonly string SQL_AUTHOR_DELETE = "DeleteAuthorById";//accept @AuthorId and return -1|0|1
                                                                                  // -1 if already reference by the others
                                                                                  // 0 if this ID does not exist
                                                                                  // 1 if successfully
        private DataProvider _dataProvider;
        private static AuthorDAO _instance;
        private AuthorDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static AuthorDAO Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AuthorDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_AUTHOR_SELECT,
                                              CommandType.Text);
        }

        public int Add(Author author)
        {
            return _dataProvider.ExecuteNonQuery(SQL_AUTHOR_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@FullName", author.FullName),
                                                 new SqlParameter("@Contact", author.Contact),
                                                 new SqlParameter("@Address", author.Address),
                                                 new SqlParameter("@Bio", author.Bio));
        }

        public int Update(Author author)
        {
            return _dataProvider.ExecuteNonQuery(SQL_AUTHOR_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@FullName", author.FullName),
                                                 new SqlParameter("@Contact", author.Contact),
                                                 new SqlParameter("@Address", author.Address),
                                                 new SqlParameter("@Bio", author.Bio),
                                                 new SqlParameter("@AuthorId", author.AuthorId));
        }

        public int Delete(int authorId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_AUTHOR_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@AuthorId", authorId));
        }
    }
}
