using CloudinaryDotNet.Actions;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_RolePermissions")]
    public class RolePermission
    {
        [Key, Column(Order = 0)]
        public int RoleId { get; set; }
        [Key, Column(Order = 1)]
        public string PermissionId { get; set; }
        [Key, Column(Order = 2)]
        public string ModuleId { get; set; }
        public virtual IdentityUserRole Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}