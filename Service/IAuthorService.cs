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
    public interface IAuthorService
    {
        [OperationContract]
         int Add(Author author);
        [OperationContract]
         int Delete(int authorId);
        [OperationContract]
         DataTable GetAll();
        [OperationContract]
         int Update(Author author);
        [OperationContract]
        List<Author> getAuthors();
    }
}
