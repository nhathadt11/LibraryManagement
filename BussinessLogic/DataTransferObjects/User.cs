using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    public class User : DataTranseferObject
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private int _roleId;

        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

    }
}
