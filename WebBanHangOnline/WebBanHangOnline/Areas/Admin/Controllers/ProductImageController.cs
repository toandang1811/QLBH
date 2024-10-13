using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Common;
using WebBanHangOnline.Http.Request;
using WebBanHangOnline.Http.Response;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute(Roles = "Admin,Employee")]
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly Cloudinary _cloudinary;
        public ProductImageController()
        {
            var account = new Account(
                ConfigurationManager.AppSettings["cloud_name"],
                ConfigurationManager.AppSettings["api_key"],
                ConfigurationManager.AppSettings["api_secret"]
            );
            _cloudinary = new Cloudinary(account);
        }
        // GET: Admin/ProductImage
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = db.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId,string url)
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = true,
                Folder = "Product"
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            string uploadedImageUrl = uploadResult.SecureUrl.ToString();
            if (!string.IsNullOrEmpty(uploadedImageUrl)) 
            {
                db.ProductImages.Add(new ProductImage
                {
                    ProductId = productId,
                    Image = uploadedImageUrl,
                    IsDefault = false
                });
                db.SaveChanges();
            }
            return Json(new { Success=true});
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImages.Find(id);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult Update(List<UpdateImageProductRequest> request, List<int> deleteIds, int productId,string idDefault = null)
        {
            var res = new BaseResponse<List<ProductImage>>();
            try
            {
                var listImg = db.ProductImages.Where(x => x.ProductId == productId).ToList();
                foreach (var item in listImg)
                {
                    item.IsDefault = false;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                if (!string.IsNullOrEmpty(idDefault) && !idDefault.StartsWith("image-add"))
                {
                    int id = int.Parse(idDefault.Split('-').LastOrDefault());
                    var item = db.ProductImages.Find(id);
                    item.IsDefault = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                if (request != null)
                {
                    foreach (var file in request)
                    {
                        if (file != null && file.httpPostedFileBase.ContentLength > 0)
                        {
                            var uploadResult = Applications.Instance.UploadImageCloudinary("ProductImages", file.httpPostedFileBase.FileName, file.httpPostedFileBase.InputStream);
                            string uploadedImageUrl = uploadResult.SecureUrl.ToString();
                            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(uploadedImageUrl))
                            {
                                db.ProductImages.Add(new ProductImage
                                {
                                    ProductId = productId,
                                    Image = uploadedImageUrl,
                                    IsDefault = !string.IsNullOrEmpty(idDefault) && file.Id == idDefault,
                                    PublicId = uploadResult.PublicId
                                });
                            }
                        }
                    }
                }

                if (deleteIds != null && deleteIds.Count > 0)
                {
                    foreach (var id in deleteIds)
                    {
                        var item = db.ProductImages.Find(id);
                        if (Applications.Instance.DeleteImageCloudinary(item.PublicId))
                        {
                            db.ProductImages.Remove(item);
                        }
                    }
                }
                db.SaveChanges();

                res.IsError = false;
                res.Error = string.Empty;
                res.Data = db.ProductImages.Where(x => x.ProductId == productId).ToList();
            }
            catch (Exception ex) 
            {
                res.IsError = true;
                res.Error = ex.Message;
                res.Data = null;
            }
            return Json(res);
        }
    }
}