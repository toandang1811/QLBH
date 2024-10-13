using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Request
{
    public class UpdateImageProductRequest
    {
        public string Id { get; set; }
        public HttpPostedFileBase httpPostedFileBase { get; set; }
    }
}