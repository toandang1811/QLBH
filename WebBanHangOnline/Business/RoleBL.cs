using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.Business;

namespace Business
{
    public class RoleBL : BaseBL
    {
        private RoleDAL _roleDal = null;
        public RoleBL()
        {
            _roleDal = new RoleDAL();
        }
        public List<Role> GetRoles()
        {
            return _roleDal.GetRoles();
        }

        public Role GetRoleById(string id)
        {
            return _roleDal.GetRoleById(id);
        }

        public bool CheckRoleIsUsed(string roleId)
        {
            return _roleDal.CheckRoleIsUsed(roleId);
        }

        public bool DeleteRole(string roleId)
        {
            return _roleDal.DeleteRole(roleId);
        }
    }
}
