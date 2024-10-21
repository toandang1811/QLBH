using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Permissions")]
    public class Permission
    {
        [Key, Column(Order = 0)]
        public string PermissionId { get; set; }
        [Key, Column(Order = 1)]
        public string ModuleId { get; set; }
        public string PermissionName { get; set; }
        public virtual Module Module { get; set; }

    }
}