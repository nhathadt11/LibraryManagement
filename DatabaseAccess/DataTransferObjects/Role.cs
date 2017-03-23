using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Role : DataTranseferObject
    {
        private int _roleId;
        [DataMember]
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        private string _name;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
