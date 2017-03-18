using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BookCopyService : ICommonService<Copy>,IBookCopyService
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

        public List<Copy> getCopies()
        {
            return _copyDAO.GetAll().Rows.Cast<DataRow>().Select<DataRow, Copy>(r => new Copy
            {
                BookId = Convert.ToInt32(r["BookId"]),
                CopyId = Convert.ToInt32(r["CopyId"]),
                IsAvailable = Convert.ToBoolean(r["IsAvailable"])
            }).ToList();
        }
    }
}
