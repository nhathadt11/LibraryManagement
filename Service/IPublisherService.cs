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
    public interface IPublisherService
    {
        [OperationContract]
        int Add(Publisher publisher);
        [OperationContract]
        int Delete(int publisherId);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(Publisher publisher);
        [OperationContract]
        List<Publisher> GetPublishers();
    }
}
