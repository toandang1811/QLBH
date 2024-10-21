using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHangOnline.DataAccess;

namespace DataAccess
{
    public class ThongKeDAL : BaseDAL
    {
        public ThongKeModel ThongKe()
        {
            var item = new ThongKeModel();
            try
            {
                Connection.Open();
                item = Connection.QueryFirstOrDefault<ThongKeModel>("sp_ThongKe", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return item;
        }
    }
}
