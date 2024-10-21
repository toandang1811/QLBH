using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Areas.Admin
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _permission;
        public CustomAuthorizeAttribute(string roles = null, string permission = null)
        {
            Roles = roles; 
            _permission = permission;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                // Kiểm tra nếu người dùng không có vai trò "Admin"
                if (!filterContext.HttpContext.User.IsInRole("Admin"))
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "_UnAuthorization" // Tên view hiển thị thông báo không có quyền truy cập
                    };
                }
                else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        }
    }
}