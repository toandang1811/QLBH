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
        [Key]
        public int PermissionId { get; set; }

        public string PermissionName { get; set; }
    }
}