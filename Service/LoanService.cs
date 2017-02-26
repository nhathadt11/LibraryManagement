using System.Data;
using BussinessLogic.DatabaseAccessObjects;
using BussinessLogic.DataTransferObjects;

namespace Service
{
    public class LoanService : ICommonService<Loan>
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
    }
}
