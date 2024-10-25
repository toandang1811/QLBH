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
        private const string SQL_GetListUserRoleByUserId = @"
                SELECT UserId, RoleId FROM AspNetUserRoles WHERE UserId = @UserId";

        private const string SQL_UpdateUser = @"
            UPDATE AspNetUsers 
            SET FullName = @FullName, Phone = @Phone, PhoneNumber = @Phone
            WHERE Id = @Id
        ";
        private const string SQL_GetRoleNameBayRoleId = @"SELECT Name FROM AspNetRoles WHERE Id = @Id";
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

        public List<UserRole> GetListUserRoleByUserId(string userId)
        {
            var items = new List<UserRole>();
            try
            {
                Connection.Open();
                items = Connection.Query<UserRole>(SQL_GetListUserRoleByUserId,
                    new
                    {
                        UserId = userId
                    },
                    commandType: CommandType.Text).ToList();
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return items;
        }

        public string GetRoleNameByRoleId(string roleId)
        {
            string roleName = string.Empty;
            try
            {
                Connection.Open();
                roleName = Connection.QuerySingle<string>(SQL_GetRoleNameBayRoleId,
                    new
                    {
                        Id = roleId
                    },
                    commandType: CommandType.Text);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return roleName;
        }
    }
}