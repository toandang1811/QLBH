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
    public class FieldObjectBL : BaseBL
    {
        private FieldObjectDAL _dal = null;
        public FieldObjectBL()
        {
            _dal = new FieldObjectDAL();
        }

        public List<FieldObject> GetColumnObject(string objectId)
        {
            return _dal.GetColumnObject(objectId);
        }
    }
}
