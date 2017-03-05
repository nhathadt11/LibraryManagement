using System.Data;
using System.ServiceModel;
namespace Service
{
    [ServiceContract]
    public interface ICommonService<T>
    {
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Add(T obj);
        [OperationContract]
        int Update(T obj);
        [OperationContract]
        int Delete(int objId);
    }
}
