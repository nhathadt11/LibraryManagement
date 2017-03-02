using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataTransferObjects
{
    public class LoanDetail : DataTranseferObject
    {
        private int _copyCode;

        public int CopyCode
        {
            get { return _copyCode; }
            set { _copyCode = value; }
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
