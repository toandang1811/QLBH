using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DataAccess
{
    public class UserDAL : BaseDAL
    {
        #region ---- SQL query ----
        private const string SQL_GetUserInfo = @"
        SELECT Id AS UserId, UserName, FullName, Phone, Avatar, Email
        FROM AspNetUsers
        WHERE Id = @UserId";
        #endregion ---- SQL query ----

        public UserInfo GetUserInfo(string userId)
        {
            UserInfo item = null;
            try
            {
                Connection.Open();
                item = Connection.QueryFirstOrDefault<UserInfo>(SQL_GetUserInfo,
                    new
                    {
                        UserId = userId
                    },
                    commandType: CommandType.Text);
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