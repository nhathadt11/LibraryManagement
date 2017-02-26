﻿using System;
using System.Data;
using BussinessLogic.DataTransferObjects;
using DatabaseAccess;
using System.Data.SqlClient;

namespace BussinessLogic.DatabaseAccessObjects
{
    public class LoanDetailDAO : IDataAccessObject<LoanDetail>
    {
        private readonly string SQL_STORE_PROC_LOAN_DETAIL_SELECT = "select * from LoanDetails";

        //required - @CopyId
        //required - @LoanId
        //required - @ReturnDate
        private readonly string SQL_STORE_PROC_LOAN_DETAIL_INSERT = "InsertLoanDetail";//return -1 if CopyId not valid
                                                                                       //return -2 if LoanId not valid
                                                                                       //return this Id if insert successfully
        private readonly string SQL_STORE_PROC_LOAN_DETAIL_UPDATE = "";
        private readonly string SQL_STORE_PROC_LOAN_DETAIL_DELETE = "";
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
            return _dataProvider.ExecuteQuery(SQL_STORE_PROC_LOAN_DETAIL_SELECT,
                                              CommandType.Text);
        }

        public int Add(LoanDetail loanDetail)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_LOAN_DETAIL_INSERT,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@CopyCode", loanDetail.CopyCode),
                                                 new SqlParameter("@LoanId", loanDetail.LoanId));
        }

        public int Update(LoanDetail loanDetail)
        {
            return _dataProvider.ExecuteNonQuery(SQL_STORE_PROC_LOAN_DETAIL_UPDATE,
                                                 CommandType.StoredProcedure,
                                                 new SqlParameter("@CopyCode", loanDetail.CopyCode),
                                                 new SqlParameter("@LoanId", loanDetail.LoanId),
                                                 new SqlParameter("@ReturnDate", loanDetail.ReturnDate));
        }

        public int Delete(int loanDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
