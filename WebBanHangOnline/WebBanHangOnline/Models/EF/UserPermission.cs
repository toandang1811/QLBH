using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_UserPermissions")]
    public class UserPermission
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public string PermissionId { get; set; }
        [Key, Column(Order = 2)]
        public string ModuleId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Permission Permission { get; set; }
    }
}