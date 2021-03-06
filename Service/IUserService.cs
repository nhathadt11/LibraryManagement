﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DatabaseAccess.DataTransferObjects;
using System.Data;

namespace Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        int Add(User user);
        [OperationContract]
        int Delete(int userId);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(User user);
        [OperationContract]
        int CheckUserById(int userId);
        [OperationContract]
        DataTable GetAllLibrarians();
        [OperationContract]
        int HasExisted(string Username);
        [OperationContract]
        List<User> GetUsers();
        [OperationContract]
        List<User> GetLibrarians();
        [OperationContract]
        User CheckLogin(string username, string password);
    }
}
