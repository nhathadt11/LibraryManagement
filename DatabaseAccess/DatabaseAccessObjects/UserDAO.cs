﻿using DatabaseAccess.DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess.DatabaseAccessObjects
{
    public class UserDAO : IDataAccessObject<User>
    {
        private readonly string SQL_USER_SELECT = "SELECT * FROM Users";
        private readonly string SQL_USER_SELECT_SINGLE = "SELECT * FROM Users WHERE UserId = @UserId";
        private readonly string SQL_USER_SELECT_LOGIN = @"SELECT * FROM Users WHERE Username = @Username AND Password = @Password
                                                        AND RoleId IN (SELECT RoleId FROM Roles WHERE Name = 'Librarian')";
        private readonly string SQL_USER_HAS_EXISTED = "HasExisted";
        private readonly string SQL_LIBRARIAN_SELECT_ALL = "SELECT * FROM Users WHERE RoleId IN (SELECT RoleId FROM Roles WHERE Name = 'Librarian')";

        //required @Username nvarchar(300),
        //required @Password nvarchar(60),
        //required @RoleId int,
        //optional @PhoneNumber nvarchar(11) = null,
        //optional @Address nvarchar(600) = null,
        //optional @Email nvarchar(50) = null
        private readonly string SQL_USER_INSERT = "InsertUser";//return 1 if insert successfully
                                                                          //return -1 if this user already exists

        //@UserId int,
        //@Username nvarchar(300),
        //@Password nvarchar(60),
        //@PhoneNumber nvarchar(11),
        //@Address nvarchar(600),
        //@Email nvarchar(50),
        //@RoleId int
        //return 0 if user not eixts
        //return -1 if new role not valid
        //return 1 if successfully
        private readonly string SQL_USER_UPDATE = "UpdateUserById";

        //required @UserId int
        //return 0 if user id not exists
        //return -1 if has been reference as Member in Loans
        //return -2 if has been reference as Libraryan in Loans
        //return 1 if deleted successfully
        private readonly string SQL_USER_DELETE = "DeleteUserById";

        private DataProvider _dataProvider;
        private static UserDAO _instance;
        private UserDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static UserDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_USER_SELECT,
                                              CommandType.Text);
        }

        public int Add(User user)
        {
            return _dataProvider.ExecuteNonQuery(SQL_USER_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Username", user.Username),
                                                 new SqlParameter("@Password", user.Password),
                                                 new SqlParameter("@FullName", user.FullName),
                                                 new SqlParameter("@PhoneNumber", user.PhoneNumber),
                                                 new SqlParameter("@Address", user.Address),
                                                 new SqlParameter("@Email", user.Email),
                                                 new SqlParameter("@RoleId", user.RoleId));
        }

        public int Update(User user)
        {
            return _dataProvider.ExecuteNonQuery(SQL_USER_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@Username", user.Username),
                                                 new SqlParameter("@Password", user.Password),
                                                 new SqlParameter("@PhoneNumber", user.PhoneNumber),
                                                 new SqlParameter("@Address", user.Address),
                                                 new SqlParameter("@Email", user.Email),
                                                 new SqlParameter("@RoleId", user.RoleId),
                                                 new SqlParameter("@FullName", user.FullName),
                                                 new SqlParameter("@UserId", user.UserId));
        }

        public int Delete(int userId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_USER_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@UserId", userId));
        }
        public int HasExisted(string Username)
        {
            return _dataProvider.ExecuteQuery(SQL_USER_HAS_EXISTED,
                                              CommandType.StoredProcedure,
                                              new SqlParameter("@Username",Username)).Rows.Count;
        }
        public int CheckUserById(int userId)
        {
            return _dataProvider.ExecuteQuery(SQL_USER_SELECT_SINGLE,
                                              CommandType.Text,
                                              new SqlParameter("@UserId", userId)).Rows.Count;
        }
        public DataTable GetAllLibrarians()
        {
            return _dataProvider.ExecuteQuery(SQL_LIBRARIAN_SELECT_ALL,
                                              CommandType.Text);
        }
        public DataTable CheckLogin(string username, string password)
        {
            return _dataProvider.ExecuteQuery(SQL_USER_SELECT_LOGIN,
                                              CommandType.Text,
                                              new SqlParameter("@Username", username),
                                              new SqlParameter("@Password", password));
        }
    }
}
