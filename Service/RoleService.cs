using DatabaseAccess.DataTransferObjects;
using System.Data;
using DatabaseAccess.DatabaseAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class RoleService : ICommonService<Role>,IRoleService
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

        public List<Role> GetRoles()
        {
            return _roleDAO.GetAll().Rows.Cast<DataRow>()
                .Select<DataRow,Role>(r => new Role
                {
                    RoleId = Convert.ToInt32(r["RoleId"]),
                    Name = Convert.ToString(r["Name"])
                }).ToList();
        }

        public int Update(Role role)
        {
            return _roleDAO.Update(role);
        }
    }
}
