using DatabaseAccess.DataTransferObjects;
using System.Data;
using DatabaseAccess.DatabaseAccessObjects;

namespace Service
{
    public class RoleService : ICommonService<Role>
    {
        private RoleDAO _roleDAO;
        public RoleService()
        {
            _roleDAO = RoleDAO.Instance;
        }
        public int Add(Role role)
        {
            return _roleDAO.Add(role);
        }

        public int Delete(int roleId)
        {
            return _roleDAO.Delete(roleId);
        }

        public DataTable GetAll()
        {
            return _roleDAO.GetAll();
        }

        public int Update(Role role)
        {
            return _roleDAO.Update(role);
        }
    }
}
