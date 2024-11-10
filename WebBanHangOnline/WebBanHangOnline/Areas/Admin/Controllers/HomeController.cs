using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using dotenv.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using Microsoft.AspNet.Identity;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Common;
using Business;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_DASHBOARD)]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialSideBar() 
        {
            var userBl = new UserBL();
            var items = new List<SideBarViewModel>();
            var modules = db.Modules.Where(x => x.IsActive && x.IsSideBar).ToList();
            foreach (var module in modules) 
            {
                if (userBl.CheckHasPermission(User.Identity.GetUserId(), module.ModuleId, _Environment.VIEW)) 
                {
                    items.Add(new SideBarViewModel
                    {
                        ModuleId = module.ModuleId,
                        ModuleName = module.ModuleName,
                        Url = module.Url,
                        Icon = module.Icon,
                        ParentId = module.ParentId,
                        Orders = module.Orders,
                    });
                }
            }
            return View(items.OrderBy(x => x.ParentId).OrderBy(x => x.Orders));
        }
    }
}