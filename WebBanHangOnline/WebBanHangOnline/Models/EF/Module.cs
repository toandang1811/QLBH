using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Modules")]
    public class Module
    {
        [Key]
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int IsActive { get; set; }
        public int Orders {  get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
    }
}