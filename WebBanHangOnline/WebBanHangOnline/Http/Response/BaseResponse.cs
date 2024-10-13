using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Response
{
    public class BaseResponse<T>
    {
        public bool IsError { get; set; }
        public string MessageError {  get; set; }
        public T Data { get; set; }
    }
}