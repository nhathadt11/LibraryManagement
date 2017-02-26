using System.Data;
using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class LoanDAO : IDataAccessObject<Loan>
    {
        private readonly string SQL_STORE_PROC_LOAN_SELECT = "select * from Loans";

        //optional @IssueDate
        //optional @Limit
        //required @MemberId
        //required @LibrarianId
        private readonly string SQL_STORE_PROC_LOAN_INSERT = "InsertLoan";//return -1 if member Id not valid
                                                                          //return -2 if LibrarianId not valid
                                                                          //return 1 if insert successfully
        private readonly string SQL_STORE_PROC_LOAN_UPDATE = "";

        //requied @LoanId
        private readonly string SQL_STORE_PROC_LOAN_DELETE = "";//return -1 if this has already reference by the others
                                                                //return 0 if this Id does not exists
                                                                //return 1 if deleted successfully
        private DataProvider _dataProvider;
        private static LoanDAO _instance;
        private LoanDAO()
        {
            _dataProvider = DataProvider.Instance;
        }
        public static LoanDAO Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new LoanDAO();
                }
                return _instance;
            }
        }

        public DataTable GetAll()
        {
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_LOAN_SELECT,
                                              CommandType.StoredProcedure);
        }

        public int Add(Loan loan)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_LOAN_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@IssueDate", loan.IssueDate),
                                                 new SqlParameter("@LimitDay", loan.LimitDate),
                                                 new SqlParameter("@MemberId", loan.MemberId),
                                                 new SqlParameter("@LibrarianId", loan.LibrarianId));
        }

        public int Update(Loan loan)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_LOAN_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@IssueDate", loan.IssueDate),
                                                 new SqlParameter("@LimitDay", loan.LimitDate),
                                                 new SqlParameter("@MemberId", loan.MemberId),
                                                 new SqlParameter("@LibrarianId", loan.LibrarianId),
                                                 new SqlParameter("@LoanId", loan.LoanId));
        }

        public int Delete(int loanId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_LOAN_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@LoanId", loanId));
        }
    }
}
