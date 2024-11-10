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
    [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_PRODUCTCATEGORIES)]
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_PRODUCTCATEGORIES)]
        public ActionResult Index()
        {
            var items = db.ProductCategories;
            return View(items);
        }

        [CustomAuthorize(permission: _Environment.ADD, moduleId: _Environment.M_PRODUCTCATEGORIES)]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(permission: _Environment.ADD, moduleId: _Environment.M_PRODUCTCATEGORIES)]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.CreatedBy = User.Identity.Name;
                model.Modifiedby = User.Identity.Name;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.ProductCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [CustomAuthorize(permission: _Environment.UPDATE, moduleId: _Environment.M_PRODUCTCATEGORIES)]
        public ActionResult Edit(int id)
        {
            var item = db.ProductCategories.Find(id);
            return View(item);
        }

        [HttpPost]
        [CustomAuthorize(permission: _Environment.UPDATE, moduleId: _Environment.M_PRODUCTCATEGORIES)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                model.Modifiedby = User.Identity.Name;
                db.ProductCategories.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}