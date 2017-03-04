using System.Data;
using BussinessLogic.DataTransferObjects;
using BussinessLogic.DatabaseAccessObjects;
using System.Collections.Generic;
using System;

namespace Service
{
    public class LoanDetailService : ICommonService<LoanDetail>
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
                    ReturnDate = Convert.ToDateTime(row["ReturnDate"])
                });
            }
            return details;
        }
    }
}
