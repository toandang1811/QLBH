using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.DataAccess;

namespace DataAccess
{
    public class RoleDAL : BaseDAL
    {
        #region ---- SQL query ----
        private const string SQL_GetRoles = @"
        SELECT Id AS RoleId, Name AS RoleName, Description, IsActive
        FROM AspNetRoles
";
        private const string SQL_GetRoleById = @"
        SELECT Id AS RoleId, Name AS RoleName, Description, IsActive
        FROM AspNetRoles
        WHERE Id = @RoleId
";
        private const string SQL_CheckRoleIsUsed = @"
        SELECT TOP 1 1 
        FROM AspNetUserRoles
        WHERE RoleId = @RoleId
";
        private const string SQL_DeleteRole = @"
        DELETE tb_RolePermissions WHERE RoleId = @RoleId

        DELETE AspNetRoles WHERE Id = @RoleId
";
        #endregion

        public List<Role> GetRoles()
        {
            List<Role> items = new List<Role>();
            try
            {
                Connection.Open();
                items = Connection.Query<Role>(SQL_GetRoles, commandType: CommandType.Text).ToList();
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return items;
        }

        public Role GetRoleById(string roleId)
        {
            Role item = new Role();
            try
            {
                Connection.Open();
                item = Connection.QueryFirstOrDefault<Role>(SQL_GetRoleById, 
                    new
                    {
                        RoleId = roleId
                    }
                    ,commandType: CommandType.Text);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return item;
        }

        public bool CheckRoleIsUsed(string roleId)
        {
            bool rs = false;
            try
            {
                Connection.Open();
                var obj = Connection.ExecuteScalar(SQL_GetRoleById,
                    new
                    {
                        RoleId = roleId
                    }
                    , commandType: CommandType.Text);
                rs = obj != null && Convert.ToInt32(obj) == 1;
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

        public bool DeleteRole(string roleId)
        {
            bool rs = false;
            try
            {
                Connection.Open();
                var obj = Connection.Execute(SQL_DeleteRole,
                    new
                    {
                        RoleId = roleId
                    }
                    , commandType: CommandType.Text);
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
