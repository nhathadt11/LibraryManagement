﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryMaragementClient.UserServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Add", ReplyAction="http://tempuri.org/IUserService/AddResponse")]
        int Add(DatabaseAccess.DataTransferObjects.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Add", ReplyAction="http://tempuri.org/IUserService/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(DatabaseAccess.DataTransferObjects.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Delete", ReplyAction="http://tempuri.org/IUserService/DeleteResponse")]
        int Delete(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Delete", ReplyAction="http://tempuri.org/IUserService/DeleteResponse")]
        System.Threading.Tasks.Task<int> DeleteAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAll", ReplyAction="http://tempuri.org/IUserService/GetAllResponse")]
        System.Data.DataTable GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAll", ReplyAction="http://tempuri.org/IUserService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Update", ReplyAction="http://tempuri.org/IUserService/UpdateResponse")]
        int Update(DatabaseAccess.DataTransferObjects.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Update", ReplyAction="http://tempuri.org/IUserService/UpdateResponse")]
        System.Threading.Tasks.Task<int> UpdateAsync(DatabaseAccess.DataTransferObjects.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CheckUserById", ReplyAction="http://tempuri.org/IUserService/CheckUserByIdResponse")]
        int CheckUserById(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CheckUserById", ReplyAction="http://tempuri.org/IUserService/CheckUserByIdResponse")]
        System.Threading.Tasks.Task<int> CheckUserByIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllLibrarians", ReplyAction="http://tempuri.org/IUserService/GetAllLibrariansResponse")]
        System.Data.DataTable GetAllLibrarians();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllLibrarians", ReplyAction="http://tempuri.org/IUserService/GetAllLibrariansResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetAllLibrariansAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/HasExisted", ReplyAction="http://tempuri.org/IUserService/HasExistedResponse")]
        int HasExisted(string Username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/HasExisted", ReplyAction="http://tempuri.org/IUserService/HasExistedResponse")]
        System.Threading.Tasks.Task<int> HasExistedAsync(string Username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUsers", ReplyAction="http://tempuri.org/IUserService/GetUsersResponse")]
        System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User> GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUsers", ReplyAction="http://tempuri.org/IUserService/GetUsersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User>> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetLibrarians", ReplyAction="http://tempuri.org/IUserService/GetLibrariansResponse")]
        System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User> GetLibrarians();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetLibrarians", ReplyAction="http://tempuri.org/IUserService/GetLibrariansResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User>> GetLibrariansAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CheckLogin", ReplyAction="http://tempuri.org/IUserService/CheckLoginResponse")]
        DatabaseAccess.DataTransferObjects.User CheckLogin(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CheckLogin", ReplyAction="http://tempuri.org/IUserService/CheckLoginResponse")]
        System.Threading.Tasks.Task<DatabaseAccess.DataTransferObjects.User> CheckLoginAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : LibraryMaragementClient.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<LibraryMaragementClient.UserServiceReference.IUserService>, LibraryMaragementClient.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(DatabaseAccess.DataTransferObjects.User user) {
            return base.Channel.Add(user);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(DatabaseAccess.DataTransferObjects.User user) {
            return base.Channel.AddAsync(user);
        }
        
        public int Delete(int userId) {
            return base.Channel.Delete(userId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int userId) {
            return base.Channel.DeleteAsync(userId);
        }
        
        public System.Data.DataTable GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public int Update(DatabaseAccess.DataTransferObjects.User user) {
            return base.Channel.Update(user);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(DatabaseAccess.DataTransferObjects.User user) {
            return base.Channel.UpdateAsync(user);
        }
        
        public int CheckUserById(int userId) {
            return base.Channel.CheckUserById(userId);
        }
        
        public System.Threading.Tasks.Task<int> CheckUserByIdAsync(int userId) {
            return base.Channel.CheckUserByIdAsync(userId);
        }
        
        public System.Data.DataTable GetAllLibrarians() {
            return base.Channel.GetAllLibrarians();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetAllLibrariansAsync() {
            return base.Channel.GetAllLibrariansAsync();
        }
        
        public int HasExisted(string Username) {
            return base.Channel.HasExisted(Username);
        }
        
        public System.Threading.Tasks.Task<int> HasExistedAsync(string Username) {
            return base.Channel.HasExistedAsync(Username);
        }
        
        public System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User> GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User>> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User> GetLibrarians() {
            return base.Channel.GetLibrarians();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.User>> GetLibrariansAsync() {
            return base.Channel.GetLibrariansAsync();
        }
        
        public DatabaseAccess.DataTransferObjects.User CheckLogin(string username, string password) {
            return base.Channel.CheckLogin(username, password);
        }
        
        public System.Threading.Tasks.Task<DatabaseAccess.DataTransferObjects.User> CheckLoginAsync(string username, string password) {
            return base.Channel.CheckLoginAsync(username, password);
        }
    }
}
