using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebBanHangOnline.DataAccess;

namespace WebBanHangOnline.Business
{
    public class UserRoleBL : BaseBL
    {
        private UserRoleDAL _dal = null;
        public UserRoleBL()
        {
            _dal = new UserRoleDAL();
        }

        public List<UserRole> GetListUserRoleByUserId(string userId)
        {
            return _dal.GetListUserRoleByUserId(userId);
        }
    }
}