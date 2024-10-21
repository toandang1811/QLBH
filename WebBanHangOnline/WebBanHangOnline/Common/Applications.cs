using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Common
{
    public class Applications
    {
        private static Applications instance;
        public static Applications Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Applications();
                }
                return instance;
            }
            private set
            {
                Applications.instance = value;
            }
        }
        #region messages
        public const string MsgErr = "Đã xảy ra lỗi trong quá trình xử lý!";
        #endregion

        
        private Cloudinary _cloudinary;

        /// <summary>
        /// Send Mail to customer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="toMail"></param>
        /// <returns></returns>
        public bool SendMail(string name, string subject, string content,
            string toMail)
        {
        bool rs = false;
            try
            {
                MailMessage message = new MailMessage();
                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com"; //host name
                    smtp.Port = 587; //port number
                    smtp.EnableSsl = true; //whether your smtp server requires SSL
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential() { 
                        UserName = _Environment.EMAIL,
                        Password= _Environment.PASSWORDEMAIL
                    };
                }
                MailAddress fromAddress = new MailAddress(_Environment.EMAIL, name);
                message.From = fromAddress;
                message.To.Add(toMail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;
                smtp.Send(message);
                rs = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                rs = false;
            }
            return rs;
        }

        /// <summary>
        /// Upload ảnh lên cloudinary
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="fileName"></param>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public ImageUploadResult UploadImageCloudinary(string folder, string fileName, Stream inputStream)
        {
            if (_cloudinary == null)
            {
                var account = new Account(
                    _Environment.CLOUD_NAME,
                    _Environment.API_KEY,
                    _Environment.API_SECRET
                );
                _cloudinary = new Cloudinary(account);
            }
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, inputStream),
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = true,
                Folder = folder
            };
            return _cloudinary.Upload(uploadParams);
        }

        /// <summary>
        /// Xóa ảnh cloudinary
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        public bool DeleteImageCloudinary(string publicId)
        {
            if (_cloudinary == null)
            {
                var account = new Account(
                    _Environment.CLOUD_NAME,
                    _Environment.API_KEY,
                    _Environment.API_SECRET
                );
                _cloudinary = new Cloudinary(account);
            }
            var deleteParams = new DeletionParams(publicId);
            var deleteResult = _cloudinary.Destroy(deleteParams);

            if (deleteResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public bool DeleteImageCloudinary(List<string> publicIds)
        {
            if (_cloudinary == null)
            {
                var account = new Account(
                    _Environment.CLOUD_NAME,
                    _Environment.API_KEY,
                    _Environment.API_SECRET
                );
                _cloudinary = new Cloudinary(account);
            }
            var deleteParams = new DelResParams()
            {
                PublicIds = publicIds,
                Type = "upload",
                ResourceType = ResourceType.Image
            };
            var result = _cloudinary.DeleteResources(deleteParams);
            if (result.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Format number
        /// </summary>
        /// <param name="value"></param>
        /// <param name="SoSauDauPhay"></param>
        /// <returns></returns>
        public string FormatNumber(object value, int SoSauDauPhay = 2)
        {
                bool isNumber = IsNumeric(value);
            decimal GT = 0;
            if (isNumber)
            {
                GT = Convert.ToDecimal(value);
            }
            string str = "";
            string thapPhan = "";
            for (int i = 0; i < SoSauDauPhay; i++)
            {
                thapPhan += "#";
            }
            if (thapPhan.Length > 0) thapPhan = "." + thapPhan;
            string snumformat = string.Format("0:#,##0{0}", thapPhan);
            str = String.Format("{" + snumformat + "}", GT);

            return str;
        }
        private bool IsNumeric(object value)
        {
            return value is sbyte
                       || value is byte
                       || value is short
                       || value is ushort
                       || value is int
                       || value is uint
                       || value is long
                       || value is ulong
                       || value is float
                       || value is double
                       || value is decimal;
        }

        public bool HasPermission(string moduleId, string permissionId, string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.Find(userId);
                if (user != null && user.Roles.Any())
                {
                    foreach (var role in user.Roles)
                    {
                        if (RoleHasPermission(role.RoleId, permissionId))
                        {
                            return true;
                        }
                    }
                }
                return db.UserPermissions.Any(x => x.UserId == userId && x.PermissionId == permissionId && x.ModuleId == moduleId);
            }
        }

        public bool RoleHasPermission(string roleId, string permissionId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.RolePermissions.Any(x => x.RoleId == roleId && x.PermissionId == permissionId);
            }
        }
    }
}