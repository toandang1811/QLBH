using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Common
{
    public class _Environment
    {
        public static string Email { get; set; } = ConfigurationManager.AppSettings["Email"];
        public static string PassWordEmail { get; set; } = ConfigurationManager.AppSettings["PasswordEmail"];
        public static string CLOUD_NAME { get; } = ConfigurationManager.AppSettings["cloud_name"];
        public static string API_KEY { get; } = ConfigurationManager.AppSettings["api_key"];
        public static string API_SECRET { get; } = ConfigurationManager.AppSettings["api_secret"];
    }
}