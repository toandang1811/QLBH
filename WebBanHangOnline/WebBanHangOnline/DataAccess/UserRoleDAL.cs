using Dapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.DataAccess
{
    public class UserRoleDAL : BaseDAL
    {
        #region ---- SQL query ----
        private const string SQL_GetAllUserRole = @"
                SELECT  u.ID, u.FullName, u.UserName, u.Avatar, u.Email, u.Phone, r.Id AS Role, r.Name AS RoleName 
                FROM AspNetUsers u
                LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
                LEFT JOIN AspNetRoles r ON r.Id = ur.RoleId
                WHERE u.UserName = @UserName";

        private const string SQL_UpdateUser = @"
            UPDATE AspNetUsers 
            SET FullName = @FullName, Phone = @Phone, PhoneNumber = @Phone
            WHERE Id = @Id
        ";
        #endregion ---- SQL query ----

        public UserRoleDAL(DbTransaction tran) : base(tran) { }
        public UserRoleDAL() { }

        /// <summary>
        /// Get all user role
        /// </summary>
        /// <returns></returns>
        public EditAccountViewModel GetAll(string pUserName)
        {
            SqlCommand command = null;
            try
            {
                _Connection.Open();
                command = new SqlCommand();
                command.Connection = _Connection;
                command.CommandText = SQL_GetAllUserRole;
                command.Parameters.AddWithValue("@UserName", pUserName);
                var reader = command.ExecuteReader();
                EditAccountViewModel usr = null;
                if (reader.HasRows && reader.Read())
                {
                    usr = new EditAccountViewModel();
                    usr.Id = reader["ID"].ToString();
                    usr.FullName = reader["FullName"].ToString();
                    usr.UserName = reader["UserName"].ToString();
                    usr.Email = reader["Email"].ToString();
                    usr.Role = reader["Role"].ToString();
                    usr.Phone = reader["Phone"].ToString();
                    usr.RoleName = reader["RoleName"].ToString();
                    usr.Avatar = reader["Avatar"].ToString();
                }
                _Connection.Close();
                return usr;

            }
            catch (Exception ex)
            {
                throw new Exception(WebBanHangOnline.Messages.MessagesInfo.MSG00004, ex);
            }
        }

        public bool Update(EditAccountViewModel model)
        {
            SqlCommand command = null;
            bool success = false;
            try
            {
                _Connection.Open();
                command = new SqlCommand();
                command.Connection = _Connection;
                command.CommandText = SQL_GetAllUserRole;
                command.Parameters.AddWithValue("@Id", model.Id);
                command.Parameters.AddWithValue("@Phone", model.Phone);
                command.Parameters.AddWithValue("@FullName", model.FullName);
                success = command.ExecuteNonQuery() > 0;
                _Connection.Close();
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(WebBanHangOnline.Messages.MessagesInfo.MSG00004, ex);
            }
        }
    }
}