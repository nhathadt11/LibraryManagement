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
    public interface IBookCopyService
    {
        [OperationContract]
         int Add(Copy copy);
        [OperationContract]
        int Delete(int copyCode);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(Copy copy);
        [OperationContract]
        bool CheckValidCopyId(int copyId);
        [OperationContract]
        List<Copy> getCopies();
    }
}
