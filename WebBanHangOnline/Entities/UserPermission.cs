using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserPermission
    {
        public string UserId { get; set; }
        public string PermissionId { get; set; }
        public string ModuleId { get; set; }
    }
}
