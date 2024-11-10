using Business;
using Business.UIConfigs;
using Entities;
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
    [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_PERMISSIONS)]
    public class PermissionsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/Permissions
        [CustomAuthorize(permission: _Environment.VIEW, moduleId: _Environment.M_PERMISSIONS)]
        public ActionResult Index()
        {
            var modules = _context.Modules.ToList();
            ViewBag.Modules = modules;
            return View();
        }

        [HttpPost]
        public ActionResult GetRoles()
        {
            var _fObjBL = new FieldObjectBL(); 
            BaseResponse<DataTaleResponse<Role>> res = new BaseResponse<DataTaleResponse<Role>>() { IsError = false, MessageError = string.Empty, Data = new DataTaleResponse<Role>() };
            try
            {
                res.Data.DataColumns = _fObjBL.GetColumnObject(Role.OBJECTID);
                res.Data.DataRows = new RoleBL().GetRoles();
            }
            catch (Exception ex) 
            {
                res.IsError = true;
                res.MessageError = ex.Message;
            }
            return Json(res);
        }
    }
}