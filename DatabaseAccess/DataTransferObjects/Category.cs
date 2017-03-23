using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Category : DataTranseferObject
    {
        private int _categoryId;
        [DataMember]
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
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
