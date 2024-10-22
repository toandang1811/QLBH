using Business;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebBanHangOnline.Business;

namespace WebBanHangOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UpdateAllUsersSecurityStamp();
            Application["HomNay"] = 0;
            Application["HomQua"] = 0;
            Application["TuanNay"] = 0;
            Application["TuanTruoc"] = 0;
            Application["ThangNay"] = 0;
            Application["ThangTruoc"] = 0;
            Application["TatCa"] = 0;
            Application["visitors_online"] = 0;
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 150;
            Application.Lock();
            Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
            Application.UnLock();
            try
            {
                ThongKeBL _bl = new ThongKeBL();
                var item = _bl.ThongKe();
                if (item!=null)
                {
                    Application["HomNay"] = long.Parse("0" + item.HomNay.ToString("#,###"));
                    Application["HomQua"] = long.Parse("0" + item.HomQua.ToString("#,###"));
                    Application["TuanNay"] = long.Parse("0" + item.ThangNay.ToString("#,###"));
                    Application["TuanTruoc"] = long.Parse("0" + item.ThangTruoc.ToString("#,###"));
                    Application["ThangNay"] = long.Parse("0" + item.ThangNay.ToString("#,###"));
                    Application["ThangTruoc"] = long.Parse("0" + item.ThangTruoc.ToString("#,###"));
                    Application["TatCa"] = (int.Parse(item.TatCa.ToString())).ToString("#,###");
                }
               
            }
            catch { }

        }
        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
            Application.UnLock();
        }

        private void UpdateAllUsersSecurityStamp()
        {
            // Lấy UserManager từ OWIN context
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (userManager != null)
            {
                var users = userManager.Users.ToList();
                foreach (var user in users)
                {
                    // Cập nhật lại SecurityStamp cho từng người dùng
                    userManager.UpdateSecurityStamp(user.Id);
                }
            }
        }
    }
}
