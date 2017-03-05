using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    public class LoanDetail : DataTranseferObject
    {
        private int _copyId;

        public int CopyId
        {
            get { return _copyId; }
            set { _copyId = value; }
        }
        private int _loanId;

        public int LoanId
        {
            get { return _loanId; }
            set { _loanId = value; }
        }
        private DateTime _returnDate;

        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }
    }
}
