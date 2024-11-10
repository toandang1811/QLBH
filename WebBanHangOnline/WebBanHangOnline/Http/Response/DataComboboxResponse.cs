using Entities.UIConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Http.Response
{
    public class DataComboboxResponse
    {
        public SysCombobox Combobox { get; set; }
        public List<SysFieldCombobox> FieldsCombobox { get; set; }
    }
}