using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UIConfigs
{
    public class SysCombobox
    {
        public string ComboboxId { get; set; }
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public string StoredDataLoad { get; set; }
        public string TextDataLoad { get; set; }
        public bool IsUseText { get; set; }
    }
}
