﻿using System;
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
        public string PermissionId { get; set; }
        public string ModuleId { get; set; }
        public string PermissionName { get; set; }
        public virtual Module Module { get; set; }

    }
}