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
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int PermissionId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Permission Permission { get; set; }
    }
}