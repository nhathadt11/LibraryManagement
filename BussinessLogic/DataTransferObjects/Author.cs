using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataTransferObjects
{
    public class Author
    {
        private int _authorId;

        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _contact;

        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _bio;

        public string Bio
        {
            get { return _bio; }
            set { _bio = value; }
        }

    }
}
