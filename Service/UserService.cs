using System.Data;
using DatabaseAccess.DataTransferObjects;
using DatabaseAccess.DatabaseAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class UserService : ICommonService<User>,IUserService
    {
        private UserDAO _userDAO;
        public UserService()
        {
            _userDAO = UserDAO.Instance;
        }
        public int Add(User user)
        {
            return _userDAO.Add(user);
        }

        public int Delete(int userId)
        {
            return _userDAO.Delete(userId);
        }

        public DataTable GetAll()
        {
            return _userDAO.GetAll();
        }

        public int Update(User user)
        {
            return _userDAO.Update(user);
        }
        public int CheckUserById(int userId)
        {
            return _userDAO.CheckUserById(userId);
        }
        public DataTable GetAllLibrarians()
        {
            return _userDAO.GetAllLibrarians();
        }
        public int HasExisted(string Username)
        {
           return _userDAO.HasExisted(Username);
        }

        public List<User> GetUsers()
        {
            return _userDAO.GetAll().Rows.Cast<DataRow>()
                .Select<DataRow,User>(r => new User
                {
                    UserId = Convert.ToInt32(r["UserId"]),
                    Username = Convert.ToString(r["Username"]),
                    Password = Convert.ToString(r["Password"]),
                    FullName = Convert.ToString(r["FullName"]),
                    PhoneNumber = Convert.ToString(r["PhoneNumber"]),
                    Address = Convert.ToString(r["Address"]),
                    Email = Convert.ToString(r["Email"]),
                    RoleId = Convert.ToInt32(r["RoleId"])
                }).ToList();
        }

        public List<User> GetLibrarians()
        {
            return _userDAO.GetAllLibrarians().Rows.Cast<DataRow>()
                .Select<DataRow, User>(r => new User
                {
                    UserId = Convert.ToInt32(r["UserId"]),
                    Username = Convert.ToString(r["Username"]),
                    Password = Convert.ToString(r["Password"]),
                    FullName = Convert.ToString(r["FullName"]),
                    PhoneNumber = Convert.ToString(r["PhoneNumber"]),
                    Address = Convert.ToString(r["Address"]),
                    Email = Convert.ToString(r["Email"]),
                    RoleId = Convert.ToInt32(r["RoleId"])
                }).ToList();
        }
        public User CheckLogin(string username, string password)
        {
            DataTable data = _userDAO.CheckLogin(username, password);
            return data.Rows.Count != 0 ? new User { FullName = data.Rows[0].Field<string>("FullName") } : null;
        }
    }
}
