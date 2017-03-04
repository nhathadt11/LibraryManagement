namespace BussinessLogic.DataTransferObjects
{
    public class Copy : DataTranseferObject
    {
        private int _copyId;

        public int CopyId
        {
            get { return _copyId; }
            set { _copyId = value; }
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
