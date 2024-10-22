using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.Business;
using WebBanHangOnline.DataAccess;

namespace Business
{
    public class UserBL : BaseBL
    {
        private UserDAL _dl = null;
        public UserBL() 
        {
            _dl = new UserDAL();
        }

        public UserInfo GetUserInfo(string userId)
        {
            return _dl.GetUserInfo(userId);
        }
    }
}
