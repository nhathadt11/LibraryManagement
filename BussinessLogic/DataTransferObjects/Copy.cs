namespace BussinessLogic.DataTransferObjects
{
    public class Copy : DataTranseferObject
    {
        private int _copyCode;

        public int CopyCode
        {
            get { return _copyCode; }
            set { _copyCode = value; }
        }
        private int _bookId;

        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        private bool _isAvailable;

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }

    }
}
