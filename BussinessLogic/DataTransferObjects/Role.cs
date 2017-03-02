using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataTransferObjects
{
    public class Role : DataTranseferObject
    {
        private int _roleId;

        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
