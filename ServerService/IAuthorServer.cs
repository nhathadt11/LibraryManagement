using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;
namespace Server
{
    [ServiceContract]
    interface IAuthorServer
    {
        [OperationContract]
        int Add(Author author);
        [OperationContract]
        int Delete(int authorId);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(Author author);
    }
}
