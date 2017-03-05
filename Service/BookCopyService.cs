using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;
using System;

namespace Service
{
    public class BookCopyService : ICommonService<Copy>
    {
        private CopyDAO _copyDAO;
        public BookCopyService()
        {
            _copyDAO = CopyDAO.Instance;
        }

        public int Add(Copy copy)
        {
            return _copyDAO.Add(copy);
        }

        public int Delete(int copyCode)
        {
            return _copyDAO.Delete(copyCode);
        }

        public DataTable GetAll()
        {
            return _copyDAO.GetAll();
        }

        public int Update(Copy copy)
        {
            return _copyDAO.Update(copy);
        }

        public bool CheckValidCopyId(int copyId)
        {
            return _copyDAO.CheckValidCopyId(copyId);
        }
    }
}
