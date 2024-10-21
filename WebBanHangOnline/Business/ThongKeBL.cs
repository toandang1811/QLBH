using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ThongKeBL
    {
        private ThongKeDAL _dal = null;
        public ThongKeBL() 
        {
            _dal = new ThongKeDAL();
        }

        public ThongKeModel ThongKe()
        {
            return _dal.ThongKe();
        }
    }
}
