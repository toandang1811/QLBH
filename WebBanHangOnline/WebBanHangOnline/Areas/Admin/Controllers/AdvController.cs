using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Common;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_ADVS)]
    public class AdvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Posts
        [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_ADVS)]
        public ActionResult Index()
        {
            var items = db.Posts.ToList();
            return View(items);
        }
        [CustomAuthorize(permission: _Environment.ADD, moduleId: _Environment.M_ADVS)]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(permission: _Environment.ADD, moduleId: _Environment.M_ADVS)]
        public ActionResult Add(Adv model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Modifiedby = User.Identity.Name;
                model.CreatedBy = User.Identity.Name;
                db.Advs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [CustomAuthorize(permission: _Environment.UPDATE, moduleId: _Environment.M_ADVS)]
        public ActionResult Edit(int id)
        {
            var item = db.Advs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(permission: _Environment.UPDATE, moduleId: _Environment.M_ADVS)]
        public ActionResult Edit(Adv model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Modifiedby = User.Identity.Name;
                db.Advs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize(permission: _Environment.DELETE, moduleId: _Environment.M_ADVS)]
        public ActionResult Delete(int id)
        {
            var item = db.Advs.Find(id);
            if (item != null)
            {
                db.Advs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

       
        [HttpPost]
        [CustomAuthorize(permission: _Environment.DELETE, moduleId: _Environment.M_ADVS)]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Advs.Find(Convert.ToInt32(item));
                        db.Advs.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}