using DataAccess.UIConfigs;
using Entities.UIConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.Business;

namespace Business.UIConfigs
{
    public class SysComboboxBL : BaseBL
    {
        private SysComboboxDAL _dal = null;
        public SysComboboxBL()
        {
            _dal = new SysComboboxDAL();
        }
        public SysCombobox GetComboboxById(string comboboxId)
        {
            return _dal.GetComboboxById(comboboxId);
        }

        public List<SysFieldCombobox> GetFieldsComboByComboId(string comboboxId)
        {
            return _dal.GetFieldsComboByComboId(comboboxId);
        }
    }
}
