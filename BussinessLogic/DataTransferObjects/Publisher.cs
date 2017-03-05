using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    public class Publisher : DataTranseferObject
    {
        private int _publisherId;

        public int PublisherId
        {
            get { return _publisherId; }
            set { _publisherId = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
