using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Response
{
    public class UpdateImageProductResponse
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public bool IsDefault { get; set; }
    }
}