using System.Data;
using BussinessLogic.DataTransferObjects;
using BussinessLogic.DatabaseAccessObjects;
using System;

namespace Service
{
    class LoanDetailService : ICommonService<LoanDetail>
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
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            return _loanDetailDAO.GetAll();
        }

        public int Update(LoanDetail loanDetail)
        {
            return _loanDetailDAO.Update(loanDetail);
        }
    }
}
