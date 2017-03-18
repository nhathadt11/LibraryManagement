using System.Data;
using System.ServiceModel;
namespace Service
{
    public interface ICommonService<T>
    {
        DataTable GetAll();
        int Add(T obj);
        int Update(T obj);
        int Delete(int objId);
    }
}
