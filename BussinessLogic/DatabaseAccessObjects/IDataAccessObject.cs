using System.Data;

namespace DatabaseAccess.DatabaseAccessObjects
{
    interface IDataAccessObject<T>
    {
        DataTable GetAll();
        int Add(T obj);
        int Update(T obj);
        int Delete(int objId);
    }
}
