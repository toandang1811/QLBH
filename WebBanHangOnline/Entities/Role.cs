using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public const string OBJECTID = "role";
        public const string FIELD_ROLEID = "RoleId";
        public const string FIELD_ROLENAME = "RoleName";
        public const string FIELD_DESCRIPTION = "Description";
        public const string FIELD_ISACTIVE = "IsActive";

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
