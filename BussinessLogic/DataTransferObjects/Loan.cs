using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    public class Loan : DataTranseferObject
    {
        private int _loanId;

        public int LoanId
        {
            get { return _loanId; }
            set { _loanId = value; }
        }
        private DateTime _issueDate;

        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }
        private int _limitDay;

        public int LimitDay
        {
            get { return _limitDay; }
            set { _limitDay = value; }
        }
        private int _memberId;

        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }
        private int _librarianId;

        public int LibrarianId
        {
            get { return _librarianId; }
            set { _librarianId = value; }
        }
    }
}
