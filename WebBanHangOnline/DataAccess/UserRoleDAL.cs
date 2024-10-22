

using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebBanHangOnline.DataAccess
{
    public class UserRoleDAL : BaseDAL
    {
        #region ---- SQL query ----
        private const string SQL_GetListUserRoleByUserId = @"
                SELECT UserId, RoleId FROM AspNetUserRoles WHERE UserId = @UserId";

        private const string SQL_UpdateUser = @"
            UPDATE AspNetUsers 
            SET FullName = @FullName, Phone = @Phone, PhoneNumber = @Phone
            WHERE Id = @Id
        ";
        #endregion ---- SQL query ----
        public UserRoleDAL() { }

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
    }
}