﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryMaragementClient.CategoryServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CategoryServiceReference.ICategoryService")]
    public interface ICategoryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/Add", ReplyAction="http://tempuri.org/ICategoryService/AddResponse")]
        int Add(DatabaseAccess.DataTransferObjects.Category category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/Add", ReplyAction="http://tempuri.org/ICategoryService/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(DatabaseAccess.DataTransferObjects.Category category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/Delete", ReplyAction="http://tempuri.org/ICategoryService/DeleteResponse")]
        int Delete(int categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/Delete", ReplyAction="http://tempuri.org/ICategoryService/DeleteResponse")]
        System.Threading.Tasks.Task<int> DeleteAsync(int categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetAll", ReplyAction="http://tempuri.org/ICategoryService/GetAllResponse")]
        System.Data.DataTable GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetAll", ReplyAction="http://tempuri.org/ICategoryService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/Update", ReplyAction="http://tempuri.org/ICategoryService/UpdateResponse")]
        int Update(DatabaseAccess.DataTransferObjects.Category category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/Update", ReplyAction="http://tempuri.org/ICategoryService/UpdateResponse")]
        System.Threading.Tasks.Task<int> UpdateAsync(DatabaseAccess.DataTransferObjects.Category category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetCategories", ReplyAction="http://tempuri.org/ICategoryService/GetCategoriesResponse")]
        System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.Category> GetCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetCategories", ReplyAction="http://tempuri.org/ICategoryService/GetCategoriesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.Category>> GetCategoriesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICategoryServiceChannel : LibraryMaragementClient.CategoryServiceReference.ICategoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategoryServiceClient : System.ServiceModel.ClientBase<LibraryMaragementClient.CategoryServiceReference.ICategoryService>, LibraryMaragementClient.CategoryServiceReference.ICategoryService {
        
        public CategoryServiceClient() {
        }
        
        public CategoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(DatabaseAccess.DataTransferObjects.Category category) {
            return base.Channel.Add(category);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(DatabaseAccess.DataTransferObjects.Category category) {
            return base.Channel.AddAsync(category);
        }
        
        public int Delete(int categoryId) {
            return base.Channel.Delete(categoryId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int categoryId) {
            return base.Channel.DeleteAsync(categoryId);
        }
        
        public System.Data.DataTable GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public int Update(DatabaseAccess.DataTransferObjects.Category category) {
            return base.Channel.Update(category);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(DatabaseAccess.DataTransferObjects.Category category) {
            return base.Channel.UpdateAsync(category);
        }
        
        public System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.Category> GetCategories() {
            return base.Channel.GetCategories();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseAccess.DataTransferObjects.Category>> GetCategoriesAsync() {
            return base.Channel.GetCategoriesAsync();
        }
    }
}
