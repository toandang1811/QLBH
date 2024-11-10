using Entities;
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
        public const string VIEW = "view";
        public const string ADD = "add";
        public const string UPDATE = "update";
        public const string DELETE = "delete";

        #region modules
        public const string M_ACCOUNTS = "accounts";
        public const string M_ADVS = "advs";
        public const string M_CATEGORIES = "categories";
        public const string M_CONFIGS = "config";
        public const string M_DASHBOARD = "dashboard";
        public const string M_MANAGERPRODUCT = "managerproduct";
        public const string M_NEWS = "news";
        public const string M_ORDERS = "orders";
        public const string M_PERMISSIONS = "permissions";
        public const string M_POSTS = "posts";
        public const string M_PRODUCTCATEGORIES = "productcategories";
        public const string M_PRODUCTS = "products";
        #endregion

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
        public static List<Role> Roles {  get; set; } 

    }
}