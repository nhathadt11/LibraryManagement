using System;
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
    public interface ICategoryService
    {
        [OperationContract]
         int Add(Category category);
        [OperationContract]
         int Delete(int categoryId);
        [OperationContract]
         DataTable GetAll();
        [OperationContract]
         int Update(Category category);
        [OperationContract]
        List<Category> getCategories();
    }
}
