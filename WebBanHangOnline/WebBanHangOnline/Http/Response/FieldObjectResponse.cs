using Entities.UIConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Response
{
    public class FieldObjectResponse
    {
        public List<FieldObject> Fields { get; set; }
        public int CountColumns
        {
            get
            {
                return Fields != null ? Fields.Count : 0;
            }
        }
    }
}