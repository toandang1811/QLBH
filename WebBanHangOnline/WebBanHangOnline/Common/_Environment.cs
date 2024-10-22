using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.ViewModels;

namespace WebBanHangOnline.Common
{
    public class _Environment
    {
        #region config
        public static string EMAIL { get; set; } = ConfigurationManager.AppSettings["Email"];
        public static string PASSWORDEMAIL { get; set; } = ConfigurationManager.AppSettings["PasswordEmail"];
        public static string CLOUD_NAME { get; } = ConfigurationManager.AppSettings["cloud_name"];
        public static string API_KEY { get; } = ConfigurationManager.AppSettings["api_key"];
        public static string API_SECRET { get; } = ConfigurationManager.AppSettings["api_secret"];
        #endregion

        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public static string Address { get; set; }
        public static string AvatarUrl { get; set; }

    }
}