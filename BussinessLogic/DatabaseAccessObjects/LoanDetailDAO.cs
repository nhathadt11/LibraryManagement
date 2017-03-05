using System;
using System.Data;
using DatabaseAccess.DataTransferObjects;
using System.Data.SqlClient;

namespace DatabaseAccess.DatabaseAccessObjects
{
    public class LoanDetailDAO : IDataAccessObject<LoanDetail>
    {
        private readonly string SQL_LOAN_DETAILS_SELECT_ALL = "SELECT * FROM LoanDetails";
        private readonly string SQL_LOAN_DETAILS_SELECT_BY_LOAN_ID = "SELECT * FROM LoanDetails WHERE LoanId = @LoanId";
        //required - @CopyId
        //required - @LoanId
        //required - @ReturnDate
        private readonly string SQL_LOAN_DETAILS_INSERT = "InsertLoanDetail";//return -1 if CopyId not valid
                                                                             //return -2 if LoanId not valid
                                                                             //return this Id if insert successfully
        private readonly string SQL_LOAN_DETAILS_UPDATE = "";
        private readonly string SQL_LOAN_DETAILS_DELETE = "";
        private DataProvider _dataProvider;
        private static LoanDetailDAO _instance;
        private LoanDetailDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static LoanDetailDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoanDetailDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_LOAN_DETAILS_SELECT_ALL,
                                              CommandType.Text);
        }

        public int Add(LoanDetail loanDetail)
        {
            return _dataProvider.ExecuteNonQuery(SQL_LOAN_DETAILS_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@CopyCode", loanDetail.CopyId),
                                                 new SqlParameter("@LoanId", loanDetail.LoanId));
        }

        public int Update(LoanDetail loanDetail)
        {
            return _dataProvider.ExecuteNonQuery(SQL_LOAN_DETAILS_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@CopyCode", loanDetail.CopyId),
                                                 new SqlParameter("@LoanId", loanDetail.LoanId),
                                                 new SqlParameter("@ReturnDate", loanDetail.ReturnDate));
        }

        public int Delete(int loanDetailId)
        {
            throw new NotImplementedException();
        }
        public DataTable GetLoanDetailsByLoanId(int loanId)
        {
            return _dataProvider.ExecuteQuery(SQL_LOAN_DETAILS_SELECT_BY_LOAN_ID,
                                              CommandType.Text,
                                              new SqlParameter("@LoanId", loanId));
        }
    }
}
