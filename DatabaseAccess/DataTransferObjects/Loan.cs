using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Loan : DataTranseferObject
    {
        private int _loanId;
        [DataMember]
        public int LoanId
        {
            get { return _loanId; }
            set { _loanId = value; }
        }
        private DateTime _issueDate;
        [DataMember]
        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }
        private int _limitDay;
        [DataMember]
        public int LimitDay
        {
            get { return _limitDay; }
            set { _limitDay = value; }
        }
        private int _memberId;
        [DataMember]
        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }
        private int _librarianId;
        [DataMember]
        public int LibrarianId
        {
            get { return _librarianId; }
            set { _librarianId = value; }
        }
    }
}
