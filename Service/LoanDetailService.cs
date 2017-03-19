using System.Data;
using DatabaseAccess.DataTransferObjects;
using DatabaseAccess.DatabaseAccessObjects;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Service
{
    public class LoanDetailService : ICommonService<LoanDetail>, ILoanDetailService
    {
        private LoanDetailDAO _loanDetailDAO;
        public LoanDetailService()
        {
            _loanDetailDAO = LoanDetailDAO.Instance;
        }
        public int Add(LoanDetail loanDetail)
        {
            return _loanDetailDAO.Add(loanDetail);
        }

        public int Delete(int loanDetailId)
        {
            return _loanDetailDAO.Delete(loanDetailId);
        }

        public DataTable GetAll()
        {
            return _loanDetailDAO.GetAll();
        }

        public int Update(LoanDetail loanDetail)
        {
            return _loanDetailDAO.Update(loanDetail);
        }
        public List<LoanDetail> GetLoanDetailsByLoanId(int loanId)
        {
            DataTable data = _loanDetailDAO.GetLoanDetailsByLoanId(loanId);
            List<LoanDetail> details = new List<LoanDetail>();
            foreach (var row in data.AsEnumerable())
            {
                details.Add(new LoanDetail {
                    CopyId = Convert.ToInt32(row["CopyId"]),
                    LoanId = loanId,
                    ReturnDate = Convert.ToDateTime(row["ReturnDate"] == DBNull.Value ? null : row["ReturnDate"])
                });
            }
            return details;
        }

        public List<LoanDetail> GetLoanDetails()
        {
            return _loanDetailDAO.GetAll().Rows.Cast<DataRow>()
                .Select<DataRow, LoanDetail>(r => new LoanDetail
                {
                    CopyId = Convert.ToInt32(r["CopyId"]),
                    LoanId = Convert.ToInt32(r["LoanId"]),
                    ReturnDate = Convert.ToDateTime(r["ReturnDate"])
                }).ToList();
        }
    }
}
