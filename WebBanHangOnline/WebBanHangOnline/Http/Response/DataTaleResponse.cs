using Entities.UIConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Response
{
    public class DataTaleResponse<T>
    {
        public List<FieldObject> DataColumns { get; set; }
        public List<T> DataRows { get; set; }
    }
}