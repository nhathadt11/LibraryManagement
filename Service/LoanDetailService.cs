using System.Data;
using BussinessLogic.DataTransferObjects;
using BussinessLogic.DatabaseAccessObjects;

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
    }
}
