using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;
using DatabaseAccess.DataTransferObjects;

namespace Service
{
    [ServiceContract]
    interface ILoanDetailService
    {
        [OperationContract]
         int Add(LoanDetail loanDetail);
        [OperationContract]
        int Delete(int loanDetailId);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(LoanDetail loanDetail);
        [OperationContract]
        List<LoanDetail> GetLoanDetailsByLoanId(int loanId);
        [OperationContract]
        List<LoanDetail> getLoanDetails();
    }
}
