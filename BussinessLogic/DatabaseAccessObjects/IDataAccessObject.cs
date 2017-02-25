using System.Data;

namespace BussinessLogic.DatabaseAccessObjects
{
    interface IDataAccessObject<T>
    {
        DataTable GetAll();
        int Add(T obj);
        int Update(T obj);
        int Delete(int objId);
    }
}
