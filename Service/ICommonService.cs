using System.Data;

namespace Service
{
    interface ICommonService<T>
    {
        DataTable GetAll();
        int Add(T obj);
        int Update(T obj);
        int Delete(int objId);
    }
}
