using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Publisher : DataTranseferObject
    {
        private int _publisherId;
        [DataMember]
        public int PublisherId
        {
            get { return _publisherId; }
            set { _publisherId = value; }
        }
        private string _name;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        private string _description;
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
