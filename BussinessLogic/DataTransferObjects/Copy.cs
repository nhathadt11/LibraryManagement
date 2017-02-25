using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataTransferObjects
{
    class Copy
    {
        private string _copyId;

        public string CopyId
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
