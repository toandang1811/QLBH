using Business.UIConfigs;
using Entities.UIConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Http.Response;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class UIConfigsController : Controller
    {
        // GET: Admin/SettingFields
        [HttpPost]
        [Route("get-fields-object")]
        public async Task<ActionResult> GetFieldsObject(string objectId)
        {
            var res = new BaseResponse<List<FieldObject>>();
            try
            {

                using (FieldObjectBL _fieldObjBL = new FieldObjectBL())
                {
                    res.Data = _fieldObjBL.GetColumnObject(objectId);
                    res.IsError = false;
                }
            }
            catch (Exception ex) 
            {
                res.MessageError = ex.Message;
                res.IsError = true;
            }
            return Json(res);
        }

        [HttpPost]
        [Route("get-combobox")]
        public async Task<ActionResult> GetCombobox(string comboboxId)
        {
            var res = new BaseResponse<DataComboboxResponse>();
            try
            {
                using (SysComboboxBL _bl = new SysComboboxBL())
                {
                    res.Data.Combobox = _bl.GetComboboxById(comboboxId);
                    res.Data.FieldsCombobox = _bl.GetFieldsComboByComboId(comboboxId);
                    res.IsError = false;
                }
            }
            catch (Exception ex)
            {
                res.MessageError = ex.Message;
                res.IsError = true;
            }
            return Json(res);
        }
    }
}