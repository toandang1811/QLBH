using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHangOnline.DataAccess;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Business
{
    public class UserRoleBL : BaseBL
    {
        private UserRoleDAL _dal = new UserRoleDAL();
        public EditAccountViewModel GetAll(string pUserName)
        {
            try
            {
                return _dal.GetAll(pUserName);
            }
            catch (Exception ex)
            {
                throw new Exception(WebBanHangOnline.Messages.MessagesInfo.MSG00004, ex);
            }
        }

        public bool Update(EditAccountViewModel model)
        {
            try
            {
                return _dal.Update(model);
            }
            catch (Exception ex)
            {
                throw new Exception(WebBanHangOnline.Messages.MessagesInfo.MSG00004, ex);
            }
        }
    }
}