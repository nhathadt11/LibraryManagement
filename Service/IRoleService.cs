using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;
using DatabaseAccess.DataTransferObjects;

namespace Service
{
    [ServiceContract]
    interface IRoleService
    {
        [OperationContract]
         int Add(Role role);
        [OperationContract]
        int Delete(int roleId);
        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Update(Role role);
        [OperationContract]
        List<Role> getRoles();
    }
}
