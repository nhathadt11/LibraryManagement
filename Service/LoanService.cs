using System.Data;
using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Service
{
    public class LoanService : ICommonService<Loan>, ILoanService
    {
        private LoanDAO _loanDAO;
        public LoanService()
        {
            _loanDAO = LoanDAO.Instance;
        }

        public int Add(Loan loan)
        {
            return _loanDAO.Add(loan);
        }

        public int Delete(int loanId)
        {
            return _loanDAO.Delete(loanId);
        }

        public DataTable GetAll()
        {
            return _loanDAO.GetAll();
        }

        public int Update(Loan loan)
        {
            return _loanDAO.Update(loan);
        }
        public int Add(Loan loan, List<LoanDetail> loanDetails)
        {
            return _loanDAO.Add(loan, loanDetails);
        }

        public List<Loan> getLoans()
        {
            return _loanDAO.GetAll().Rows.Cast<DataRow>().Select<DataRow, Loan>(r => new Loan
            {
                LoanId = Convert.ToInt32(r["LoanId"]),
                IssueDate = Convert.ToDateTime(r["IssueDate"]),
                LimitDay = Convert.ToInt32(r["LimitDay"]),
                MemberId = Convert.ToInt32(r["MemberId"]),
                LibrarianId = Convert.ToInt32(r["LibrarianId"])
            }).ToList();
        }
    }
}
