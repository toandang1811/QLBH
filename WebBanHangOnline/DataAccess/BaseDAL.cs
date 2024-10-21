using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DataAccess
{
    public class BaseDAL
    {
        private string strConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        private SqlConnection _connection;
        protected SqlConnection Connection 
        { 
            get 
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(strConnect);
                }
                return _connection;
            }
            set { _connection = value; }
        }
    }
}