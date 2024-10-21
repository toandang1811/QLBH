

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
        public UserRoleDAL() { }
    }
}