using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Common;

namespace WebBanHangOnline.Areas.Admin
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _permission;
        private readonly string _moduleId;
        public CustomAuthorizeAttribute(string permission, string moduleId)
        {
            _permission = permission;
            _moduleId = moduleId;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/admin/account/login");
            }
            else
            {
                // Nếu người dùng đã đăng nhập nhưng không có quyền, trả về view không có quyền truy cập
                filterContext.Result = new ViewResult
                {
                    ViewName = "_UnAuthorization" // Tên view hiển thị thông báo không có quyền truy cập
                };
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userBl = new UserBL();
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false; // Người dùng chưa đăng nhập
            }

            // Kiểm tra quyền dựa trên moduleId và permission
            return userBl.CheckHasPermission(_Environment.UserId, _moduleId, _permission);
        }
    }
}