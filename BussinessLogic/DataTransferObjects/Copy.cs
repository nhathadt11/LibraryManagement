using System.Runtime.Serialization;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Copy : DataTranseferObject
    {
        private int _copyId;
        [DataMember]
        public int CopyId
        {
            get { return _copyId; }
            set { _copyId = value; }
        }
        private int _bookId;
        [DataMember]
        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        private bool _isAvailable;
        [DataMember]
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }

    }
}
