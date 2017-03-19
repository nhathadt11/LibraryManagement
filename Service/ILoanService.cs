using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DatabaseAccess.DataTransferObjects;
using System.Data;

namespace Service
{
    [ServiceContract]
    public interface ILoanService
    {
        [OperationContract]
        int Delete(int loanId);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(Loan loan);
        [OperationContract]
        int Add(Loan loan, List<LoanDetail> loanDetails);
        [OperationContract]
        List<Loan> GetLoans();
    }
}
