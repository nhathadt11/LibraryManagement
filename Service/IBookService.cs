using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;
using DatabaseAccess.DataTransferObjects;

namespace Service
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Add(Book book);
        [OperationContract]
        int Update(Book book);
        [OperationContract]
        int Delete(int bookId);
        [OperationContract]
        List<Book> GetBooks();
    }
}
