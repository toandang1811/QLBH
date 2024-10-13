using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DataAccess
{
    public class UserDAL : BaseDAL
    {
        #region ---- SQL query ----
        private const string SQL_UpdateUser = @"
        UPDATE AspNetUsers 
        SET FullName = @FullName
        , Phone = @Phone
        , PhoneNumber = @Phone
        , 
                ";
        #endregion ---- SQL query ----
    }
}