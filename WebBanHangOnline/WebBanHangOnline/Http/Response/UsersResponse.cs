using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Response
{
    public class UsersResponse
    {
        public string UserId { get; set; }
        public string Avatar {  get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Roles> Roles { get; set; }
    }

    public class Roles
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}