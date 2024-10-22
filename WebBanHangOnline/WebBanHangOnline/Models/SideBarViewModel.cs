using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class SideBarViewModel
    {
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Icon {  get; set; }
        public string Url { get; set; }
        public string ParentId { get; set; }
        public int Orders {  get; set; }
    }
}