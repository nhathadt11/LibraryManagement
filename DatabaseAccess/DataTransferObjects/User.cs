using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class User : DataTranseferObject
    {
        private int _userId;
        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _username;
        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _password;
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _fullName;
        [DataMember]
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _phoneNumber;
        [DataMember]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        private string _address;
        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private int _roleId;
        [DataMember]
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

    }
}
