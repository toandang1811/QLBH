using Business;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Common;
using WebBanHangOnline.Http.Response;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Role
        public ActionResult Index()
        {
            var items = db.Roles.ToList();
            return View(items);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                roleManager.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Roles.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                roleManager.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string ids)
        {
            var rp = new BaseResponse<bool>();
            var roleBl = new RoleBL();
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                try
                {
                    var errors = new List<string>();
                    foreach (var item in items)
                    {
                        if (roleBl.CheckRoleIsUsed(item))
                        {
                            errors.Add($"Vai trò {roleBl.GetRoleById(item).RoleName} đã được sử dụng.");
                        }
                        else
                        {
                            roleBl.DeleteRole(item);
                        }
                    }
                    rp.IsError = false;
                    rp.Data = true;
                    rp.ErrorItems = errors;
                }
                catch (Exception ex) 
                {
                    rp.MessageError = ex.Message;
                    rp.IsError = true;
                    rp.Data = false;
                }
            }
            else
            {
                rp.MessageError = "Xóa không thành công.";
                rp.IsError = true;
                rp.Data = false;
            }
            return Json(rp);
        }
    }
}