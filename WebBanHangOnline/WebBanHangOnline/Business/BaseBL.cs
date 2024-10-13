using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Business
{
    public class BaseBL
    {
        protected DbTransaction _Transaction { get; set; }

        public BaseBL()
        {
        }

        public BaseBL(DbTransaction transaction)
        {
            _Transaction = transaction;
        }
    }
}