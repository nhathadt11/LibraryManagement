using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataTransferObjects
{
    public class Category : DataTranseferObject
    {
        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
