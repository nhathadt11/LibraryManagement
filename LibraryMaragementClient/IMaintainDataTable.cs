using System.Data;

namespace LibraryMaragementClient
{
    interface IMaintainDataTable<T>
    {
        DataRow GetCurrentSelectedDataRow();
        void AddToDataTable(T obj);
        void UpdateToDataTable(T obj);
        void DeleteFromDataTable();
    }
}
