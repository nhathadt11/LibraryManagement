using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Author : DataTranseferObject
    {
        private int _authorId;
        [DataMember]
        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        private string _fullName;
        [DataMember]
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _contact;
        [DataMember]
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        private string _address;
        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _bio;
        [DataMember]
        public string Bio
        {
            get { return _bio; }
            set { _bio = value; }
        }

    }
}
