using System.Data;
using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Windows.Forms;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class LoanDAO : IDataAccessObject<Loan>
    {
        private readonly string SQL_LOAN_SELECT = "SELECT * FROM Loans";

        //optional @IssueDate
        //optional @Limit
        //required @MemberId
        //required @LibrarianId
        private readonly string SQL_LOAN_INSERT = "InsertLoan";//return -1 if member Id not valid
                                                                          //return -2 if LibrarianId not valid
                                                                          //return 1 if insert successfully
        private readonly string SQL_LOAN_UPDATE = "";

        //requied @LoanId
        private readonly string SQL_LOAN_DELETE = "";//return -1 if this has already reference by the others
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
            return _dataProvider.ExecuteQuery(SQL_LOAN_SELECT,
                                              CommandType.Text);
        }

        public int Add(Loan loan)
        {
            return _dataProvider.ExecuteNonQuery(SQL_LOAN_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@IssueDate", loan.IssueDate),
                                                 new SqlParameter("@LimitDay", loan.LimitDate),
                                                 new SqlParameter("@MemberId", loan.MemberId),
                                                 new SqlParameter("@LibrarianId", loan.LibrarianId));
        }

        public int Update(Loan loan)
        {
            return _dataProvider.ExecuteNonQuery(SQL_LOAN_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@IssueDate", loan.IssueDate),
                                                 new SqlParameter("@LimitDay", loan.LimitDate),
                                                 new SqlParameter("@MemberId", loan.MemberId),
                                                 new SqlParameter("@LibrarianId", loan.LibrarianId),
                                                 new SqlParameter("@LoanId", loan.LoanId));
        }

        public int Delete(int loanId)
        {
            return _dataProvider.ExecuteNonQuery(SQL_LOAN_DELETE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@LoanId", loanId));
        }
        public int Add(Loan loan, List<LoanDetail> loanDetailList)
        {
            DataProvider provider = DataProvider.Instance;
            using (SqlConnection connection = new SqlConnection(provider.ConnectionString))
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "INSERT Loans (IssueDate, LimitDay, MemberId, LibrarianId) "
                                    + "VALUES(@IssueDate, @LimitDay, @MemberId, @LibrarianId); "
                                    + "SELECT SCOPE_IDENTITY()";
                command.Parameters.AddWithValue("@IssueDate", loan.IssueDate);
                command.Parameters.AddWithValue("@LimitDay", loan.LimitDate);
                command.Parameters.AddWithValue("@MemberId", loan.MemberId);
                command.Parameters.AddWithValue("@LibrarianId", loan.LibrarianId);

                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    int loanId = Convert.ToInt32(command.ExecuteScalar());
                    if (loanId > 0)
                    {
                    
                        command.CommandText = "INSERT LoanDetails (CopyId, LoanId) VALUES(@CopyId, @LoanId)";
                        command.Parameters.Add("@CopyId", SqlDbType.Int);
                        command.Parameters.Add("@LoanId", SqlDbType.Int);
                        foreach (var loanDetail in loanDetailList)
                        {
                            command.Parameters["@CopyId"].Value = loanDetail.CopyId;
                            command.Parameters["@LoanId"].Value = loanDetail.LoanId;
                        }
                    }
                    transaction.Commit();
                    return loanId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("Transaction failed and has been rolled back!");
                    return -100;
                }
            }
        }
    }
}
