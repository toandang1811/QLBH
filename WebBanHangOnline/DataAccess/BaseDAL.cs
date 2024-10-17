using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseDAL
    {
        private static string strConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        private SqlConnection _connection;
        protected SqlConnection _Connection
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
        internal DbTransaction Transaction { get; private set; }

        public BaseDAL()
        {
        }

        public BaseDAL(DbTransaction transaction)
        {
            Transaction = transaction;
        }

    }
}
