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
        #region --- stores procedure ---
        private const string STORE_CHECK_HAS_PERMISSION = "SP_CheckHasPermission";
        #endregion

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
        private const string SQL_GetRoleNameByRoleId = @"SELECT Name FROM AspNetRoles WHERE Id = @Id";
        private const string SQL_GetRolesOfUser = @"SELECT A.Id AS RoleId, A.Name AS RoleName, A.Description, A.IsActive
        FROM AspNetRoles A
        INNER JOIN AspNetUserRoles B ON A.Id = B.RoleId
        WHERE B.UserId = @UserId";
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
                roleName = Connection.QuerySingle<string>(SQL_GetRoleNameByRoleId,
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

        public List<Role> GetRolesOfUser(string userId)
        {
            var items = new List<Role>();
            try
            {
                Connection.Open();
                items = Connection.Query<Role>(SQL_GetRolesOfUser,
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

        public bool CheckHasPermission(string userId, string moduleId, string permissionId)
        {
            if (string.IsNullOrEmpty(userId)) return false;
            bool rs = false;
            try
            {
                Connection.Open();
                var obj = Connection.ExecuteScalar<int>(STORE_CHECK_HAS_PERMISSION,
                    new
                    {
                        UserId = userId,
                        ModuleId = moduleId,
                        PermissionId = permissionId
                    }
                    , commandType: CommandType.StoredProcedure);
                rs = obj > 0;
            }
            catch (Exception ex)
            {
                rs = false;
            }
            finally
            {
                Connection.Close();
            }
            return rs;
        }
    }
}